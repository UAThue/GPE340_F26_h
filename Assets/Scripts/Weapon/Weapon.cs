using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public float damageDone = 1;
    public float shotsPerSecond = 2;
    public List<Attack> attacks;
    public Transform RHPoint;
    public Transform LHPoint;
    public Transform RHHint;
    public Transform LHHint;
    [Tooltip("How accurate the weapon is. 1 is perfect. 0 is worst possible.")]
    public float accuracy;
    [Tooltip("The worst possible inaccurate shot is this many degrees off target.")]
    public float maxAccuracyRotation;

    public void PullTrigger(int attackNumber = 0)
    {
        if (attackNumber < attacks.Count)
        {
            // Tell the event to run all the subscriber functions
            attacks[attackNumber].OnAttackStart.Invoke();
        }
    }

    public void ReleaseTrigger(int attackNumber = 0)
    {
        if (attackNumber < attacks.Count)
        {
            // Tell the event to run all the subscriber functions
            attacks[attackNumber].OnAttackEnd.Invoke();
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual float GetAccuracyRotationDegrees()
    {
        // Find out what percentage of our maxAccuracyRotation to miss by
        float accuracyDeltaPercentage = Random.Range(0, 1-accuracy);

        float accuracyDeltaDegrees = Mathf.Lerp(-maxAccuracyRotation, maxAccuracyRotation, accuracyDeltaPercentage);
        Debug.Log("We miss by " + accuracyDeltaDegrees + "degrees");

        return accuracyDeltaDegrees;

    }


    [System.Serializable]
    public struct Attack
    {
        public UnityEvent OnAttackStart;
        public UnityEvent OnAttackEnd;
    }
}
