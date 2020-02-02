using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public Wall wall;
    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount -= (wall.health/100);
    }


}
