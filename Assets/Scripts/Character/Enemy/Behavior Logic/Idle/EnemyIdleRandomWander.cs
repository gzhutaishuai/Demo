using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = ("Idle-Random Wander"), menuName = ("Enemy Logic/Idle Logic/Random Wander"))]
public class EnemyIdleRandomWander : EnemyIdleSOBase
{
    #region Idle Variables
    [SerializeField] private float RandomMoveRange = 5f;//����ƶ���Χ
    [SerializeField] private float RandomMoveSpeed = 3f;//�ƶ��ٶ�
    public float waitTimer = 5f;//�Ⱥ�ʱ��
    #endregion

    private Vector3 _targetPos;//Ŀ��λ��
    private Vector3 _targetDir;//����
    private float _waitInterval;//�Ⱥ��ʱ��

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type)
    {
        base.DoAnimationTriggerEventLogic(type);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        _targetPos = GetRandomPoint();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if(waitTimer>=0f) { waitTimer -= Time.deltaTime; }

    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
        _targetDir = (_targetPos - transform.position).normalized;//����
        enemy.MoveEnemy(_targetDir * RandomMoveSpeed);//�ƶ�����
        if ((enemy.transform.position - _targetPos).sqrMagnitude <= 0.1f||waitTimer<=0f)//�������Ŀ��㣬�����»�ȡ��
        {
            waitTimer = 5f;
            _targetPos = GetRandomPoint();
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
    private Vector3 GetRandomPoint()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * RandomMoveRange;
    }
}
