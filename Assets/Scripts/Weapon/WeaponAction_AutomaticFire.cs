using UnityEngine;
using UnityEngine.Events;

public class WeaponAction_AutomaticFire : WeaponAction
{
    private bool isShooting;
    public UnityEvent OnShoot;

    public void Update()
    {
        // Are we shooting?
        if (isShooting)
        {
            // Actually Shoot
            OnShoot.Invoke();
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting =false;
    }

}
