using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("コインのプレハブ")]
    GameObject _coinPrefab;

    [SerializeField, Header("オブジェクトプールのデフォルトの容量")]
    int _defaultPoolSize;

    [SerializeField, Header("オブジェクトプールの最大サイズ")]
    int _maxPoolSize;

    public static ObjectPool Instance { get; private set; } 

    // オブジェクトプールのディクショナリ
    private Dictionary<string, ObjectPool<GameObject>> _itemPools = new Dictionary<string, ObjectPool<GameObject>>();

    ObjectPool<GameObject> _coinPool;

    void Start()
    {
        _coinPool = new ObjectPool<GameObject>(
            CreatePoolObj,
            TakeFromPool,
            ReturnToPool,
            DestroyPool,
            false,
            _defaultPoolSize,
            _maxPoolSize);
    }

    private void Awake()
    {
        Instance = this;
    }

    GameObject CreatePoolObj()
    {
        GameObject _pooledCoin = Instantiate(_coinPrefab, transform);
        return _pooledCoin;
    }

    void TakeFromPool(GameObject _coin)
    {
        _coin.SetActive(true);
    }

    void ReturnToPool(GameObject _coin)
    {
        _coin.SetActive(false);
    }

    void DestroyPool(GameObject _coin)
    {
        Destroy(_coin);
    }

    public GameObject GetCoin()
    {
        GameObject _pooledCoin = _coinPool.Get();
        return _pooledCoin;

    }

    public void DelCoin(GameObject _pooledCoin)
    {
        _coinPool.Release(_pooledCoin);
    }
}
