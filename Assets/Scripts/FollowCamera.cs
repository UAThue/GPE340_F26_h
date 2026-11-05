using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetWorld;
    public float rotateSpeed;
    public float moveSpeed;


    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        // Find the position we want our camera to be at
        Vector3 targetPosition = target.position;
        targetPosition += offsetWorld;

        // Move towards that position every framedraw
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
    }
}
