using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    //コインジェネレ―タースクリプトを変数として宣言
    ObjectPool _coinGenScript;

    [Header("得点")]
    public int _scorePoint;
    private void Start()
    {
        //コインジェネレ―タースクリプトをキャッシュ
        _coinGenScript = GameObject.FindWithTag("CoinPool").GetComponent<ObjectPool>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ScoreZone":
                ObjectPool.Instance.DelCoin(gameObject);
                SceneDirector.GetScore(_scorePoint);
                break;

            case "DropZone":
                ObjectPool.Instance.DelCoin(gameObject);
                break;
        }
    }
}
