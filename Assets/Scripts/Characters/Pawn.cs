using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    public float moveSpeed;
    public float rotationSpeed;
    public Weapon weapon;

    public abstract void Move(Vector3 moveVector);
    public abstract void Rotate(float direction);
    public virtual void RotateToLookAt(Vector3 targetPoint)
    {
        // Rotate towards that point
        // Find the vector from pawn to point
        Vector3 vectorToTargetPoint = targetPoint - transform.position;
        // Find the rotation that looks down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTargetPoint, Vector3.up);
        // Move a little towards that rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
    }
}
