using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFade : MonoBehaviour
{
    private Image barImage;
    public HealthSystem healthSystem;

    private void Awake()
    {
        barImage = transform.Find("HealthBar").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {

        SetHealth(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
    }
}
