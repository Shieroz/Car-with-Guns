using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;
    public Rigidbody rb;

    public GameObject explosionEffect;

    float rangeTimer = Pprop.turnRate["Msle"];
    float launchTimer = 0.2f;

    //Remember to call this everytime spawning a new 
    public void setTarget(Transform t)
    {
        target = t;
    }

    void FixedUpdate()
    {
        if (rangeTimer <= 0)
        {
            Explode();
        }
        else
        {
            rangeTimer -= Time.fixedDeltaTime;
        }


        if (launchTimer <= 0)
        {
            rb.velocity = transform.forward * Pprop.speed["Msle"];
            Quaternion missileRotation = Quaternion.LookRotation(target.position - transform.position);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, missileRotation, Pprop.turnRate["Msle"]));
        }
        else
        {
            rb.velocity = transform.up * Pprop.speed["Msle"] * 0.5f;
            launchTimer -= Time.fixedDeltaTime;
        }
    }

    //Explode on impact
    private void OnTriggerEnter(Collider other)
    {
        Explode();
    }

    void Explode()
    {
        GameObject e = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(e, 2f);
        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(transform.position, Pprop.radius["Msle"]);

        foreach (Collider other in colliders)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Pprop.force["Msle"], transform.position, Pprop.radius["Msle"]);
            }
            //Add damage

            //Write a destructible class
        }
        
    }
}
