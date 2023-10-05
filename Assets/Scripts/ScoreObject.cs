using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    //コインジェネレ―タースクリプトを変数として宣言
    CoinGenerator _coinGenScript;

    [Header("得点")]
    public int _scorePoint;
    private void Start()
    {
        //コインジェネレ―タースクリプトをキャッシュ
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
