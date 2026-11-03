using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    public float moveSpeed;
    public float rotationSpeed;

    public abstract void Move(Vector3 moveVector);
    public abstract void Rotate(float direction);

}
