using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkedVar;
using MLAPI.Messaging;
using System;

public class PlayerShooting : NetworkedBehaviour
{
    public ParticleSystem bulletParticleSystem;
    private ParticleSystem.EmissionModule em;

    NetworkedVarBool shooting = new NetworkedVarBool(new NetworkedVarSettings { 
        WritePermission = NetworkedVarPermission.OwnerOnly
    }, false);
    //bool shooting = false;
    float fireRate = 10f;
    float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        em = bulletParticleSystem.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            shooting.Value = Input.GetMouseButton(0);
            shootTimer += Time.deltaTime;
            if (shooting.Value && shootTimer >= 1f/fireRate)
            {
                shootTimer = 0;
                //call our method
                InvokeServerRpc(Shoot);
            }
        }

        em.rateOverTime = shooting.Value ? 10f : 0f;

    }
    [ServerRPC]
    private void Shoot()
    {
        Ray ray  = new Ray(bulletParticleSystem.transform.position,bulletParticleSystem.transform.forward);
        if(Physics.Raycast(ray,out RaycastHit hit, 100f))
        {
            //we hit something
            var player = hit.collider.GetComponent<PlayerHealth>();
            if(player != null)
            {
                //we hit a player
                player.TakeDamage(10f);
            }
        }
    }
}
