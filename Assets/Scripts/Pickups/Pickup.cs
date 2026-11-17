using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class Pickup : MonoBehaviour
{
    public UnityEvent OnPickup;

    public virtual void Awake () 
    { 
        // Make sure this collider is a trigger
        Collider myCollider = GetComponent<Collider>();
        if (myCollider != null)
        {
            myCollider.isTrigger = true;
        } 
        else
        {
            Debug.LogError(gameObject.name + " does not have a collider.");
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Call the designer-added functions for a pickup
        OnPickup.Invoke();
    }

}
