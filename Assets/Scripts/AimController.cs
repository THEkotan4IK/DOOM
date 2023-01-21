using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Animator animator;
    public Animator CameraAnimator;

    public float dampingDelta = 0.2f;

    private Vector3 initialPositionX;

    void Start()
    {
        animator = GetComponent<Animator>();
        initialPositionX = transform.position;
    }
    void Update()
    {
        animator.SetBool("IsAim", Input.GetKey(KeyCode.Mouse1));
        CameraAnimator.SetBool("IsAim", Input.GetKey(KeyCode.Mouse1));
    }
}
