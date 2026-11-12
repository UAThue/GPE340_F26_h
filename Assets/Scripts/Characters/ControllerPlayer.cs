using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
    public Camera viewCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move based on controller input
        MakeDecisions();
    }

    protected virtual void MakeDecisions()
    {
        // Get our 2D axis action named "Move"
        InputAction moveAction = InputSystem.actions.FindAction("Move");
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();

        // Make sure my value doesn't go beyond what thumbstick can do! ( no 1,1! )
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1);

        // Conver the thumbstick direction - so that UP on the stick is whatever local direction we need to move to go "North" in the world
        Vector3 moveDirection3 = new Vector3(moveDirection.x, 0, moveDirection.y);
        moveDirection3 = pawn.transform.InverseTransformDirection(moveDirection3);

        // Send the value into our Move as a 3D vector!
        pawn.Move(moveDirection3);

        // Rotate Camera
        RotateCamera();

        //Handle shooting
        InputAction attackAction = InputSystem.actions.FindAction("Attack1");
        InputAction secondaryAttackAction = InputSystem.actions.FindAction("Attack2");
        if (attackAction.WasPressedThisFrame())
        {
            pawn.weapon.PullTrigger(0);
        }

        if (secondaryAttackAction.WasPressedThisFrame())
        {
            pawn.weapon.PullTrigger(1);
        }
        if (attackAction.WasReleasedThisFrame())
        {
            pawn.weapon.ReleaseTrigger(0);
        }

        if (secondaryAttackAction.WasReleasedThisFrame())
        {
            pawn.weapon.ReleaseTrigger(1);
        }


    }

    protected virtual void RotateCamera()
    {
        // Create an object for our floor plane
        Plane thePlane = new Plane(Vector3.up, pawn.transform.position);

        // Create an object for our camera mouse ray
        Ray theRay = new Ray();

        // Get our mouse position
        InputAction mousePositionAction = InputSystem.actions.FindAction("MousePosition");
        Vector2 mousePosition = mousePositionAction.ReadValue<Vector2>();
        theRay = viewCamera.ScreenPointToRay(mousePosition);

        // Find the intersection between the Ray and the Plane
        float distanceToIntersection; // Variable to hold distance down the ray that we collide
        Vector3 hitPoint; // Variable to hold the point where we collide

        // If the ray collides with the plane
        if (thePlane.Raycast(theRay, out distanceToIntersection))
        {
            // Save the point down the ray
            hitPoint = theRay.GetPoint(distanceToIntersection);

            // Rotte towards that point
            pawn.RotateToLookAt(hitPoint);            
        }


    }

}
