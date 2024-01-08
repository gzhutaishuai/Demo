using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected Enemy enemy;//������
    protected EnemtStateMachine enemyStateMachine;//fsm
    public EnemyState(Enemy enemy, EnemtStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    //��Ҫ������߼�״̬
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void AniamtionTriggerEvent(Enemy.AnimationTriggerType triigerType) { }
}
