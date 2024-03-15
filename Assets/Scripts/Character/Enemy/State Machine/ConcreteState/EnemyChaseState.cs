using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ×·»÷×´Ì¬
/// </summary>
public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemtStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
       
    }

    public override void AniamtionTriggerEvent(Enemy.AnimationTriggerType triigerType)
    {
        base.AniamtionTriggerEvent(triigerType);
        enemy.EnemyChaseBaseInstance.DoAnimationTriggerEventLogic(triigerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.EnemyChaseBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyChaseBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyChaseBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyChaseBaseInstance.DoPhysicsLogic();
    }
}
