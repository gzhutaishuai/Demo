using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人移动的接口
/// </summary>
public interface IEnemyMoveable 
{
    Rigidbody2D rb { get; set; }

    bool isFacRight { get; set; }
    /// <summary>
    /// 移动方法
    /// </summary>
    /// <param name="velocity"></param>
    void MoveEnemy(Vector2 velocity);
    /// <summary>
    /// 敌人朝向
    /// </summary>
    /// <param name="velocity"></param>
    void CheckFacing(Vector2 velocity);


}
