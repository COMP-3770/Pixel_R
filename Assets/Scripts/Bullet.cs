using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float bulletDamage = 5;
    public Rigidbody rb;
    public Rigidbody chargerRb;
    private ChargerEnemy charger;
    private Animator ca;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.tag == "charger")
        {
            // Debug.Log("11111111111111111");
            //  transform.position = respawnPoint;
            charger = hitInfo.gameObject.GetComponent<ChargerEnemy>();
            charger.TakeDamage(bulletDamage);

            charger.SetSpeed(-1f);
            //charger take damage animation
            ca = hitInfo.gameObject.GetComponent<Animator>();
            ca.Play("Take Damage");
      //      Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider hitInfo)
    {
        if (hitInfo.tag == "charger")
        {
            // Debug.Log("11111111111111111");
            //  transform.position = respawnPoint;
            charger = hitInfo.gameObject.GetComponent<ChargerEnemy>();
            charger.TakeDamage(bulletDamage);

            charger.SetSpeed(charger.walkSpeed);

            Destroy(gameObject);
        }
        //  Debug.Log(hitInfo.name);
    }
}
