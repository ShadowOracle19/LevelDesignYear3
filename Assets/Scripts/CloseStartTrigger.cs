using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseStartTrigger : MonoBehaviour
{
    public GameObject trigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            trigger.SetActive(true);
        }
    }
}
