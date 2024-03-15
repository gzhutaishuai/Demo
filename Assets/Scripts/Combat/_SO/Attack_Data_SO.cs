using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Attack",menuName ="Attack/Attack_Data")]
public class Attack_Data_SO : ScriptableObject
{
    public float arrow_Range;//Ô¶³Ì¹¥»÷·¶Î§

    public float coll_Down;//¹¥»÷ÀäÈ´

    public int minDamage;//×îĞ¡ÉËº¦

    public int maxDamage;//×î´óÉËº¦

    public float criticalDamage;//±©»÷ÉËº¦¼Ó³É

    public float criticalChance;//±©»÷ÂÊ
}
