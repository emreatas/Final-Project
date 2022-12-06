using UnityEngine;
using UnityEngine.AI;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public Transform player;
    public int[] enemySize;

    private float spawnRadius = 10f;
    private float spawnDistance = 10f;
    private bool[] isEnemySpawned = new bool[3];
    void Start() {
        for(int i = 0; i < spawnPoints.Length; i++) {
            isEnemySpawned[i] = false;
        }
    }
    void Update() {
        for(int j = 0; j < enemies.Length; j++) {
            if(Vector3.Distance(player.position , spawnPoints[j].position) < spawnDistance && !isEnemySpawned[j]) {
                isEnemySpawned[j] = true;
                Vector3 point;
                for(int i = 0; i < enemySize[j]; i++) {
                    while(!CreateRandomPoints(j , out point)) {
                    }
                    Instantiate(enemies[j] , point , transform.rotation).transform.SetParent(spawnPoints[j]);
                }
            }
        }
    }
    public bool CreateRandomPoints(int enemyType , out Vector3 result) {
        Vector3 randomPoint = spawnPoints[enemyType].position + Random.insideUnitSphere * spawnRadius;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint , out hit , 1.0f , NavMesh.AllAreas)) {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
