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
    /// 初始化函数
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
        //如果进入巡逻范围，改变为追逐状态
        if (enemy.IsInAttackDistance)
        {
            enemy.stateMachine.ChangeState(enemy.attackState);
        }
        //如果退出激怒范围，就改为idle
        if(!enemy.IsAggroed)
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
        }
    }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type) { }

    /// <summary>
    ///  用来处理需要重新设置的参数
    /// </summary>
    public virtual void ResetValues() { }
}
