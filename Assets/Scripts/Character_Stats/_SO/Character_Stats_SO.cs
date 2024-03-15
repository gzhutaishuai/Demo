using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character_Stats_SO",menuName ="Character_Stats/Character_Data")]
public class Character_Stats_SO : ScriptableObject
{
    [Header("Stats Info")]
    public int maxHealth;//�������ֵ
    public int curHealth;//��ǰ����ֵ
    public int baseDefence;//����������
    public int curDefence;//��ǰ������
    //TODO �����������


    [Header("Kill Numbers")]
    public int kills;//ɱ����
    [Header("Level")]
    public int curLevel;//��ǰ�ȼ�
    public int maxLevel;//��ߵȼ�
    public int curExp;//��ǰ������
    public int maxExp;//���������������


}
