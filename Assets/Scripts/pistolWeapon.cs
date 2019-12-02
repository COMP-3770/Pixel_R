using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isShoot = false;
    private playerController pc;
    private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<playerController>();
        playerAnimation = pc.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            isShoot = true;
            playerAnimation.SetBool("IsShoot", isShoot);

            playerAnimation.SetFloat("speed", Mathf.Abs(pc.GetComponent<Rigidbody>().velocity.x));


        }
        //    isShoot = false;
        //    playerAnimation.SetBool("IsShoot", isShoot);


    }

    private void Shoot()
    {
        //change the bullet rotation

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
