using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ñ²Âß×´Ì¬
/// </summary>
public class EnemyPatrolState : EnemyState
{


    public EnemyPatrolState(Enemy enemy, EnemtStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void AniamtionTriggerEvent(Enemy.AnimationTriggerType triigerType)
    {
        base.AniamtionTriggerEvent(triigerType);

    }

    public override void EnterState()
    {
        base.EnterState();

        //enemy.animator.SetTrigger("run");
    }

    public override void ExitState()
    {
        base.ExitState();

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
