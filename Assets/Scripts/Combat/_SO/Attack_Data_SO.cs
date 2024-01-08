using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Attack",menuName ="Attack/Attack_Data")]
public class Attack_Data_SO : ScriptableObject
{
    public float melee_Range;//��ս������Χ

    public float arrow_Range;//Զ�̹�����Χ

    public float coll_Down;//������ȴ

    public float minDamage;//��С�˺�

    public float maxDamage;//����˺�

    public float criticalDamage;//�����˺��ӳ�

    public float criticalChance;//������
}
