using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Animator animator;
    public Animator CameraAnimator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("IsAim", Input.GetKey(KeyCode.Mouse1));
        CameraAnimator.SetBool("IsAim", Input.GetKey(KeyCode.Mouse1));
    }
}
