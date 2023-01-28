using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int worthXP;
    private int health;
    private XPSystem xpsystem;

    void Start()
    {
        health = maxHealth;
        xpsystem = GameObject.FindGameObjectWithTag("XPSystem").GetComponent<XPSystem>();
    }
    public void ChangeHealth(int value)
    {
        health += value;
        if(value > 0)
        {
            print($"{gameObject} получил {value} здоровья");
        }
        else
        {
            print($"{gameObject} получил {value} урона");
        }

        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        xpsystem.ChangeScore(worthXP);
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeHealth(-30);
        }
    }
}
