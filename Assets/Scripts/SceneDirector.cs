using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    [Header("�X�V����e�L�X�g")]
    [SerializeField, Tooltip("�^�C�}�[�e�L�X�g")] GameObject _timer;
    [SerializeField, Tooltip("�X�R�A�e�L�X�g")] GameObject _score;
    [SerializeField, Tooltip("�c�e���̃e�L�X�g")] GameObject _ammo;

    [SerializeField, Header("�X�^�[�g���̎��Ԃ̎c��")]
    float _time;

    //�c�e��
    public int _ammoCount;

    //�����X�R�A
    int _scorePoint = 0;
    
    TextMeshProUGUI _timerText;
    TextMeshProUGUI _scoreText;
    TextMeshProUGUI _ammoText;
    void Start()
    {
        //�^�C�}�[�ƃX�R�A�̃e�L�X�g�����ꂼ��L���b�V��
        _timerText = _timer.GetComponent<TextMeshProUGUI>();
        _scoreText = _score.GetComponent<TextMeshProUGUI>();
        _ammoText = _ammo.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _time -= Time.deltaTime;
        _timerText.text = $"Time :{_time.ToString("F1")}";


        if (_time < 0)
        {
            SceneManager.LoadScene("ResultScene");
        }

        _scoreText.text = $"Score:{_scorePoint.ToString("F0")}";
        _ammoText.text = $"�c�e��:{_ammoCount.ToString("F0")}";
    }

    public void GetScore()
    {
        _scorePoint += 100;
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
