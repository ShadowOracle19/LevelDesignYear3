using cowsins;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyTargets = new List<GameObject>();
    public List<GameObject> civiTargets = new List<GameObject>();
    public float currentTime = 0;

    public TextMeshProUGUI enemyTargetsText;
    public TextMeshProUGUI civiTargetsText;

    public Transform enemyParent;
    public Transform civiParent;

    public int enemyTargetsShot = 0;
    public int civiTargetsShot = 0;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Game Manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform target in enemyParent)
        {
            enemyTargets.Add(target.gameObject);
        }
        foreach (Transform target in civiParent)
        {
            civiTargets.Add(target.gameObject);
        }

        enemyTargetsText.text = $"0/{enemyTargets.Count}";
        civiTargetsText.text = $"0/{civiTargets.Count}";
    }

    // Update is called once per frame
    void Update()
    {
        enemyTargetsText.text = $"{enemyTargetsShot}/{enemyTargets.Count}";
        civiTargetsText.text = $"{civiTargetsShot}/{civiTargets.Count}";
    }

    public void ResetTrainingCourse()
    {
        foreach(GameObject target in enemyTargets)
        {
            target.GetComponentInChildren<TrainingTarget>().Revive();
        }
        foreach (GameObject target in civiTargets)
        {
            target.GetComponentInChildren<TrainingTarget>().Revive();
        }

        enemyTargetsShot = 0;
        civiTargetsShot = 0;
    }
}
