using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform path;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.darkGoldenRod;
        Gizmos.DrawSphere(transform.position, 5);
    }


}
