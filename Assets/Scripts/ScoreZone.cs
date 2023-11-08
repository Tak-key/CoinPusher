using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField, Header("�V�[���f�B���N�^�[")]
    SceneDirector _sceneDirector;

    [SerializeField, Header("�R�C���J�E���g�̏��")]
    int _coinCountMax = 20;

    int _coinCount = 0; //�R�C���J�E���g�̏����l
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
