using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code written by Ethan Ruhl
/// </summary>
public class DefendablePoints : MonoBehaviour, ITakeDamage
{
    #region Fields
    private int health = 0;

    #endregion

    #region Methods
    /// <summary>
    /// Called when the objects health is reduced to 0
    /// </summary>
    public void Death()
    {
        Destroy(this.gameObject);
    }


    /// <summary>
    /// Updates the health of the defense point, checks death condition
    /// </summary>
    /// <param name="damageTaken">The amount of damage the defense point should take</param>
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if(health <= 0)
        {
            Death();
        }
    }
    #endregion
}
