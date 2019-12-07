using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public int gunType; //0 for projectile, 1 for plasma
    public int gunNumbers;

    public Transform main;
    public float gunRange;

    public GameObject bulletPrefab;
    public GameObject laserPrefab;

    public Transform bulletSpawn;
    public Material mat;
    public GameObject muzzleFlash;

    // Update is called once per frame
    void LateUpdate()
    {
        // Control where the gun point at
        RaycastHit hit;
        if (Physics.Raycast(main.position, main.forward, out hit, gunRange))
        {
            // If the gun can hit something within range then point at it
            if (hit.transform != transform)
                transform.LookAt(hit.point);
        }
        Vector3 target = hit.point;

        if (hit.collider == null)
        {
            // Else point at the max range of the gun
            target = main.position + main.forward * 1000f;
            transform.LookAt(target);
        }

        weaponSelect();

        if (Input.GetButtonDown("Fire1"))
        {
            switch (gunType)
            {
                case 1:
                    ShootProjectile(target);
                    GameObject mF = Instantiate(muzzleFlash, bulletSpawn.position, transform.rotation);
                    Destroy(mF, 0.25f);
                    break;
                case 2:
                    ShootPlasma(target);
                    break;
            }
        }
    }

    void weaponSelect()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            gunType -= 1;
        else if (Input.GetKeyDown(KeyCode.E))
            gunType += 1;

        if (gunType > gunNumbers)
            gunType = 1;
        else if (gunType == 0)
            gunType = gunNumbers;
    }

    void ShootProjectile(Vector3 target)
    {
        GameObject B = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        B.GetComponent<Rigidbody>().velocity = (target - bulletSpawn.position).normalized * Pprop.speed["Proj"];
    }

    void ShootPlasma(Vector3 target)
    {
        GameObject P = Instantiate(laserPrefab, bulletSpawn.position, transform.rotation);
        P.GetComponent<Rigidbody>().velocity = (target - bulletSpawn.position).normalized * Pprop.speed["Plsm"];
    }
}
