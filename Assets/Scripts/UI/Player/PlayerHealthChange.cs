using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerHealthChange : MonoBehaviour
{
    Image healthImage;
    Character_Stats player_Stats;
    public float delayAmount = 1f;
    private float delaySpeed = 1.5f;
    private void Awake()
    {
        healthImage = transform.Find("HealthBottom").Find("HealthSliced").GetComponent<Image>();
        player_Stats=GameObject.Find("Player").GetComponent<Character_Stats>(); 
    }

    private void OnEnable()
    {
        player_Stats.changeHPAction += UpdateHealth;
    }
    private void Update()
    {
        if (healthImage.fillAmount > delayAmount)
        {
            healthImage.fillAmount -= Time.deltaTime * delaySpeed;
        }
        if(healthImage.fillAmount < delayAmount)
        {
            healthImage.fillAmount += Time.deltaTime * delaySpeed;
        }
    }

    private void OnDisable()
    {
        player_Stats.changeHPAction -= UpdateHealth;
    }
    private void UpdateHealth(int curHp, int maxHp)
    {
        delayAmount = (float)curHp / maxHp;
    }
}
