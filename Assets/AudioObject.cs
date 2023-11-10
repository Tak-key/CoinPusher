using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    // �I�[�f�B�I���Đ�����Ă��邩�̔���
    bool isAudioStart = false;

    [SerializeField, Header("�Z�b�g���鉹")]
    AudioSource _setAudio;

    void Start()
    {
        // �Đ��ƍ��킹�āAisAudioStart��true�ɂ���i��d�Đ��h�~�j
        _setAudio.Play();
        isAudioStart = true;
    }

    void Update()
    {
        // �I�[�f�B�I�̍Đ����I��������A�I�u�W�F�N�g�v�[���ɖ߂�
        if (!_setAudio.isPlaying && isAudioStart)
        {
            Destroy(gameObject);
            //ObjectPool.Instance.ReturnObjectToPool(gameObject);
        }
    }
}
