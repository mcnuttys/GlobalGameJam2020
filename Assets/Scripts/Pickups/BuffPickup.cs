using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPickup : MonoBehaviour
{
    [SerializeField] private Buff buffToPickup;
    public Buff BuffToPickup { get { return buffToPickup; } }

    void Awake()
    {
        this.tag = "BuffPickup";
    }
}
