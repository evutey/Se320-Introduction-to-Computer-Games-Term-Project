using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
	[SerializeField]
	public  float health;

	Image WhitePixel;
    public float maxHealth = 100f;
    public GameObject bar;
    public Text text;
    

	void Start ()
	{
		WhitePixel = bar.GetComponent<Image>();
		health = maxHealth;
	}

	void Update()
	{
		WhitePixel.fillAmount = health / maxHealth;
		text.text = health.ToString() + "/" +  maxHealth.ToString() ;
	}

	public void setHealth(float x)
	{
		health = x;
	}

	public float getHealth()
	{
		return health;
	}
	public void setMaxHealth(float x)
	{
		maxHealth = x;
	}

	public float getMaxHealth()
	{
		return maxHealth;
	}
	
}
