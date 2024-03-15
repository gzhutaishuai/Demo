using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Attack-Pawn Attack"), menuName = ("Enemy Logic/Attack Logic/Pawn Attack"))]
public class EnemyAttackPawn : EnemyAttackSOBase
{
    [SerializeField] private float _timeBetweenAttack = 2f;//射击间隔  
    [SerializeField] private float _attackTimer = 2f;//射击计时器  
    [SerializeField] private float _distanceToCountExit = 4f;//开始计算退出距离

    private float _timer;//计时器
    private float _exitTimer;//退出计时器
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
       if(Vector2.Distance(playerTransform.position,this.enemy.transform.position) <=_distanceToCountExit)
       {
            enemy.MoveEnemy(Vector2.zero);
       }
         if(_attackTimer<0f)
         {
            _attackTimer = _timeBetweenAttack;//重新恢复

            this.enemy.animator.SetTrigger("Attack");
         }
         if(Vector2.Distance(this.enemy.transform.position,playerTransform.position) > _distanceToCountExit)
         {
            this.enemy.stateMachine.ChangeState(this.enemy.chaseState);
         }
        _attackTimer -= Time.deltaTime;

    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
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
