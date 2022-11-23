using System.Collections;
using System.Collections.Generic;
using MEC;
using ObjectPooling;
using Player;
using UnityEngine;
using UnityEngine.Rendering;

public class AbstractNewSkill : ObjectPoolBehaviour<AbstractNewSkill>
{
    [SerializeField] protected float lifeTime;

    private CoroutineHandle m_DestroyCoroutine;
    
    protected PlayerSkillController m_PlayerSkillController;
    
    protected virtual void Start()
    {
        m_DestroyCoroutine = Timing.RunCoroutine(ReleaseCO());
    }
        
    private void OnDestroy()
    {
        Timing.KillCoroutines(m_DestroyCoroutine);
    }

    public void InitSkill(PlayerSkillController skillController)
    {
        m_PlayerSkillController = skillController;
    }
    
    protected virtual IEnumerator<float> ReleaseCO()
    {
        yield return Timing.WaitForSeconds(lifeTime);
        
        Release();
    }
}
