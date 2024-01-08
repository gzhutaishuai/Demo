using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人移动的接口
/// </summary>
public interface IEnemyMoveable 
{
    Rigidbody rb { get; set; }
}
