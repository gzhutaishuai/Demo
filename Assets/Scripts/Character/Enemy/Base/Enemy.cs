using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemyMoveable
{
    private Character_Stats enemy_Stats;//敌人身上自己的character_Stats脚本

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
        //初始化类的实例，对象
        stateMachine = new EnemtStateMachine();
        patrolState=new EnemyPatrolState(this,stateMachine);
        chaseState = new EnemyChaseState(this,stateMachine);
    }

    private void Start()
    {
        stateMachine.Initialize(patrolState);//初始化状态为巡逻状态

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
