using Skills;
using Stat;
using UnityEngine;

public class PrimarySkillProjectile : AbstractProjectile
{
   [SerializeField] private float attackSpeedMultiplicator;
   [SerializeField] private float damageMultiplicator;
   
   [SerializeField] private StatType damageType;
   [SerializeField] private StatType attackSpeedType;

   private float m_AttackSpeed;
   private float m_Damage;
   
   protected override void SetStatValues()
   {
      m_AttackSpeed = m_CharacterStat.GetValue(attackSpeedType) * attackSpeedMultiplicator;
      Debug.Log("ATtack Speed" + m_AttackSpeed);
      m_Damage = m_CharacterStat.GetValue(damageType) * damageMultiplicator;
   }

   public override void FireProjectile(Vector3 dir)
   {
      Debug.Log("ATtack Speed " + m_AttackSpeed);
      rb.velocity = dir.normalized * m_AttackSpeed;
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
