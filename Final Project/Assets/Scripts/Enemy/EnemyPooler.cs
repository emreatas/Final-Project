using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPooler : MonoBehaviour
{
    public Transform player;
    public Transform mainCam;

    [System.Serializable]
    public class Pool
    {
        public Transform spawnPoint;
        public string tag;
        public GameObject prefab;
        public int size;
        public float spawnRadius;
        public int isAllEnemyDisabled;
    }
    #region Singleton
    public static EnemyPooler Instance;
    public List<Pool> pools;
    public Dictionary<string , Queue<GameObject>> poolDict;
    private void Awake() {
        Instance = this;
    }
    #endregion
    void Start() {
        poolDict = new Dictionary<string , Queue<GameObject>>();
        foreach(Pool pool in pools) {
            Debug.Log("Enemy Spawn Points: " + pool.spawnPoint);
            pool.isAllEnemyDisabled = pool.size;
            Queue<GameObject> objectPool = new Queue<GameObject>();
            Vector3 point;
            for(int i = 0; i < pool.size; i++) {
                while(CreateRandomPoints(out point , pool)) {
                }
                GameObject obj = Instantiate(pool.prefab , point , transform.rotation);
                obj.GetComponent<Enemy.EnemyStateManager>().setPlayerTransform(player);
                obj.GetComponent<Enemy.EnemyStateManager>().setBilboardCamera(mainCam);
                obj.SetActive(false);
                pool.isAllEnemyDisabled -= 1;
                Debug.Log("isAllEnemyDisabled: " + pool.isAllEnemyDisabled);
                objectPool.Enqueue(obj);
            }
            poolDict.Add(pool.tag , objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag) {
        GameObject objectToSpawn = poolDict[tag].Dequeue();
        objectToSpawn.SetActive(true);
        poolDict[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    public bool CreateRandomPoints(out Vector3 result , Pool pool) {
        Vector3 randomPoint = pool.spawnPoint.position + Random.insideUnitSphere * pool.spawnRadius;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint , out hit , 1.0f , NavMesh.AllAreas)) {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    public Pool getPool(string tag) {
        if(tag == "SkeletonEnemy") {
            return pools[0];
        }
        else if(tag == "GiantEnemy") {
            return pools[1];
        }
        else {
            return null;
        }
    }
}
