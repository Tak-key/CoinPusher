using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Header("生成するプレハブアセット")]
    GameObject _spawnObject;

    [SerializeField, Header("生成キー")]
    KeyCode _spawnKey = KeyCode.Space;

    [Header("移動キーと移動量（ユニット/秒）")]
    [SerializeField] KeyCode _moveRightKey = KeyCode.RightArrow;
    [SerializeField] KeyCode _moveLeftKey = KeyCode.LeftArrow;
    [SerializeField, Min(0)] float _moveValue = 3;

    private float _minX = -2.0f;
    private float _maxX = 2.0f;

    void Update()
    {
        // 右移動キーが押されていたら
        if (Input.GetKey(_moveRightKey))
        {
            // スポナーを右に移動させる
            transform.Translate(_moveValue * Time.deltaTime * Vector3.right);
        }

        // 左移動キーが押されていたら
        if (Input.GetKey(_moveLeftKey))
        {
            // スポナーを左に移動させる
            transform.Translate(_moveValue * Time.deltaTime * Vector3.left);
        }

        // 現在位置を変数で保存
        Vector3 _currentPos = transform.position;

        // 現在位置の内、x値の範囲を制限する
        _currentPos.x = Mathf.Clamp(_currentPos.x, _minX, _maxX);

        // 変数の値を、現在位置に代入する
        transform.position = _currentPos;

        // 生成キーが押されたら
        if (Input.GetKeyDown(_spawnKey))
        {
            // プレハブインスタンスを生成する
            Instantiate(_spawnObject, transform.position, transform.rotation * _spawnObject.transform.rotation);

            //GameObject clone = Instantiate(_spawnObject, transform.position, transform.rotation * _spawnObject.transform.rotation);
            //clone.GetComponent<Rigidbody>().velocity = transform.forward * 30;
        }
    }
}
