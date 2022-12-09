using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyPooler objectPooler;
    public float spawnDistance;
    private void Start() {
        objectPooler = EnemyPooler.Instance;
    }
    void FixedUpdate() {
        for(int j = 0; j < objectPooler.pools.Count; j++) {
            if(Vector3.Distance(objectPooler.player.position , objectPooler.pools[j].spawnPoint.position) < spawnDistance && objectPooler.pools[j].isAllEnemyDisabled == 0) {
                for(int i = 0; i < objectPooler.pools[j].size; i++) {
                    objectPooler.SpawnFromPool(objectPooler.pools[j].tag);
                    objectPooler.pools[j].isAllEnemyDisabled += 1;
                }
            }
        }
    }

}
