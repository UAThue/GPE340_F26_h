using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PawnHumanoid : Pawn
{
    private Animator anim;


    public override void Move(Vector3 moveVector)
    {
        // Pass the values into the animator
        anim.SetFloat("Right", moveVector.x * moveSpeed);
        anim.SetFloat("Forward", moveVector.z * moveSpeed);
    }

    public override void Rotate(float direction)
    {
        // Rotate our character
        transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get our animator
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimatorMove()
    {
        // After the animation runs
        // Use root motion to move the game object
        transform.position = anim.rootPosition;
        transform.rotation = anim.rootRotation;

        // If we have a NavMeshAgent on our controller,
        ControllerAI aiController = controller as ControllerAI;
        if (aiController != null)
        {
            // Set our navMeshAgent to understand it is as the position from the animator
            aiController.agent.nextPosition = anim.rootPosition;               
        }
    }

}
