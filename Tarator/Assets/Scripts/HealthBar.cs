using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image healthBar;  
    public float currentHealth; 
    private float maxHealth = 100f;
    PlayerController Player;

    // Start is called before the first frame update
    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
