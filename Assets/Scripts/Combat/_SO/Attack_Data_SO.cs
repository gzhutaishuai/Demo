using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Attack",menuName ="Attack/Attack_Data")]
public class Attack_Data_SO : ScriptableObject
{
    public float arrow_Range;//Զ�̹�����Χ

    public float coll_Down;//������ȴ

    public int minDamage;//��С�˺�

    public int maxDamage;//����˺�

    public float criticalDamage;//�����˺��ӳ�

    public float criticalChance;//������
}
