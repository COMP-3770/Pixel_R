using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private GameObject chargerEnemy;
    private ChargerEnemy ce;
    private Animator chargerAnimation;
    private bool playerInRange;
   
    // Start is called before the first frame update
    void Start()
    {
        //find the parents object charger Enemy
        chargerEnemy = transform.parent.gameObject;
        ce = chargerEnemy.GetComponent<ChargerEnemy>();
       // transform = chargerEnemy.transform;

        chargerAnimation = chargerEnemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
         //   Debug.Log("111111111111");
            ce.SetSpeed(ce.walkSpeed);
            playerInRange = true;
            chargerAnimation.SetBool("Run Forward", playerInRange);
            ce.SetWalkBool(false);
            chargerAnimation.SetBool("Walk Forward", false);

        }
        //  Debug.Log(hitInfo.name);
    }

    void OnTriggerExit(Collider hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
          //  Debug.Log("2222222222222");
            ce.SetSpeed(ce.runSpeed);
            playerInRange = false;
            chargerAnimation.SetBool("Run Forward", playerInRange);
            chargerAnimation.SetBool("Walk Forward", true);
        }
    }
}
