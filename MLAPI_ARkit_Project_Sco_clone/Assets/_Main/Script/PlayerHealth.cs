using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkedVar;

public class PlayerHealth : MonoBehaviour
{
    public  NetworkedVarFloat health = new NetworkedVarFloat(100f);

    
    public void TakeDamage(float damage)
    {
        health.Value -= damage;
    } 
}
