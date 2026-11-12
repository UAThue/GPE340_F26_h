using UnityEngine;
using UnityEngine.Events;

public class WeaponAction_LimitFireRate : WeaponAction
{
    public float shotsPerSeconds;
    private float nextShootTime;

    public UnityEvent OnShoot;
    public UnityEvent OnFailShoot;

    public void Start()
    {
        nextShootTime = Time.time;
    }

    public void TryShoot()
    {
        // Are we allowed to shoot? (Is it time?)
        if (Time.time > nextShootTime)
        {
            OnShoot.Invoke();

            // Save our next time that we are allowed to shoot
            // Change shots per second to seconds per shot
            float secondsPerShot = 1 / weapon.shotsPerSecond;
            // Next shot time is that many seconds from now
            nextShootTime = Time.time + secondsPerShot;
        }
        else
        {
            OnFailShoot.Invoke();
        }
    }
}