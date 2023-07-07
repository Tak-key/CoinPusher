using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField, Min(0), Header("プッシャーが押し出される距離")]
    float _stroke = 2; // プッシャーが押し出される距離

    [SerializeField, Min(1), Header("プッシャーの往復にかかる時間")]
    float _duration = 4; // プッシャーの往復にかかる時間

    Vector3 _pivot; // プッシャーの基点を保持する変数
    Vector3 _direction; // プッシャーの押し出し向きを保持する変数
    Rigidbody _rigidbody; // 物理移動を行うためのRigidbodyを保持する変数

    void Start()
    {
        // 基点となる開始座標を取得
        _pivot = transform.position;

        // 押し出し向きを取得
        _direction = -transform.forward;

        // 自身からRigidbodyを取得
        _rigidbody = GetComponent<Rigidbody>();
    }

    // ↓UpdateをFixedUpdateへ変更
    void FixedUpdate()
    {
        // 「経過時間」を「押し出し距離の割合(0.0～1.0)」へ変換する
        float t;

        // 直線的にプッシャーを動かす
        // t = Mathf.PingPong(Time.time * 2, _duration) / _duration;

        // 曲線的にプッシャーを動かす
        t = Time.time % _duration; // 動作時間（経過時間を周期時間で割った余り）を取得する ※1
        t = t / _duration; // 動作時間を百分率（0.0～1.0）に変換する ※2
        t = Mathf.PI * 2 * t; // 動作時間の百分率をコサイン波のx軸（0.0～2π）に変換する
        t = Mathf.Cos(t); // コサイン波のx軸をコサイン波のy軸（1～-1～1）に変換する
        t = (-t + 1) / 2; // コサイン波のy軸を押し出し距離の割合（0.0～1.0）に変換する

        // ※1:4秒周期でゲーム開始から9秒経過なら動作時間は1秒
        // ※2:4秒周期で動作時間が1秒時点なら1/4秒で百分率は0.25

        // 押し出しの方向量を作成
        Vector3 push = _direction * (_stroke * t);

        // 基点と押し出しの方向量から新しい位置を作成
        Vector3 position = _pivot + push;

        // プッシャーの移動
        _rigidbody.MovePosition(position);

    }
}
