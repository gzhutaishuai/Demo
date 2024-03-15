using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtStateMachine 
{
   public EnemyState currentState { get;set; }
   
    /// <summary>
    /// 进入第一种逻辑状态
    /// </summary>
    /// <param name="startState"></param>
   public void Initialize(EnemyState startState) 
   {
        currentState = startState;
        currentState.EnterState();
   }
    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="newState"></param>
   public void ChangeState(EnemyState newState)
   {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
   }
}
