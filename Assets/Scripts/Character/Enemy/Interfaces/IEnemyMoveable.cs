using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ƶ��Ľӿ�
/// </summary>
public interface IEnemyMoveable 
{
    Rigidbody2D rb { get; set; }

    bool isFacRight { get; set; }
    /// <summary>
    /// �ƶ�����
    /// </summary>
    /// <param name="velocity"></param>
    void MoveEnemy(Vector2 velocity);
    /// <summary>
    /// ���˳���
    /// </summary>
    /// <param name="velocity"></param>
    void CheckFacing(Vector2 velocity);


}
