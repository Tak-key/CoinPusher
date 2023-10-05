using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // 物体が範囲判定に入った時に呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        // 範囲に入った対象Colliderのゲームオブジェクトを削除する
        Destroy(other.gameObject);
    }
}
