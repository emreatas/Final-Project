using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public Transform player;
    public int[] enemySize;

    private float spawnRadius = 3f;
    private float spawnDistance = 3f;
    private bool[] isEnemySpawned = new bool[3];
    void Start()
    {
        for(int i = 0; i < spawnPoints.Length; i++) {
            isEnemySpawned[i] = false;
        }
    }
    void Update()
    {
        if(Vector3.Distance(player.position, spawnPoints[0].position) < spawnDistance && !isEnemySpawned[0]) {
            isEnemySpawned[0] = true;
            Vector3 point;
            for(int i = 0; i < enemySize[0]; i++) {
                while(!CreateRandomPoints(0 , out point)) {
                }
                Instantiate(enemies[0] , point , transform.rotation).transform.SetParent(spawnPoints[0]);
            }
        }
    }
    public bool CreateRandomPoints(int enemyType, out Vector3 result) {
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
