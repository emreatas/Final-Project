using UnityEngine;

public class DamageController : MonoBehaviour
{
    public EnemyScriptable enemyStats;
    private void OnTriggerEnter(Collider handCollider) {
        IHealth player = handCollider.GetComponent<IHealth>();
        if(player != null) {
            player.TakeDamage(enemyStats.damage,null);
        }
    }
}
