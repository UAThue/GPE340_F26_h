using UnityEngine;

[RequireComponent (typeof(Weapon))]
public abstract class WeaponAction : MonoBehaviour
{
    [HideInInspector] public Weapon weapon;
    public virtual void Awake()
    {
        // Get the weapon component
        weapon = GetComponent<Weapon>();
    }
}
