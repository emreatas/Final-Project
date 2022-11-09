using Skills;
using UnityEngine;

public class PrimarySkillProjectile : AbstractProjectile
{
   [SerializeField] private float attackSpeedMultiplicator;
   
   public override void FireProjectile(Vector3 dir)
   {
      rb.velocity = dir.normalized * m_AttackSpeed * attackSpeedMultiplicator;
   }

   private void OnTriggerEnter(Collider other)
   {
      IHealth enemy = other.GetComponent<IHealth>();
      if (enemy != null)
      {
         enemy.TakeDamage(m_Damage);
         Destroy(gameObject);
      }
   }
}
