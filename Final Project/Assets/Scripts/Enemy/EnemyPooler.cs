using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            for(int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab , pool.spawnPoint.position , transform.rotation);
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
    private void FixedUpdate() {

    }
    public GameObject SpawnFromPool(string tag , Quaternion rotation,Pool pool) {
        Vector3 point;
        while(CreateRandomPoints(out point,pool)) {
        }
        GameObject objectToSpawn = poolDict[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = point;
        objectToSpawn.transform.rotation = rotation;
        poolDict[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    public bool CreateRandomPoints(out Vector3 result , Pool pool) {
        Vector3 randomPoint = pool.spawnPoint.position + Random.insideUnitSphere * pool.spawnRadius;
        UnityEngine.AI.NavMeshHit hit;
        if(UnityEngine.AI.NavMesh.SamplePosition(randomPoint , out hit , 1.0f , UnityEngine.AI.NavMesh.AllAreas)) {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
