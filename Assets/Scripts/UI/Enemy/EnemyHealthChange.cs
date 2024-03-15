using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthChange : MonoBehaviour
{
    Image healthImage;//ÑªÌõ»¬¶¯
    Character_Stats enemy_Stats;
    private float delayAmount=1f;
    private float delaySpeed=1.5f;

    private void Awake()
    {
        healthImage = transform.Find("EnemyHealth").Find("HealthSliced").GetComponent<Image>();
        enemy_Stats=transform.parent.GetComponent<Character_Stats>();
    }

    private void OnEnable()
    {
        enemy_Stats.changeHPAction += HpUpdate;
    }

    private void Update()
    {
        if(healthImage.fillAmount > delayAmount)
        {
            healthImage.fillAmount -= Time.deltaTime*delaySpeed;
        }
        if(healthImage.fillAmount <=0f)
        {
            transform.gameObject.SetActive(false);
            
        }
        
    }
    private void OnDisable()
    {
        enemy_Stats.changeHPAction -= HpUpdate;
    }
    private void HpUpdate(int curHp, int maxHp)
    {
        delayAmount =(float)curHp / maxHp;
    }
}
