using UnityEngine;

public class PickupWeapon : Pickup
{
    public Weapon weaponToPickup;

    public override void Awake()
    {
        // Do anything special that a weapon pickup needs here

        // Do the base awake
        base.Awake();
    }

    public override void OnTriggerEnter( Collider other )
    {
        if (weaponToPickup != null)
        {
            // Check if the object that entered the trigger has a pawn component
            Pawn otherPawn = other.gameObject.GetComponent<Pawn>();
            if (otherPawn != null)
            {
                // If so, then call the equip function on that pawn
                otherPawn.EquipWeapon(weaponToPickup);

                // Do the base on Trigger Enter (call to the Unity Event)
                base.OnTriggerEnter(other);

                // Destroy this game object
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogError(gameObject.name + " does not have a weapon to pickup set.");
        }
    }


}
