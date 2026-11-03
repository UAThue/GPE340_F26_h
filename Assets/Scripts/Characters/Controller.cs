using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    public virtual void Possess(Pawn pawnToPossess)
    {
        // Set our pawn
        pawn = pawnToPossess;
        // Set that pawn to own this controller, too
        pawn.controller = this;
    }

    public virtual void UnPosess()
    {
        // Remove the links
        pawn.controller = null;
        pawn = null;
    }
}
