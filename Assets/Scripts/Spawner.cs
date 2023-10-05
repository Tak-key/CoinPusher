using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Header("コインを撃つポインター")]
    GameObject _shotLine;

    [SerializeField, Header("シーンディレクター")]
    SceneDirector _sceneDirector;

    [SerializeField, Header("コインの生成キー")]
    KeyCode _spawnKey = KeyCode.Space;

    [SerializeField, Header("コインのオブジェクトプールジェネレーター")]
    CoinGenerator _coinGenerator;

    [SerializeField, Header("コインのスポーンポジション")]
    GameObject _spawnPosition;

    [SerializeField, Header("移動キーと移動量（ユニット/秒）"), Min(0)]
    float _moveValue = 3;

    [Header("左右の移動幅の制限値")]
    [SerializeField, Tooltip("左")] float _minX = -2.0f;
    [SerializeField, Tooltip("右")] float _maxX = 2.0f;

    [Header("上下の移動幅の制限値")]
    [SerializeField, Tooltip("上")] float _maxY = 6.0f;
    [SerializeField, Tooltip("下")] float _minY = 2.0f;

    private void Start()
    {
        _shotLine.SetActive(false);
    }

    void Update()
    {
        Move();

        if (_sceneDirector._ammoCount <= 0)
            {
                return;
            }
        else if (Input.GetKey(_spawnKey))
        {
            _shotLine.SetActive(true);
        }

        // 生成キーが押されたら
        if (Input.GetKeyUp(_spawnKey))
        {
            
            GameObject _coin = _coinGenerator.GetCoin();
            _coin.transform.position = _spawnPosition.transform.position;
            _coin.transform.rotation = Quaternion.identity;
            Rigidbody _coinRb = _coin.GetComponent<Rigidbody>();
            _coinRb.isKinematic = true;
            _coinRb.isKinematic = false;
            //_coinRb.velocity = transform.forward * 30;
            _sceneDirector.LostAmmo(-1);
            _shotLine.SetActive(false);

            //GameObject clone = Instantiate(_spawnObject, transform.position, transform.rotation * _spawnObject.transform.rotation);
            //clone.GetComponent<Rigidbody>().velocity = transform.forward * 30;
        }
    }

    private void Move()
    {
        float _moveX = Input.GetAxisRaw("Horizontal");
        float _moveY = Input.GetAxisRaw("Vertical");

        Vector3 _moveDirection = new Vector3(_moveX, _moveY, 0).normalized;

        transform.Translate(_moveValue * Time.deltaTime * _moveDirection);

        // 現在位置を変数で保存
        Vector3 _currentPos = transform.position;

        // 現在位置の内、x・y値の範囲を制限する
        _currentPos.x = Mathf.Clamp(_currentPos.x, _minX, _maxX);
        _currentPos.y = Mathf.Clamp(_currentPos.y, _minY, _maxY);

        // 変数の値を、現在位置に代入する
        transform.position = _currentPos;
    }
}
