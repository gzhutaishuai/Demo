using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    [Header("Speed")]
    float horizontal;
    float vertical;
    public float speed;//移动速度

    #region Attack Info
    [Header("Attack")]
    private float interval=2;//连击间隔
    private bool isAttack;//是否处于攻击状态
    private string attack_Type;//攻击类型
    private float AttackSpeed=1;//攻击前进距离
    private float lr_attack_Time;//左右攻击计时器
    private int lr_Combo;//左右连击数
    private float up_attack_Time;//向上攻击计时器
    private float down_attack_Time;//向下攻击计时器
    private int up_Combo;//向上连击数
    private int down_Combo;//向下连击数
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontal = UnityEngine.Input.GetAxis("Horizontal");
        vertical = UnityEngine.Input.GetAxis("Vertical");
        Attack();
    }
    private void FixedUpdate()
    {
        
        Move();
    }
    /// <summary>
    /// 人物移动
    /// </summary>
    private void Move()
    {
   ;
        Vector3 scale = transform.localScale;
        if(horizontal < 0 )
        {
            transform.localScale = new Vector3( -1, 1, 1);
            scale=transform.localScale;
        }
        else if(horizontal>0)
        { 
            transform.localScale = new Vector3(1, 1, 1);
            scale = transform.localScale;
        }
        else
        {
            transform.localScale = scale;
        }
        if (!isAttack)
        {
            Vector2 position = rb.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;
            rb.MovePosition(position);
        }
        else
        {
            if(attack_Type== "LR_Attack")
            {
                rb.velocity = new Vector2(transform.localScale.x * AttackSpeed, 0);
            }
            else if(attack_Type=="Up_Attack")
            {
                rb.velocity = new Vector2(0, AttackSpeed);
            }
            else if(attack_Type=="Down_Attack")
            {
                rb.velocity = new Vector2(0, -AttackSpeed);
            }
        }
        animator.SetFloat("SpeedX", Mathf.Abs(speed*horizontal));
        animator.SetFloat("SpeedY", Mathf.Abs(speed*vertical));
    }

    private void Attack()
    {
        if(vertical>0&& UnityEngine.Input.GetKeyDown(KeyCode.J)&&!isAttack)
        {
            attack_Type = "Up_Attack";
            isAttack = true;
            up_Combo++;
            if (up_Combo > 2) up_Combo = 1;
            up_attack_Time = interval;
            animator.SetTrigger("AttackUp");
            animator.SetInteger("UP_Combo", up_Combo);
        }
        if(vertical < 0 && UnityEngine.Input.GetKeyDown(KeyCode.J)&&!isAttack)
        {
           
            attack_Type = "Down_Attack";
            isAttack = true;
            down_Combo++;
            if(down_Combo>2) down_Combo = 1;
            up_attack_Time=interval;
            animator.SetTrigger("AttackDown");
            animator.SetInteger("Down_Combo", down_Combo);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.J)&&!isAttack&&vertical==0)
        {
            isAttack = true;
            attack_Type = "LR_Attack";
            lr_Combo++;
            if (lr_Combo > 2) lr_Combo = 1;
            lr_attack_Time = interval;
            animator.SetTrigger("AttackLR");
            animator.SetInteger("LR_Combo", lr_Combo);
        }
        //连击间隔
        if (lr_attack_Time!=0)
        {
            lr_attack_Time-=Time.deltaTime;
            if(lr_attack_Time<=0)
            {
                lr_attack_Time=0;
                lr_Combo = 0;
            }
        }
        if (up_attack_Time != 0)
        {
            up_attack_Time -= Time.deltaTime;
            if (up_attack_Time <= 0)
            {
                up_attack_Time = 0;
                up_Combo = 0;
            }
        }
        if (down_attack_Time != 0)
        {
            down_attack_Time-= Time.deltaTime;
            if (down_attack_Time <= 0)
            {
                down_attack_Time = 0;
                down_Combo = 0;
            }
        }
    }
    public void AttackOver()
    {
        isAttack = false;
    }
}
