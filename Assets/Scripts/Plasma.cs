using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Plasma : MonoBehaviour
{
    Vector3 target;
    float range, damage;

    void Start()
    {
        damage = Pprop.damage["Plsm"];
        range = Pprop.range["Plsm"];
    }

    void Update()
    {
        range -= Time.deltaTime;
        if (range <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Maybe add refractive properties too?
        Hit();
    }

    void Hit()
    {
        Destroy(gameObject);
        //Do damage
    }
}
