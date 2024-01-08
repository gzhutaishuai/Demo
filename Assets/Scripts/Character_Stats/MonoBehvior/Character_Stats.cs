using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Stats : MonoBehaviour
{
    public Character_Stats_SO template_Character_Data;
    public Character_Stats_SO character_Data;
    public Attack_Data_SO attack_Data;
    public Attack_Data_SO base_attack_Data;//基础人物攻击数据

    private int curHealth;
    private int maxHealth;
    private int curDefence;
    private int baseDefence;

    #region Read From SO
    public int CurHealth {get { if (character_Data != null) return character_Data.curHealth; else return 0; } set{ character_Data.curHealth = value; } }

    public int MaxHealth { get { if (character_Data != null) return character_Data.maxHealth; else return 0; } set { character_Data.maxHealth = value; } }

    public int CurDefence { get { if (character_Data != null) return character_Data.curDefence; else return 0; } set { character_Data.curDefence = value; } }

    public int BaseDefence { get { if (character_Data != null) return character_Data.baseDefence; else return 0; } set { character_Data.baseDefence = value; } }
    #endregion

    private void Awake()
    {
        //完成人物信息的传递
        if(template_Character_Data != null)
        {
            character_Data=Instantiate(template_Character_Data);
        }
        base_attack_Data=Instantiate(attack_Data);
    }
}
