using UnityEngine;

public class DamageController : MonoBehaviour
{
    public EnemyScriptable enemyStats;
    private void OnTriggerEnter(Collider other) {
        IHealth player = other.GetComponent<IHealth>();
        if(player != null) {
            player.TakeDamage(enemyStats.damage);
            Debug.Log("Damage Taken!");
        }
    }
}
