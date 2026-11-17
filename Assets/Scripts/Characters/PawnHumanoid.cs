using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PawnHumanoid : Pawn
{
    private Animator anim;
    public Transform weaponMountPoint;


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


    public override void EquipWeapon(Weapon weaponToEquip)
    {
        // If I already have a weapon, unequip it
        if (weapon != null)
        {
            UnequipWeapon();
        }

        // Instantiate a new copy of the weapon we are equipping
        GameObject weaponObject = Instantiate<GameObject>(weaponToEquip.gameObject);
        // Move it to the mount point and make it a child of the mount point
        weaponObject.transform.position = weaponMountPoint.transform.position;
        weaponObject.transform.rotation = weaponMountPoint.transform.rotation;
        weaponObject.transform.parent = weaponMountPoint;

        // Set our weapon variable to this new weapon
        weapon = weaponObject.GetComponent<Weapon>(); 
    }

    public override void UnequipWeapon()
    {
        if (weapon != null)
        {
            Destroy(weapon);
            weapon = null;
        }
    }


    public void OnAnimatorIK(int layerIndex)
    {
        // If we have a weapon
        if (weapon != null )
        {
            // Set the position and rotation of our hand IK to the weapon's hand points
            if (weapon.RHPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.RHPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);

                anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.RHPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            }

            if (weapon.LHPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.LHPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);

                anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.LHPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
            }

            if (weapon.RHHint != null)
            {
                anim.SetIKHintPosition(AvatarIKHint.RightElbow, weapon.RHHint.position);
                anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1.0f);
            } else
            {
                anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 0.0f);
            }

            if (weapon.LHHint != null)
            {
                anim.SetIKHintPosition(AvatarIKHint.LeftElbow, weapon.LHHint.position);
                anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1.0f);
            }
            else
            {
                anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 0.0f);
            }
        }
        else
        {
            // Tell Unity to use IK at 0% ( move our hands to wherever the animator says to put them )
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);

            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);

            anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 0.0f);
            anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 0.0f);
        }


    }

}
