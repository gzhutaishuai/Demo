using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected Enemy enemy;//敌人类
    protected EnemtStateMachine enemyStateMachine;//fsm
    public EnemyState(Enemy enemy, EnemtStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    //需要处理的逻辑状态
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void AniamtionTriggerEvent(Enemy.AnimationTriggerType triigerType) { }
}
