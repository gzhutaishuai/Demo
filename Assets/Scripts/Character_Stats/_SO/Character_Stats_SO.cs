using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character_Stats_SO",menuName ="Character_Stats/Character_Data")]
public class Character_Stats_SO : ScriptableObject
{
    [Header("Stats Info")]
    public int maxHealth;//最大生命值
    public int curHealth;//当前生命值
    public int baseDefence;//基础防御力
    public int curDefence;//当前防御力
    //TODO 完成升级功能


    [Header("Kill Numbers")]
    public int kills;//杀敌数
    [Header("Level")]
    public int curLevel;//当前等级
    public int maxLevel;//最高等级
    public int curExp;//当前经验条
    public int maxExp;//升级所需最大经验条


}
