using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    private GameObject m_Self;
    private void Awake()
    {
        m_Self = transform.parent.parent.gameObject;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Enemy"))
        {          
            collision.GetComponent<Character_Stats>().TakeDamage(m_Self.transform.GetComponent<Character_Stats>(), collision.GetComponent<Character_Stats>());
        }
       if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Character_Stats>().TakeDamage(m_Self.transform.GetComponent<Character_Stats>(),collision.GetComponent<Character_Stats>());

        }
    }
}
