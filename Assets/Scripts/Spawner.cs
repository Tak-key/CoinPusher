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

    void Update()
    {
        // 右移動キーが押されていたら
        if (Input.GetKey(_moveRightKey))
        {
            // スポナーを右に移動させる
            transform.Translate(Vector3.right * _moveValue * Time.deltaTime);
        }

        // 左移動キーが押されていたら
        if (Input.GetKey(_moveLeftKey))
        {
            // スポナーを右に移動させる
            transform.Translate(Vector3.left * _moveValue * Time.deltaTime);
        }

        // 生成キーが押されたら
        if (Input.GetKeyDown(_spawnKey))
        {
            // プレハブインスタンスを生成する
            Instantiate(_spawnObject, transform.position, transform.rotation * _spawnObject.transform.rotation);
        }
    }
}
