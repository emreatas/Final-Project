using System.Collections;
using System.Collections.Generic;
using MEC;
using Player;
using UnityEngine;

public class AbstractNewSkill : MonoBehaviour
{
    [SerializeField] protected float lifeTime;

    private CoroutineHandle m_DestroyCoroutine;

    protected PlayerSkillController m_PlayerSkillController;
    
    protected virtual void Start()
    {
        m_DestroyCoroutine = Timing.RunCoroutine(_Destroy());
    }
        
    private void OnDestroy()
    {
        Timing.KillCoroutines(m_DestroyCoroutine);
    }

    public void InitSkill(PlayerSkillController skillController)
    {
        m_PlayerSkillController = skillController;
    }
    
    protected virtual IEnumerator<float> _Destroy()
    {
        yield return Timing.WaitForSeconds(lifeTime);
        
        Destroy(gameObject);
    }
    
    
}
