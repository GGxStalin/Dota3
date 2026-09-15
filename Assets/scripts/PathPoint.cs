using UnityEngine;

public class PathPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(2, 4, 2));
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, new Vector3(4, 2, 2));
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector3(2, 2, 4));
    }



}