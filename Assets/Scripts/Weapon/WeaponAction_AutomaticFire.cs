using UnityEngine;
using UnityEngine.Events;

public class WeaponAction_AutomaticFire : MonoBehaviour
{
    private bool isShooting;
    public UnityEvent OnShoot;
    public float shotsPerSecond = 2;
    private float nextShootTime;

    public void Start()
    {
        // Set it up so we can shoot right at the start
        nextShootTime = Time.time;
        
    }

    public void Update()
    {
        // Are we allowed to shoot? (Is it time?)
        if (Time.time > nextShootTime)
        {
            // Are we shooting?
            if (isShooting)
            {
                // Actually Shoot
                OnShoot.Invoke();

                // Save our next time that we are allowed to shoot
                // Change shots per second to seconds per shot
                float secondsPerShot = 1 / shotsPerSecond;
                // Next shot time is that many seconds from now
                nextShootTime = Time.time + secondsPerShot;
            }
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
