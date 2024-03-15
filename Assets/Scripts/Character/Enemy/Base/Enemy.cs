using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour, IEnemyMoveable, ITriggerCheckable
{
    private Character_Stats enemy_Stats;//敌人身上自己的character_Stats脚本

    public Rigidbody2D rb { get ; set ; }//刚体组件


    public Animator animator ;//动画组件

    public bool isFacRight { get; set; } = true;//朝向

    public bool IsAggroed { get; set; }//是否处于巡逻范围内

    public bool IsInAttackDistance { get; set; }//是否处于攻击范围内



    #region ScriptableObject Variables
    [SerializeField] private EnemyIdleSOBase EnemyIdleBase;
    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;

    //SO文件
    public EnemyIdleSOBase EnemyIdleBaseInstance { get; set; }
    public EnemyChaseSOBase EnemyChaseBaseInstance { get; set; }
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }

    #endregion

    #region State Machine Variables

    public EnemtStateMachine stateMachine { get; set ; }
    public EnemyIdleState idleState { get; set; }
    public EnemyPatrolState patrolState { get; set ; }
    public EnemyChaseState chaseState { get; set ; }
    public EnemyAttackState attackState { get; set ; }
    public bool isAggroed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool isInAttackDistance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    #endregion




    private void Awake()
    {
        EnemyIdleBaseInstance = Instantiate(EnemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);


        enemy_Stats = GetComponent<Character_Stats>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        //初始化类的实例，对象
        stateMachine = new EnemtStateMachine();

        idleState=new EnemyIdleState(this,stateMachine);
        patrolState=new EnemyPatrolState(this,stateMachine);
        chaseState = new EnemyChaseState(this,stateMachine);
        attackState=new EnemyAttackState(this,stateMachine);
    }
 

    private void Start()
    {
        //要初始化各个SO脚本，在进入初始状态
        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        stateMachine.Initialize(idleState);//初始化状态为巡逻状态 

    }

    private void Update()
    {
        stateMachine.currentState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    private void AniamtionTriggerEvent(AnimationTriggerType triggertype)
    {
        //TODO:fill in once StateMachine is Createrd
    }
    #region Move Actions
    public void MoveEnemy(Vector2 velocity)
    {
        rb.velocity = velocity;
        if(velocity==Vector2.zero)
        {
            //如果速度为零，进入idle动画
            animator.SetBool("Run",false);
        }
        else
        {
            //否则进入跑步动画
            animator.SetBool("Run", true);
        }
        CheckFacing(velocity);
    }

    public void CheckFacing(Vector2 velocity)
    {
       if(isFacRight&&rb.velocity.x < 0f)
        {
            transform.localScale=new Vector2(-1,1);
            isFacRight=!isFacRight;
        }
       else if(!isFacRight&&rb.velocity.x>0f)
        {
            transform.localScale=new Vector2(1,1);
            isFacRight=!isFacRight;
        }
    }

    #endregion

    #region Distance Checks
    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetAttackStatus(bool isInAttackDistance)
    {
        IsInAttackDistance = isInAttackDistance; 
    }
    #endregion
    public enum AnimationTriggerType 
    {
        //TODO:敌人脚步声之类的

    }

}
