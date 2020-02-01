using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    //Implementation of the singleton programming pattern
    //Allows instance of script to be accessed globally with GameStateManager.Instance
    //And forcing single active instance of this script in runtime
    private static GameStateManager instance;
    public static GameStateManager Instance;


    void Awake()
    {
        //Set this as the instance of the manager
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
