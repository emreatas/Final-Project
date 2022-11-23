using System.Collections;
using System.Collections.Generic;
using MEC;
using ObjectPooling;
using Player;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class AbstractNewSkill : ObjectPoolBehaviour<AbstractNewSkill>
{
    [SerializeField] protected float lifeTime;

    private CoroutineHandle m_DestroyCoroutine;
    
    protected PlayerSkillController m_PlayerSkillController;
    
    private void OnEnable()
    {
        m_DestroyCoroutine = Timing.RunCoroutine(ReleaseCO());
    }
        
    private void OnDisable()
    {
        Timing.KillCoroutines(m_DestroyCoroutine);
    }

    public void InitSkill(PlayerSkillController skillController)
    {
        m_PlayerSkillController = skillController;
        OnInitialized();
    }
    
    private IEnumerator<float> ReleaseCO()
    {
        yield return Timing.WaitForSeconds(lifeTime);
        ReleaseSkill();
    }

    protected void ReleaseSkill()
    {
        OnReleaseObject();
        Release();
    }
    
    protected abstract void OnInitialized();
    protected abstract void OnReleaseObject();

}
