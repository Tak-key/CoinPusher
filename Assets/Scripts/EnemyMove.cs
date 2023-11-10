using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("NavMeshAgent")]
    NavMeshAgent _agent;

    [SerializeField, Header("目標地点")]
    Transform targetPos;

    [SerializeField, Header("オーディオソース")]
    AudioSource _audioSource;

    private string targetTag = "ScoreObject";

    private float count;
    void Start()
    {
        DecideTargetPos();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = targetPos.position;

        if (transform.position.x == targetPos.position.x)
        {
            count += Time.deltaTime;
        }

        if(count >= 5)
        {   
            DecideTargetPos();
            count = 0;
        }
    }

    void DecideTargetPos()
    {
        Debug.Log("入った");
        Transform target = SearchNearObject(targetTag);

        if (target != null)
        {
            targetPos.position = target.position;
        }
        else
        {
            Debug.Log("ターゲットなし");
            return;
        }

        //targetPos.position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-3f, -3.75f));


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreObject"))
        {
            Debug.Log("触ってる");
            _audioSource.Play();
            ObjectPool.Instance.DelCoin(other.gameObject);
        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("ScoreObject"))
    //    {
    //        Debug.Log("触ってる");
    //        _audioSource.Play();
    //        ObjectPool.Instance.DelCoin(col.gameObject);
    //    }
    //}

    Transform SearchNearObject(string targetTag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        if (targets.Length == 1)
        {
            return targets[0].transform;
        }

        GameObject resultTarget = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach(GameObject target in targets)
        {
            if (target.transform.position.y > 0)
            {
                continue;
            }

            Vector3 distanceDiff = target.transform.position - transform.position;
            float currectDistance = distanceDiff.sqrMagnitude;
            if (currectDistance < distance)
            {
                resultTarget = target;
                distance = currectDistance;
            }
        }

        if (resultTarget == null)
        {
            return null;
        }
        else
        {
            return resultTarget.transform;
        }
    }
}
