using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour, IEnemyMoveable, ITriggerCheckable
{
    private Character_Stats enemy_Stats;//���������Լ���character_Stats�ű�

    public Rigidbody2D rb { get ; set ; }//�������


    public Animator animator ;//�������

    public bool isFacRight { get; set; } = true;//����

    public bool IsAggroed { get; set; }//�Ƿ���Ѳ�߷�Χ��

    public bool IsInAttackDistance { get; set; }//�Ƿ��ڹ�����Χ��



    #region ScriptableObject Variables
    [SerializeField] private EnemyIdleSOBase EnemyIdleBase;
    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;

    //SO�ļ�
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
        //��ʼ�����ʵ��������
        stateMachine = new EnemtStateMachine();

        idleState=new EnemyIdleState(this,stateMachine);
        patrolState=new EnemyPatrolState(this,stateMachine);
        chaseState = new EnemyChaseState(this,stateMachine);
        attackState=new EnemyAttackState(this,stateMachine);
    }
 

    private void Start()
    {
        //Ҫ��ʼ������SO�ű����ڽ����ʼ״̬
        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        stateMachine.Initialize(idleState);//��ʼ��״̬ΪѲ��״̬ 

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
            //����ٶ�Ϊ�㣬����idle����
            animator.SetBool("Run",false);
        }
        else
        {
            //��������ܲ�����
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
        //TODO:���˽Ų���֮���

    }

}
