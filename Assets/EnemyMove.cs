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

    string targetTag = "ScoreObject";
    void Start()
    {
        DecideTargetPos();

        SearchNearObject(targetTag);
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = targetPos.position;

        if (transform.position.x == targetPos.position.x)
        {
            DecideTargetPos();
        }
    }

    void DecideTargetPos()
    {
        Transform target = SearchNearObject(targetTag);

        if(target != null)
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ScoreObject"))
        {
            Debug.Log("触ってる");
            ObjectPool.Instance.DelCoin(col.gameObject);
        }
    }

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
            Vector3 distanceDiff = target.transform.position - transform.position;
            float currectDistance = distanceDiff.sqrMagnitude;
            if (currectDistance < distance)
            {
                resultTarget = target;
                distance = currectDistance;
            }
        }

        return resultTarget.transform;
    }
}
