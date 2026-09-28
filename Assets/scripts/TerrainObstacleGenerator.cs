using UnityEngine;
using UnityEngine.AI;

public class TerrainObstacleSpawner : MonoBehaviour
{
    void Start()
    {
        Terrain terrain = Terrain.activeTerrain;
        if (terrain == null) return;

        TerrainData data = terrain.terrainData;

        foreach (TreeInstance tree in data.treeInstances)
        {
          
            Vector3 treePosition = Vector3.Scale(tree.position, data.size) + terrain.transform.position + new Vector3(2.5f, 0, 0);

           
            GameObject obstacleNode = new GameObject("Tree_Obstacle_Node");
            obstacleNode.transform.position = treePosition;
            obstacleNode.transform.parent = this.transform;

          
            NavMeshObstacle obstacle = obstacleNode.AddComponent<NavMeshObstacle>();
            obstacle.shape = NavMeshObstacleShape.Capsule;
            obstacle.carving = true; 

          
            obstacle.radius = 4f;
            obstacle.height = 3.0f;
        }
    }
}