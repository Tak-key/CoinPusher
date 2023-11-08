using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Header("�V�[���f�B���N�^�[")]
    SceneDirector _sceneDirector;

    [SerializeField, Header("�R�C���̐����L�[")]
    KeyCode _spawnKey = KeyCode.Space;

    [SerializeField, Header("�R�C���̃I�u�W�F�N�g�v�[���W�F�l���[�^�[")]
    ObjectPool _coinGenerator;

    [SerializeField, Header("�R�C���̃X�|�[���|�W�V����")]
    GameObject _spawnPosition;

    [SerializeField, Header("�ړ��L�[�ƈړ��ʁi���j�b�g/�b�j"), Min(0)]
    float _moveValue = 3;

    [SerializeField, Header("���C�������_���[")]
    LineRenderer _lineRenderer;

    [Header("���E�̈ړ����̐����l")]
    [SerializeField, Tooltip("��")] float _minX = -2.0f;
    [SerializeField, Tooltip("�E")] float _maxX = 2.0f;

    [Header("�㉺�̈ړ����̐����l")]
    [SerializeField, Tooltip("��")] float _maxY = 6.0f;
    [SerializeField, Tooltip("��")] float _minY = 2.0f;

    private Vector3[] linePositions;

    private void Start()
    {
    }

    void Update()
    {
        Move();
       
        linePositions = new Vector3[] {new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y, 7)};
        _lineRenderer.startWidth = 0.025f;                   // �J�n�_�̑�����0.1�ɂ���
        _lineRenderer.endWidth = 0.025f;                     // �I���_�̑�����0.1�ɂ���

        _lineRenderer.SetPositions(linePositions);

        if (_sceneDirector._ammoCount <= 0)
            {
                return;
            }
        else if (Input.GetKey(_spawnKey))
        {
        }

        // �����L�[�������ꂽ��
        if (Input.GetKeyUp(_spawnKey))
        {
            
            GameObject _coin = _coinGenerator.GetCoin();
            _coin.transform.position = _spawnPosition.transform.position;
            _coin.transform.rotation = Quaternion.identity;
            Rigidbody _coinRb = _coin.GetComponent<Rigidbody>();
            _coinRb.isKinematic = true;
            _coinRb.isKinematic = false;
            _coinRb.velocity = transform.forward * 30;
            //_sceneDirector.LostAmmo(-1);

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

        // ���݈ʒu��ϐ��ŕۑ�
        Vector3 _currentPos = transform.position;

        // ���݈ʒu�̓��Ax�Ey�l�͈̔͂𐧌�����
        _currentPos.x = Mathf.Clamp(_currentPos.x, _minX, _maxX);
        _currentPos.y = Mathf.Clamp(_currentPos.y, _minY, _maxY);

        // �ϐ��̒l���A���݈ʒu�ɑ������
        transform.position = _currentPos;
    }
}
