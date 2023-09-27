using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingCourseTrigger : MonoBehaviour
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
        if(other.gameObject.tag == "Player")
        {
            TimeManager.Instance.StartTimer();
            GameManager.Instance.ResetTrainingCourse();
            gameObject.SetActive(false);
        }
    }
}
