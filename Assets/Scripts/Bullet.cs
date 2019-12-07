using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float range, force, damage;

    private void Start()
    {
        range = Pprop.range["Proj"];
        force = Pprop.force["Proj"];
        damage = Pprop.damage["Proj"];
    }
    // Update is called once per frame
    void Update()
    {
        range -= Time.deltaTime;
        if (range <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * force);
        }

        //Add damage
    }

}
