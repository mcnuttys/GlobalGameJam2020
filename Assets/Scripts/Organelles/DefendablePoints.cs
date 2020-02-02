using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code written by Ethan Ruhl
/// </summary>
public class DefendablePoints : MonoBehaviour, ITakeDamage
{
    #region Fields
    [SerializeField]private int maxHealth = 1;
    public int health = 0;
    public AudioSource damageOrganelle;

    public Sprite[] healthStates;

    public SpriteRenderer displaySprite;

    #endregion

    #region Methods
    private void Start()
    {
        health = maxHealth;

        for (int i = 0; i < healthStates.Length; i++)
        {
            float iPercent = ((float)i / (float)healthStates.Length) * (float)maxHealth;

            if (health > iPercent)
                displaySprite.sprite = healthStates[i];
        }
    }

    public void Update()
    {

        for (int i = 0; i < healthStates.Length; i++)
        {
            float iPercent = ((float)i / (float)healthStates.Length) * (float)maxHealth;

            if (health > iPercent)
                displaySprite.sprite = healthStates[i];
        }
    }

    /// <summary>
    /// Called when the objects health is reduced to 0
    /// </summary>
    public void Death()
    {
        damageOrganelle.Play();
        Destroy(gameObject, .1f);
    }


    /// <summary>
    /// Updates the health of the defense point, checks death condition
    /// </summary>
    /// <param name="damageTaken">The amount of damage the defense point should take</param>
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            damageOrganelle.Play();
            Death();
        }
    }

    /// <summary>
    /// Restores health of the defense point, unless it's already at max health
    /// </summary>
    /// <param name="healthRestored">The amount of health to restore</param>
    public void Repair(int healthRestored)
    {
        if (health < maxHealth)
        {
            health += healthRestored; 
        }
    }

    public float GetHealth()
    {
        return health;
    }
    #endregion
}
