using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtStateMachine 
{
   public EnemyState currentState { get;set; }
   
    /// <summary>
    /// �����һ���߼�״̬
    /// </summary>
    /// <param name="startState"></param>
   public void Initialize(EnemyState startState) 
   {
        currentState = startState;
        currentState.EnterState();
   }
    /// <summary>
    /// �л�״̬
    /// </summary>
    /// <param name="newState"></param>
   public void ChangeState(EnemyState newState)
   {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
   }
}
