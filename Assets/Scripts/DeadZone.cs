using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // ���̂��͈͔���ɓ��������ɌĂ΂��
    private void OnTriggerEnter(Collider other)
    {
        // �͈͂ɓ������Ώ�Collider�̃Q�[���I�u�W�F�N�g���폜����
        Destroy(other.gameObject);
    }
}
