using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 巡逻状态
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
        //TODO:巡逻状态功能的实际开发，以及配套动画如何实现
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
