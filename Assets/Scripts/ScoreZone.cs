using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField, Header("シーンディレクター")]
    SceneDirector _sceneDirector;

    [SerializeField, Header("コインカウントの上限")]
    int _coinCountMax = 20;

    int _coinCount = 0; //コインカウントの初期値
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ScoreObject":
                _coinCount++;
                Debug.Log(_coinCount);
                if (_coinCount == _coinCountMax)
                {
                    _sceneDirector.GetTime();
                    _coinCount = 0;
                }
                break;
        }
    }
}
