using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int worthXP;
    private int health;
    private XPSystem xpsystem;
    private Animator animator;

    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
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

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        xpsystem.ChangeScore(worthXP);
        animator.SetTrigger("Dead");
        Destroy(gameObject, 3);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeHealth(-30);
        }
    }
}
