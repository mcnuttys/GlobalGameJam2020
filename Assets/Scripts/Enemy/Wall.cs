using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public float health;

    private float maxHealth = 100.0f;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        healthBar.fillAmount = 1f;
    }

    void Update()
    {
        if(health > 100)
        {
            health = maxHealth;
        }

    }


    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<BaseEnemy>())
        {
            health -= 10;

            healthBar.fillAmount -= 0.001f;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<BaseEnemy>())
        {
            health -= 10;
            healthBar.fillAmount -= 0.001f;
        }
    }

}
