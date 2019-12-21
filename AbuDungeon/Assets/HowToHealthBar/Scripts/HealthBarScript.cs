using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
	[SerializeField]
	public  float health;

	Image WhitePixel;
    private float maxHealth = 100f;
    public GameObject bar;
    

	void Start ()
	{
		WhitePixel = bar.GetComponent<Image>();
		health = maxHealth;
	}

	void Update()
	{
		WhitePixel.fillAmount = health / maxHealth;
	}

	public void setHealth(float x)
	{
		health = x;
	}

	public float getHealth()
	{
		return health;
	}
}
