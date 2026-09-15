using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform path;
    [SerializeField] List<Transform> pathPoints = new List<Transform>();
    [SerializeField] int currentIndex = 0;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        for (int i = 0; i < path.childCount; i++)
        {
            pathPoints.Add(path.GetChild(i).transform);
        }

    }
    void Update()
    {
        if (currentIndex < pathPoints.Count)
        {
            agent.SetDestination(pathPoints[currentIndex].position);

            if (Vector3.Distance(transform.position, pathPoints[currentIndex].position) < 20)
            {
                currentIndex++;
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
