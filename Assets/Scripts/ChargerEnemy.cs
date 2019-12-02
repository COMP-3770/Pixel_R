using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargerEnemy : MonoBehaviour
{
    public float startHealth = 100;
    private float health = 100;
    private float speed;
    public float walkSpeed = 2;
    public float runSpeed = 4;

    public Transform headCheckPoint;
    public Vector3 groundCheckHalfExtents;
    private bool isHeadTounchingGround;
    public LayerMask enemyLayer;
    private Rigidbody rb;

    public Image healthBar;
    private Animator chargerAnimation;
    private bool isWalkForward;
    // Start is called before the first frame update
    void Start()
    {

        speed = walkSpeed;
        //charger walk forward
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed * Time.deltaTime * 100f;
        chargerAnimation = GetComponent<Animator>();
        health = startHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime * 100f;
        isHeadTounchingGround = Physics.CheckBox(headCheckPoint.position, groundCheckHalfExtents, headCheckPoint.rotation, enemyLayer);
        if(isHeadTounchingGround)
        {
            TakeDamage(50f);
        }

        isWalkForward = true;
        chargerAnimation.SetBool("Walk Forward", isWalkForward);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        rb.velocity = transform.forward * speed * Time.deltaTime * 10f;
        if (health < 0)
        {
            health = 0;
            Die();
        }
    }

    public void SetSpeed(float newspeed)
    {
        this.speed = newspeed;
    }

    public void SetWalkBool(bool wb)
    {
        this.isWalkForward = wb;
    }

    public void Die()
    {
        chargerAnimation.SetBool("Die", true);
        Destroy(gameObject, 1.5f);
    }

}
