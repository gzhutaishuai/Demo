using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Attack-Bullet Attack"), menuName = ("Enemy Logic/Attack Logic/Bullet Attack"))]
public class EnemyAttackBulletPlayer : EnemyAttackSOBase
{
   [SerializeField] private Rigidbody2D bulletPrefab;//子弹预制体

   [SerializeField] private float _timeBetweenShot = 2f;//射击间隔  
   [SerializeField] private float _timeTillExit = 2f;//退出时间
   [SerializeField] private float _distanceToCountExit = 1f;//开始计算退出距离
   [SerializeField] private float _bulletSpeed = 4f;//子弹速度

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
        enemy.MoveEnemy(Vector2.zero);
        //如果射击计时器大于规定时间，发射子弹
        if (_timer > _timeBetweenShot)
        {
            _timer = 0f;
            Vector2 dir = (playerTransform.position - enemy.transform.position-new Vector3(0,1.5f)).normalized;//计算子弹射出的方向
            Rigidbody2D bullet = GameObject.Instantiate(bulletPrefab, enemy.transform.position, Quaternion.identity);//子弹生成的位置
            bullet.velocity = dir * _bulletSpeed;//子弹速度

        }
        //如果玩家的距离和敌人的距离大于攻击的距离，就进入追击状态
        if (Vector2.Distance(playerTransform.position, enemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;
            if (_exitTimer > _timeTillExit)
            {
                enemy.stateMachine.ChangeState(enemy.chaseState);
            }
        }
        //否则退出时间就记为0
        else
        {
            _exitTimer = 0f;
        }
        _timer += Time.deltaTime;
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
