using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class ControllerAI : Controller
{
    [Header("Navigation Data")]
    [HideInInspector] public NavMeshAgent agent;
    public Transform targetTransform;
    public float stoppingDistance = 1.0f;
    public float shootingDistance = 5.0f;
    private Vector3 desiredVelocity = Vector3.zero;
    public List<Weapon> startingWeapons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pawn != null)
        {
            Possess(pawn);
        }

        EquipStartingWeapon();
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

        // if this object has a target
        if (this.HasTarget())
        {
            // If the target is in range
            float distanceToTarget = Vector3.Distance(targetTransform.position, pawn.transform.position);
            if (distanceToTarget < shootingDistance)
            {
                // Stop moving
                agent.isStopped = true;

                // Keep rotating to look at the player / aim
                pawn.RotateToLookAt(targetTransform.position);

                // And shoot
                pawn.weapon.PullTrigger();
            }
            else
            {
                // Otherwise 
                // Stop shooting
                pawn.weapon.ReleaseTrigger();

                // Seek out the target's position
                // Stop moving
                agent.isStopped = false;
                Seek(targetTransform.position);               
            }

        } else
        {
            TargetPlayer();
        }
    }

    public void EquipStartingWeapon()
    {
        if (startingWeapons.Count > 0)
        {
            Weapon randomWeapon = startingWeapons[Random.Range(0, startingWeapons.Count)];
            pawn.EquipWeapon(randomWeapon);
        }
    }

    public void TargetPlayer()
    {
        // Find the player
        ControllerPlayer playerController;
        playerController = FindAnyObjectByType<ControllerPlayer>();

        // Target that player
        targetTransform = playerController.pawn.transform;
    }

    public bool HasTarget()
    {
        if (targetTransform != null)
        {
            return true;
        }
        else
        {
            return false;
        }
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
