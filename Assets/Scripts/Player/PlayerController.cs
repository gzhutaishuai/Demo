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
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontal = UnityEngine.Input.GetAxis("Horizontal");
        vertical = UnityEngine.Input.GetAxis("Vertical");
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
        Vector2 position= rb.position;
        position.x=position.x+speed*horizontal*Time.deltaTime;
        position.y=position.y+speed*vertical*Time.deltaTime;
        rb.MovePosition(position);
        
        animator.SetFloat("SpeedX", Mathf.Abs(speed*horizontal));
        animator.SetFloat("SpeedY", Mathf.Abs(speed*vertical));
    }
}
