using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Attack-Bullet Attack"), menuName = ("Enemy Logic/Attack Logic/Bullet Attack"))]
public class EnemyAttackBulletPlayer : EnemyAttackSOBase
{
   [SerializeField] private Rigidbody2D bulletPrefab;//�ӵ�Ԥ����

   [SerializeField] private float _timeBetweenShot = 2f;//������  
   [SerializeField] private float _timeTillExit = 2f;//�˳�ʱ��
   [SerializeField] private float _distanceToCountExit = 1f;//��ʼ�����˳�����
   [SerializeField] private float _bulletSpeed = 4f;//�ӵ��ٶ�

    private float _timer;//��ʱ��
    private float _exitTimer;//�˳���ʱ��
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
        //��������ʱ�����ڹ涨ʱ�䣬�����ӵ�
        if (_timer > _timeBetweenShot)
        {
            _timer = 0f;
            Vector2 dir = (playerTransform.position - enemy.transform.position-new Vector3(0,1.5f)).normalized;//�����ӵ�����ķ���
            Rigidbody2D bullet = GameObject.Instantiate(bulletPrefab, enemy.transform.position, Quaternion.identity);//�ӵ����ɵ�λ��
            bullet.velocity = dir * _bulletSpeed;//�ӵ��ٶ�

        }
        //�����ҵľ���͵��˵ľ�����ڹ����ľ��룬�ͽ���׷��״̬
        if (Vector2.Distance(playerTransform.position, enemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;
            if (_exitTimer > _timeTillExit)
            {
                enemy.stateMachine.ChangeState(enemy.chaseState);
            }
        }
        //�����˳�ʱ��ͼ�Ϊ0
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
