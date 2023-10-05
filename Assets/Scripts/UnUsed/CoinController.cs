using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        switch (other.gameObject.tag)
        {
            case "DeadZone":
        }
        */
    }
}
