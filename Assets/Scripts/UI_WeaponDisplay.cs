using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponDisplay : MonoBehaviour
{
    Text Display_Weapon;

    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        Display_Weapon = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int type = weapon.GetComponent<GunControl>().gunType;
        switch (type)
        {
            case 1:
                Display_Weapon.text = "Projectile";
                break;
            case 2:
                Display_Weapon.text = "Plasma";
                break;
        }
    }
}
