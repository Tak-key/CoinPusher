using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField, Header("����炷�I�u�W�F�N�g")]
    GameObject _audioObject;

    [Header("���_")]
    public int _scorePoint;
    private void Start()
    {
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            gameObject.tag = "ScoreObject";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ScoreZone":
                Instantiate(_audioObject, transform.position, Quaternion.identity);
                ObjectPool.Instance.DelCoin(gameObject);
                SceneManager.GetScore(_scorePoint);
                break;

            case "DropZone":
                ObjectPool.Instance.DelCoin(gameObject);
                break;
        }
    }
}
