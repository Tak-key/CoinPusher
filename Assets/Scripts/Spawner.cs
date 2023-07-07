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

    private float _minX = -2.0f;
    private float _maxX = 2.0f;

    void Update()
    {
        // �E�ړ��L�[��������Ă�����
        if (Input.GetKey(_moveRightKey))
        {
            // �X�|�i�[���E�Ɉړ�������
            transform.Translate(_moveValue * Time.deltaTime * Vector3.right);
        }

        // ���ړ��L�[��������Ă�����
        if (Input.GetKey(_moveLeftKey))
        {
            // �X�|�i�[�����Ɉړ�������
            transform.Translate(_moveValue * Time.deltaTime * Vector3.left);
        }

        // ���݈ʒu��ϐ��ŕۑ�
        Vector3 _currentPos = transform.position;

        // ���݈ʒu�̓��Ax�l�͈̔͂𐧌�����
        _currentPos.x = Mathf.Clamp(_currentPos.x, _minX, _maxX);

        // �ϐ��̒l���A���݈ʒu�ɑ������
        transform.position = _currentPos;

        // �����L�[�������ꂽ��
        if (Input.GetKeyDown(_spawnKey))
        {
            // �v���n�u�C���X�^���X�𐶐�����
            Instantiate(_spawnObject, transform.position, transform.rotation * _spawnObject.transform.rotation);

            //GameObject clone = Instantiate(_spawnObject, transform.position, transform.rotation * _spawnObject.transform.rotation);
            //clone.GetComponent<Rigidbody>().velocity = transform.forward * 30;
        }
    }
}
