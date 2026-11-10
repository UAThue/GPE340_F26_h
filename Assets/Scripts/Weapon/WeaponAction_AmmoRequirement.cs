using UnityEngine;
using UnityEngine.Events;

public class WeaponAction_AmmoRequirement : MonoBehaviour
{
    public int currentAmmo;
    public int maxAmmo;
    public UnityEvent OnShoot;
    public UnityEvent OnOutOfAmmo;


    public void Reload()
    {
        currentAmmo = maxAmmo;
    }
     
    public void TryShoot()
    {
        if ( currentAmmo > 0)
        {
            currentAmmo--;
            OnShoot.Invoke();
        }
        else
        {
            OnOutOfAmmo.Invoke();
        }
    }

}
