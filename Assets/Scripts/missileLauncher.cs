using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileLauncher : MonoBehaviour
{
    public Transform spawn, main;
    public GameObject missile;
    public float cooldown;
    public GameObject hatch;
    Animator anim;

    private void Start()
    {
        anim = hatch.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(main.position, main.forward, out hit))
            {
                if (hit.transform != null)
                {
                    if (cooldown <= 0)
                    {
                        anim.SetTrigger("LaunchMissile");
                        cooldown = 0.35f;

                        GameObject tar = new GameObject();
                        tar.transform.SetParent(hit.transform);
                        tar.transform.position = hit.point;

                        StartCoroutine(Launch(tar.transform));

                        Destroy(tar, 10f);
                    }
                }
            }
        }
        
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    IEnumerator Launch(Transform target)
    {
        yield return new WaitForSeconds(0.1f);
        GameObject m1 = Instantiate(missile, spawn.position, spawn.rotation);
        m1.GetComponent<Missile>().setTarget(target);
    }
}
