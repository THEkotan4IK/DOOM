using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator animator;
    private Collider collider;
    public LayerMask playerLayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }
    void Update()
    {
        RaycastHit hit;

        animator.SetBool("Attack", Physics.SphereCast(collider.bounds.center, 1, transform.forward, out hit, playerLayer));
    }
}
