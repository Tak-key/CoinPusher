using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    // オーディオが再生されているかの判定
    bool isAudioStart = false;

    [SerializeField, Header("セットする音")]
    AudioSource _setAudio;

    void Start()
    {
        // 再生と合わせて、isAudioStartをtrueにする（二重再生防止）
        _setAudio.Play();
        isAudioStart = true;
    }

    void Update()
    {
        // オーディオの再生が終了したら、オブジェクトプールに戻す
        if (!_setAudio.isPlaying && isAudioStart)
        {
            Destroy(gameObject);
            //ObjectPool.Instance.ReturnObjectToPool(gameObject);
        }
    }
}
