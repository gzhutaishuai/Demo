using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseSOBase : ScriptableObject
{
    protected Enemy enemy;

    protected Transform transform;

    protected GameObject gameObject;

    protected Transform playerTransform;

    /// <summary>
    /// ��ʼ������
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="enemy"></param>
    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        this.enemy = enemy;
        transform = gameObject.transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }

    public virtual void DoExitLogic() { ResetValues(); }

    public virtual void DoFrameUpdateLogic()
    {
        //�������Ѳ�߷�Χ���ı�Ϊ׷��״̬
        if (enemy.IsInAttackDistance)
        {
            enemy.stateMachine.ChangeState(enemy.attackState);
        }
        //����˳���ŭ��Χ���͸�Ϊidle
        if(!enemy.IsAggroed)
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
        }
    }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type) { }

    /// <summary>
    ///  ����������Ҫ�������õĲ���
    /// </summary>
    public virtual void ResetValues() { }
}
