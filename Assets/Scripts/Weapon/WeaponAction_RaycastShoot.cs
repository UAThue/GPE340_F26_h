using UnityEngine;

public class WeaponAction_RaycastShoot : MonoBehaviour
{
    public float damageDone;
    public Transform firePoint;
    public float fireDistance;
    public GameObject laserPrefab;
    public float laserLifespan = 0.1f;
    public float laserWidth = 0.1f;
    public Color laserColor = Color.green;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot( )
    {
        // Create a variable to hold the laser's endpoint
        Vector3 laserEndpoint = firePoint.position + (firePoint.forward * fireDistance);

        // Raycast in the direction of the firepoint for "distance" meters
        RaycastHit hit;

        Ray rayToCast = new Ray();
        rayToCast.origin = firePoint.position;
        rayToCast.direction = firePoint.forward;

        // If that raycast hits something
        if (Physics.Raycast(rayToCast, out hit, fireDistance))
        {
            // And that something has a Health component
            Health otherHealth = hit.collider.gameObject.GetComponent<Health>();

            if (otherHealth != null)
            {
                // Do Damage
                otherHealth.TakeDamage(damageDone); 
            }

            // change the endpoint of the laser based on our hit
            laserEndpoint = hit.point;
        }

        // Draw a "line" (line renderer) that matches our shot
        // Instantiate a "laser" object
        GameObject laser = Instantiate(laserPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        // Set its data to look like we need it to for this weapon
        LineRenderer laserData = laser.GetComponent<LineRenderer>();
        if (laserData != null)
        {
            laserData.SetPosition(0, firePoint.position);
            laserData.SetPosition(1, laserEndpoint);
            laserData.startColor = laserColor;
            laserData.endColor = laserColor;
            laserData.startWidth = laserWidth;
            laserData.endWidth = laserWidth;
        }

        // Tell it to self destruct after a certain time
        Destroy(laser, laserLifespan);
    }

}
