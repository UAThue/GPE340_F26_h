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


}
