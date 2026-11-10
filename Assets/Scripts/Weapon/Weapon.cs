using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;


    public void PullTrigger()
    {
        // Tell the event to run all the subscriber functions
        OnTriggerPull.Invoke();
    }

    public void ReleaseTrigger()
    {
        // Tell the event to run all the subscriber functions
        OnTriggerRelease.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
