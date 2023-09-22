using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingCourseEndTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        TimeManager.Instance.StopTimer();
        gameObject.SetActive(false);
    }
}
