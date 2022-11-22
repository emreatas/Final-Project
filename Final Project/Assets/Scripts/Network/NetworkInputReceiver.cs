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
        OnPrimarySkillPerfomed;
       
    
    public GameEvent OnPrimarySkillCanceled;  
        
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
                Vector3 movementVector = new Vector3(inputData.MovementInput.x, 0, inputData.MovementInput.y);
                
                OnMovePerformed.Invoke(movementVector);
            }
            
            if (inputData.MovementStarted)
            {
                OnMoveStarted.Invoke();
            }
            
            if (inputData.MovementCanceled)
            {
                OnMoveCanceled.Invoke();
            }

            if (inputData.BasicAttackStarted)
            {
                Debug.Log("Girdiiiiiiiii   1");
                OnBasicAttackStarted.Invoke();
            }

            if (inputData.BasicPerformedStarted)
            {
                Debug.Log("Girdiiiiiiiii");
                OnBasicAttackPerformed.Invoke();
            }

            if (inputData.BasicCanceledStarted)
            {
                Debug.Log("Ciktiiiiiiiiii");
                OnBasicAttackCanceled.Invoke();
            }
        }
    }
}
