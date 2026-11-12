using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public float damageDone = 1;
    public float shotsPerSecond = 2;
    public List<Attack> attacks;

    public void PullTrigger(int attackNumber = 0 )
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


    [System.Serializable]
    public struct Attack
    {
        public UnityEvent OnAttackStart;
        public UnityEvent OnAttackEnd;
    }
}
