using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shooting : MonoBehaviour
{
    [Header("OPTIONS")]
    public float range;
    public float fireRate;
    public int damage;
    private float nextFire;

    public float recoilX;
    public float recoilY;

    public int AmmoCount;
    public int MagazineAmmoCount;
    public int MaxMagazineAmmoCount;

    public float deleteImpactTime;

    [HideInInspector]public bool canShoot;

    [Header("GAMEOBJECTS")]
    public GameObject camera;
    public GameObject hitEffect;

    private CinemachineImpulseSource impulse;

    [Header("ANIMATIONS")]
    private Animator animator;

    [Header("AUDIO")]
    public AudioSource shootSFX;

    private void Start()
    {
        canShoot = true;
        animator = GetComponent<Animator>();
        impulse = GetComponent<CinemachineImpulseSource>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && MagazineAmmoCount > 0 && canShoot)
        {
            RayShoot();
            nextFire = Time.time + 0.1f / fireRate;
        }
    }

    void RayShoot()
    {
        MagazineAmmoCount--;

        shootSFX.PlayOneShot(shootSFX.clip);

        animator.SetTrigger("Shot");

        impulse.GenerateImpulse();

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("?????? ?? ????????");
                hit.collider.GetComponent<EnemyHealth>().ChangeHealth(-damage);
            }

            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, deleteImpactTime);
        }
    }
}
