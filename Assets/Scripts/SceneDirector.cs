using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    [Header("更新するテキスト")]
    [SerializeField, Tooltip("タイマーテキスト")] GameObject _timer;
    [SerializeField, Tooltip("スコアテキスト")] GameObject _score;
    [SerializeField, Tooltip("残弾数のテキスト")] GameObject _ammo;

    [SerializeField, Header("スタート時の時間の残量")]
    float _time;

    //残弾数
    public int _ammoCount;

    //初期スコア
    int _scorePoint = 0;
    
    TextMeshProUGUI _timerText;
    TextMeshProUGUI _scoreText;
    TextMeshProUGUI _ammoText;
    void Start()
    {
        //タイマーとスコアのテキストをそれぞれキャッシュ
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
        _ammoText.text = $"残弾数:{_ammoCount.ToString("F0")}";
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
