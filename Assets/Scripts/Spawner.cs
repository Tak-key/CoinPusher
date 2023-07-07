using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Header("��������v���n�u�A�Z�b�g")]
    GameObject _spawnObject;

    [SerializeField, Header("�����L�[")]
    KeyCode _spawnKey = KeyCode.Space;

    [Header("�ړ��L�[�ƈړ��ʁi���j�b�g/�b�j")]
    [SerializeField] KeyCode _moveRightKey = KeyCode.RightArrow;
    [SerializeField] KeyCode _moveLeftKey = KeyCode.LeftArrow;
    [SerializeField, Min(0)] float _moveValue = 3;

    void Update()
    {
        // �E�ړ��L�[��������Ă�����
        if (Input.GetKey(_moveRightKey))
        {
            // �X�|�i�[���E�Ɉړ�������
            transform.Translate(Vector3.right * _moveValue * Time.deltaTime);
        }

        // ���ړ��L�[��������Ă�����
        if (Input.GetKey(_moveLeftKey))
        {
            // �X�|�i�[���E�Ɉړ�������
            transform.Translate(Vector3.left * _moveValue * Time.deltaTime);
        }

        // �����L�[�������ꂽ��
        if (Input.GetKeyDown(_spawnKey))
        {
            // �v���n�u�C���X�^���X�𐶐�����
            Instantiate(_spawnObject, transform.position, transform.rotation * _spawnObject.transform.rotation);
        }
    }
}
