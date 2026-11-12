using UnityEngine;

[RequireComponent (typeof(Rigidbody)), RequireComponent (typeof(Collider))]
public class Projectile : MonoBehaviour
{
    public float damageDone;

    public void Start()
    {
        // Set our collider to be a trigger
        Collider collider = GetComponent<Collider> ();
        collider.isTrigger = true;
    }

    public void OnTriggerEnter( Collider other)
    {
        // Get the object we hit
        Debug.Log(gameObject.name + " hit " + other.gameObject.name);

        // If it has a health component
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null)
        {
            // Do Damage
            otherHealth.TakeDamage(damageDone);
        }

        // Destroy our projectile on Hit
        Destroy(gameObject);
    }
}
