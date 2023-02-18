using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator animator;
    private SphereCollider collider;
    public LayerMask playerLayer;
    private GameObject player;
    private float nextDamage;
    public float damageRate;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        bool hit = Physics.CheckSphere(collider.bounds.center, collider.radius, playerLayer);

        animator.SetBool("Attack", hit);

        if(Time.time > nextDamage && hit)
        {
            player.GetComponent<PlayerHealth>().ChangeHealth(-10);
            nextDamage = Time.time + 0.1f / damageRate;
        }
    }
}