using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [Header("�X�V����e�L�X�g")]
    [SerializeField, Tooltip("�^�C�}�[�e�L�X�g")] TextMeshProUGUI _timerText;
    [SerializeField, Tooltip("�X�R�A�e�L�X�g")] TextMeshProUGUI _scoreText;
    [SerializeField, Tooltip("�c�e���̃e�L�X�g")] TextMeshProUGUI _ammoText;

    [SerializeField, Header("�X�^�[�g���̎��Ԃ̎c��")]
    float _time;

    //�c�e��
    public int _ammoCount;

    //�����X�R�A
    public static int _scorePoint {  get; private set; }
    
    
    void Start()
    {
        
    }

    void Update()
    {
        //_time -= Time.deltaTime;
        //_timerText.text = $"Time :{_time.ToString("F1")}";
        _timerText.SetText("�c�莞�ԁF���u��");


        //if (_time < 0)
        //{
        //    SceneManager.LoadScene("ResultScene");
        //}

        _scoreText.text = $"���_:{_scorePoint.ToString("F0")}";
        //_ammoText.text = $"�c�e��:{_ammoCount.ToString("F0")}";
        _ammoText.SetText("�c�e���F���u��");
    }

    public static void GetScore(int score)
    {
        _scorePoint += score;
    }

    public void GetTime()
    {
        _time += 10;
    }

    public void LostAmmo(int _ammoValue)
    {
        _ammoCount += _ammoValue;
    }

    public void IncreaseAmmo(int _ammoValue)
    {
        _ammoCount += _ammoValue;
    }
}
