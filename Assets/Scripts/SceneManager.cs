using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [Header("更新するテキスト")]
    [SerializeField, Tooltip("タイマーテキスト")] TextMeshProUGUI _timerText;
    [SerializeField, Tooltip("スコアテキスト")] TextMeshProUGUI _scoreText;
    [SerializeField, Tooltip("残弾数のテキスト")] TextMeshProUGUI _ammoText;

    [SerializeField, Header("スタート時の時間の残量")]
    float _time;

    //残弾数
    public int _ammoCount;

    //初期スコア
    public static int _scorePoint {  get; private set; }
    
    
    void Start()
    {
        
    }

    void Update()
    {
        //_time -= Time.deltaTime;
        //_timerText.text = $"Time :{_time.ToString("F1")}";
        _timerText.SetText("残り時間：仮置き");


        //if (_time < 0)
        //{
        //    SceneManager.LoadScene("ResultScene");
        //}

        _scoreText.text = $"得点:{_scorePoint.ToString("F0")}";
        //_ammoText.text = $"残弾数:{_ammoCount.ToString("F0")}";
        _ammoText.SetText("残弾数：仮置き");
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
