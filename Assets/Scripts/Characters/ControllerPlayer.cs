using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
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
    }

}
