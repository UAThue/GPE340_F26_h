using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("Gizmo Data")]
    public float gizmoHeight;
    public float gizmoWidth;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        Color boxColor = Color.red;
        boxColor.a = 0.5f;
        Gizmos.color = boxColor;


        Vector3 boxPosition = transform.position;
        boxPosition += Vector3.up * (0.5f * gizmoHeight);

        Vector3 boxSize = new Vector3(gizmoWidth, gizmoHeight, gizmoWidth);
        Gizmos.DrawCube(boxPosition, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(boxPosition, transform.forward);
      
    }
}
