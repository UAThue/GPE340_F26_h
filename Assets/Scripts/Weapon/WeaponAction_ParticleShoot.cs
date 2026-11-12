using UnityEngine;
using UnityEngine.Events;

public class WeaponAction_ParticleShoot : WeaponAction
{
    public GameObject bulletPrefab;
    public float shootForce;
    public float bulletMaxLifespan = 3;
    public Transform firePoint;
    public UnityEvent OnShoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        // Instantiate a bullet
        GameObject bulletObject = Instantiate<GameObject>(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add its damage done data
        Projectile bulletData = bulletObject.GetComponent<Projectile>();
        if ( bulletData != null )
        {
            bulletData.damageDone = weapon.damageDone;
        }

        // Add force for it go forward
        Rigidbody bulletPhysics = bulletObject.GetComponent<Rigidbody>();
        if (bulletPhysics != null)
        {
            bulletPhysics.useGravity = false;
            bulletPhysics.AddForce(firePoint.forward * shootForce);
        }

        // Destroy it after a given time
        Destroy(bulletObject, bulletMaxLifespan);

        // Do whatever the designers have added
        OnShoot.Invoke();
    }
}
