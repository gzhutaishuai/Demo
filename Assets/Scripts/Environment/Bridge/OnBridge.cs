using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBridge : MonoBehaviour
{
    public bool is_OnBridge;//是否在桥上
    private SpriteRenderer spriteRenderer;
    [Header("桥下的石头")]
    public GameObject left_Stone;
    public GameObject right_Stone;
    [Header("桥的边界")]
    public GameObject bridge_Stone;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(is_OnBridge)
        {
            left_Stone.SetActive(false);
            right_Stone.SetActive(false);
            bridge_Stone.SetActive(true);
        }
        else
        {
            left_Stone.SetActive(true);
            right_Stone.SetActive(true);
            bridge_Stone.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           if(spriteRenderer.sortingOrder==0&&spriteRenderer.sortingLayerName=="Character")
            {
                is_OnBridge = true;
            }
           else
            {
                is_OnBridge = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            is_OnBridge = false;
        }
    }


}
