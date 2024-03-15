using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Stats : MonoBehaviour
{
    public event Action<int, int> changeHPAction;

    public Character_Stats_SO template_Character_Data;
    public Character_Stats_SO character_Data;
    public Attack_Data_SO attack_Data;
    public Attack_Data_SO base_attack_Data;//�������﹥������

    #region Read From SO
    public int CurHealth {get { if (character_Data != null) return character_Data.curHealth; else return 0; } set{ character_Data.curHealth = value; } }

    public int MaxHealth { get { if (character_Data != null) return character_Data.maxHealth; else return 0; } set { character_Data.maxHealth = value; } }

    public int CurDefence { get { if (character_Data != null) return character_Data.curDefence; else return 0; } set { character_Data.curDefence = value; } }

    public int BaseDefence { get { if (character_Data != null) return character_Data.baseDefence; else return 0; } set { character_Data.baseDefence = value; } }

    #endregion

    private void Awake()
    {
        //���������Ϣ�Ĵ���
        if(template_Character_Data != null)
        {
            character_Data=Instantiate(template_Character_Data);
        }
        base_attack_Data=Instantiate(attack_Data);
    }



    public void TakeDamage(Character_Stats attacker,Character_Stats defener)
    {
        int damage =UnityEngine.Random.Range(attacker.attack_Data.minDamage, attacker.attack_Data.maxDamage);
        defener.CurHealth=Mathf.Max(defener.CurHealth-damage, 0);
        //���˺���
        Hurt(attacker, defener);

        //��ѪUI
        defener.changeHPAction?.Invoke(defener.CurHealth, defener.MaxHealth);
        //�����¼�
        if(defener.CurHealth<=0f)
        {
            defener.GetComponent<Animator>().SetBool("Dead",true);

            defener.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
       
            Destroy(defener.gameObject,2.5f);
        }

    }
    private void Hurt(Character_Stats attacker, Character_Stats defener)
    {
        defener.GetComponent<Animator>().SetTrigger("Hurt");
        Vector2 dir = attacker.transform.localScale;
        defener.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }



}
