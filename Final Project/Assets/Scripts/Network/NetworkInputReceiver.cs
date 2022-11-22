using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using Utils;

public class NetworkInputReceiver : NetworkBehaviour
{
    public GameEvent
        OnMoveStarted,
        OnMoveCanceled;
    
    public GameEvent<Vector3> OnMovePerformed;

    public GameEvent 
        OnBasicAttackStarted,
        OnBasicAttackPerformed,
        OnBasicAttackCanceled;

    public GameEvent<Vector3> 
        OnPrimarySkillStarted,
        OnPrimarySkillPerfomed,
        OnPrimarySkillCanceled;   
        
    public GameEvent<Vector3> 
        OnSecondarySkillStarted,
        OnSecondarySkillPerfomed,
        OnSecondarySkillCanceled;

    public GameEvent OnInteractStarted;
    
    
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkMovementInputData inputData))
        {
            if (inputData.MovementInput != Vector2.zero)
            {
                OnMovePerformed.Invoke(inputData.MovementInput);
            }
            
            if (inputData.MovementStarted)
            {
                OnMoveStarted.Invoke();
            }
            
            if (inputData.MovementCanceled)
            {
                OnMoveCanceled.Invoke();
            }
        }
    }
    
}
