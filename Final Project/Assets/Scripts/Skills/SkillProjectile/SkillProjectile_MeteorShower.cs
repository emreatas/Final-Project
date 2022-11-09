using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class SkillProjectile_MeteorShower : AbstractProjectile
    {
        [SerializeField] private float attackSpeedMultiplicator;
        public override void FireProjectile()
        {
            rb.velocity = Vector3.down * m_AttackSpeed * attackSpeedMultiplicator;
        }

        private void OnTriggerEnter(Collider other)
        {
            IHealth enemy = other.GetComponent<IHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(m_Damage);
            }
            Destroy(gameObject);
        }
    }

}
