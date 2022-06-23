using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

	// Set slider's max health and value
	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
	}
	
	// Set slider's value
    public void SetHealth(int health)
	{
		slider.value = health;
	}
}
