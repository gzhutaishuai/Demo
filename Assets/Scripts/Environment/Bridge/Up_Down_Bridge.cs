using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Down_Bridge : MonoBehaviour
{
    public bool is_LRCollider;//ÊÇ·ñÊÇ×óÓÒÅö×²ÇøÓò

    [Header("ÇÅ")]
    public GameObject Bridge;//ÇÅ


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(is_LRCollider)
            {
                Bridge.GetComponent<SpriteRenderer>().sortingLayerName="Player";
                Bridge.GetComponent<SpriteRenderer>().sortingOrder = 0;

            }
            else 
            {
                Bridge.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
                Bridge.GetComponent<SpriteRenderer>().sortingOrder= 1;
            }
        }
    }
}
