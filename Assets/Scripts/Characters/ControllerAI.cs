using UnityEngine;
using UnityEngine.AI;

public class ControllerAI : Controller
{
    [Header("Navigation Data")]
    [HideInInspector] public NavMeshAgent agent;
    public Transform targetTransform;
    public float stoppingDistance = 1.0f;
    private Vector3 desiredVelocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pawn != null)
        {
            Possess(pawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MakeDecisions();
    }

    public void MakeDecisions()
    {
        // If we don't have a pawn, we can't make decisions for it, so do nothing
        if (pawn == null)
        {
            return;
        }

        // Seek out the target's position
        Seek(targetTransform.position);        
    }

    public void Seek( Vector3 targetPoint )
    {
        // Set our NavMeshAgent to seek our target
        agent.SetDestination(targetPoint);

        // Find the velocity that the agent wants to move in order to follow the path (IN WORLD direction!)
        desiredVelocity = agent.desiredVelocity;

        // Send the direction in to our Move function (use the move function to add speed / move is in local directions!)
        desiredVelocity = pawn.transform.InverseTransformDirection(desiredVelocity);
        desiredVelocity = desiredVelocity.normalized;
        pawn.Move(desiredVelocity);

        // Look towards the player
        pawn.RotateToLookAt(targetPoint);
    }


    public override void Possess(Pawn pawnToPossess)
    {
        // Take control of the pawn, just like any other controller/pawn
        base.Possess(pawnToPossess);

        // Make sure that the pawn has a NavMeshAgent (So the AI can control it!)
        agent = pawn.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = pawn.gameObject.AddComponent<NavMeshAgent>();
        }

        // Set the stopping distance
        agent.stoppingDistance = stoppingDistance;

        // Set the max speed of the AI from the pawn data
        agent.speed = pawn.moveSpeed;

        // Set the max rotation speed of the AI from the pawn data
        agent.angularSpeed = pawn.rotationSpeed;

        // Disable movement and rotation from the NavMeshAgent
        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    public override void UnPossess()
    {
        // If we have a nav mesh agent, remove it
        agent = pawn.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            Destroy(agent);
        }
        // Unpossess like any other controller
        base.UnPossess();
        
    }

}
