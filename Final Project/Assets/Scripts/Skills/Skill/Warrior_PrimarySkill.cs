using System;
using System.Collections;
using System.Collections.Generic;
using Skills;
using MEC;
using UnityEngine;

public class Warrior_PrimarySkill : AbstractSkill
{
    [SerializeField] private List<ParticleDelay> _particleDelays;
    protected override void SetStats()
    {
        
    }
    
    public override void FireProjectile(Vector3 dir, Transform target)
    {
        for (int i = 0; i < _particleDelays.Count; i++)
        {
            Timing.RunCoroutine(PlayParticleCO(_particleDelays[i]));
        }
    }

    IEnumerator<float> PlayParticleCO(ParticleDelay particleDelay)
    {
        yield return Timing.WaitForSeconds(particleDelay.startDelay);
        particleDelay.particle.Play();
    }
}

[Serializable]
public class ParticleDelay
{
    public ParticleSystem particle;
    public float startDelay;
}
