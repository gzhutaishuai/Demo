using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¹¥»÷×´Ì¬
/// </summary>
public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemtStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void AniamtionTriggerEvent(Enemy.AnimationTriggerType triigerType)
    {
        base.AniamtionTriggerEvent(triigerType);
        enemy.EnemyAttackBaseInstance.DoAnimationTriggerEventLogic(triigerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.EnemyAttackBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyAttackBaseInstance.DoExitLogic();

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyAttackBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyAttackBaseInstance.DoPhysicsLogic();
    }
}
