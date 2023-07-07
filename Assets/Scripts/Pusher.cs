using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField, Min(0), Header("�v�b�V���[�������o����鋗��")]
    float _stroke = 2; // �v�b�V���[�������o����鋗��

    [SerializeField, Min(1), Header("�v�b�V���[�̉����ɂ����鎞��")]
    float _duration = 4; // �v�b�V���[�̉����ɂ����鎞��

    Vector3 _pivot; // �v�b�V���[�̊�_��ێ�����ϐ�
    Vector3 _direction; // �v�b�V���[�̉����o��������ێ�����ϐ�
    Rigidbody _rigidbody; // �����ړ����s�����߂�Rigidbody��ێ�����ϐ�

    void Start()
    {
        // ��_�ƂȂ�J�n���W���擾
        _pivot = transform.position;

        // �����o���������擾
        _direction = -transform.forward;

        // ���g����Rigidbody���擾
        _rigidbody = GetComponent<Rigidbody>();
    }

    // ��Update��FixedUpdate�֕ύX
    void FixedUpdate()
    {
        // �u�o�ߎ��ԁv���u�����o�������̊���(0.0�`1.0)�v�֕ϊ�����
        float t;

        // �����I�Ƀv�b�V���[�𓮂���
        // t = Mathf.PingPong(Time.time * 2, _duration) / _duration;

        // �Ȑ��I�Ƀv�b�V���[�𓮂���
        t = Time.time % _duration; // ���쎞�ԁi�o�ߎ��Ԃ��������ԂŊ������]��j���擾���� ��1
        t = t / _duration; // ���쎞�Ԃ�S�����i0.0�`1.0�j�ɕϊ����� ��2
        t = Mathf.PI * 2 * t; // ���쎞�Ԃ̕S�������R�T�C���g��x���i0.0�`2�΁j�ɕϊ�����
        t = Mathf.Cos(t); // �R�T�C���g��x�����R�T�C���g��y���i1�`-1�`1�j�ɕϊ�����
        t = (-t + 1) / 2; // �R�T�C���g��y���������o�������̊����i0.0�`1.0�j�ɕϊ�����

        // ��1:4�b�����ŃQ�[���J�n����9�b�o�߂Ȃ瓮�쎞�Ԃ�1�b
        // ��2:4�b�����œ��쎞�Ԃ�1�b���_�Ȃ�1/4�b�ŕS������0.25

        // �����o���̕����ʂ��쐬
        Vector3 push = _direction * (_stroke * t);

        // ��_�Ɖ����o���̕����ʂ���V�����ʒu���쐬
        Vector3 position = _pivot + push;

        // �v�b�V���[�̈ړ�
        _rigidbody.MovePosition(position);

    }
}
