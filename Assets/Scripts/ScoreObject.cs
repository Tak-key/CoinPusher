using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    //�R�C���W�F�l���\�^�[�X�N���v�g��ϐ��Ƃ��Đ錾
    CoinGenerator _coinGenScript;

    [Header("���_")]
    public int _scorePoint;
    private void Start()
    {
        //�R�C���W�F�l���\�^�[�X�N���v�g���L���b�V��
        _coinGenScript = GameObject.FindWithTag("CoinPool").GetComponent<CoinGenerator>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ScoreZone":
                _coinGenScript.DelCoin(gameObject);
                break;
        }
    }
}
