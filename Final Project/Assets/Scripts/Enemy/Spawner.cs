using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }
    void FixedUpdate() {
        ObjectPooler.Instance.SpawnFromPool("SkeletonEnemy" , transform.position , Quaternion.identity);
    }
}
