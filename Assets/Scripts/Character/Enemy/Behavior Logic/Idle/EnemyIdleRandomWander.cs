using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = ("Idle-Random Wander"), menuName = ("Enemy Logic/Idle Logic/Random Wander"))]
public class EnemyIdleRandomWander : EnemyIdleSOBase
{
    #region Idle Variables
    [SerializeField] private float RandomMoveRange = 5f;//随机移动范围
    [SerializeField] private float RandomMoveSpeed = 3f;//移动速度
    public float waitTimer = 5f;//等候时间
    #endregion

    private Vector3 _targetPos;//目标位置
    private Vector3 _targetDir;//朝向
    private float _waitInterval;//等候计时器

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
        _targetDir = (_targetPos - transform.position).normalized;//朝向
        enemy.MoveEnemy(_targetDir * RandomMoveSpeed);//移动方法
        if ((enemy.transform.position - _targetPos).sqrMagnitude <= 0.1f||waitTimer<=0f)//如果到达目标点，就重新获取点
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
