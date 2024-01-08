using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemyMoveable
{
    private Character_Stats enemy_Stats;//���������Լ���character_Stats�ű�

    public Rigidbody rb { get ; set ; }

    public Animator animator ;

    #region State Machine Variables
    public EnemtStateMachine stateMachine { get; set ; } 
    public EnemyPatrolState patrolState { get; set ; }
    public EnemyChaseState chaseState { get; set ; }
    #endregion
    private void Awake()
    {
        enemy_Stats = GetComponent<Character_Stats>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //��ʼ�����ʵ��������
        stateMachine = new EnemtStateMachine();
        patrolState=new EnemyPatrolState(this,stateMachine);
        chaseState = new EnemyChaseState(this,stateMachine);
    }

    private void Start()
    {
        stateMachine.Initialize(patrolState);//��ʼ��״̬ΪѲ��״̬

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
    
    public enum AnimationTriggerType
    {

    }

}
