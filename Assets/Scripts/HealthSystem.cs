using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    private int healthAmount;
    private int healthAmountMax;

    public HealthSystem(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        healthAmount -= amount;
        if(healthAmount < 0)
        {
            healthAmount = 0;
        }
        if(OnDamaged != null)
        {
        //    OnDamaged(this, EventHandler.Equals.Damage);
        }
    }

    public void Heal(int amount)
    {
        healthAmount += amount;
        if(healthAmount > healthAmountMax)
        {
            healthAmount = healthAmountMax;
        }
        if (OnHealed != null)
        {
         //   OnHealed(this, EventHandler.Equals.Heal);
        }
    }

    public float GetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
}
