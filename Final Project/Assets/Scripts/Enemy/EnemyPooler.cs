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
            pool.isAllEnemyDisabled = pool.size;
            Queue<GameObject> objectPool = new Queue<GameObject>();
            Vector3 point;
            for(int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                while(CreateRandomPoints(out point , pool)) {
                }
                obj.GetComponent<Enemy.EnemyStateManager>().setPlayerTransform(player);
                obj.GetComponent<Enemy.EnemyStateManager>().setBilboardCamera(mainCam);
                obj.transform.position = point;
                obj.transform.rotation = transform.rotation;
                obj.SetActive(false);
                pool.isAllEnemyDisabled -= 1;
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
            return false;
        }
        result = Vector3.zero;
        return true;
    }
    public void IsEnemyDisabled(string tag) {
        for(int i = 0; i < pools.Count; i++) {
            if(pools[i].tag == tag) {
                pools[i].isAllEnemyDisabled -= 1;
            }
        }
    }
}
