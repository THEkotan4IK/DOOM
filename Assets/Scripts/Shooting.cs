using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("OPTIONS")]
    public float range;
    public float fireRate;
    public float damage;
    private float nextFire;

    public float recoilX;
    public float recoilY;

    public int AmmoCount;
    public int MagazineAmmoCount;
    public int MaxMagazineAmmoCount;

    public float deleteImpactTime;

    [Header("GAMEOBJECTS")]
    public GameObject camera;
    public GameObject hitEffect;

    [Header("ANIMATIONS")]
    private Animator animator;

    [Header("AUDIO")]
    public AudioSource shootSFX;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && MagazineAmmoCount > 0)
        {
            RayShoot();
            nextFire = Time.time + 0.1f / fireRate;
        }
    }

    void RayShoot()
    {   
        if (!shootSFX.isPlaying)
        {
            shootSFX.Play();
        }
        MagazineAmmoCount--;

        animator.SetTrigger("Shot");

        camera.transform.rotation = camera.transform.rotation * Quaternion.Euler(UnityEngine.Random.Range(-recoilX, recoilX), UnityEngine.Random.Range(-recoilY, recoilY), 0);

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.name);
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, deleteImpactTime);
        }
    }
}
