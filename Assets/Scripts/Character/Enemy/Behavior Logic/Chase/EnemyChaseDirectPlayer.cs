using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Chase-Chase Player"), menuName = ("Enemy Logic/Chase Logic/Chase Player"))]
public class EnemyChaseDirectPlayer : EnemyChaseSOBase
{
    [SerializeField]private float _chaseSpeed = 3.5f;//׷���ٶ�
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type)
    {
        base.DoAnimationTriggerEventLogic(type);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();

        Vector2 moveDir = (playerTransform.position - enemy.transform.position).normalized;

        enemy.MoveEnemy(moveDir * _chaseSpeed);
        //������빥����Χ�����л�Ϊ����״̬
        if (enemy.IsInAttackDistance)
        {
            enemy.stateMachine.ChangeState(enemy.attackState);
        }
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
