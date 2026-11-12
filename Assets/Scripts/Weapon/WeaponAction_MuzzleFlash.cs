using UnityEngine;

public class WeaponAction_MuzzleFlash : MonoBehaviour
{
 
    public Transform firePoint;
    public GameObject flashPrefab;
    public float flashLifespan = 0.1f;

    public void Flash()
    {
        GameObject flashObject = Instantiate<GameObject>(flashPrefab, firePoint.position, firePoint.rotation);       
        Destroy(flashObject, flashLifespan);
    }
}
