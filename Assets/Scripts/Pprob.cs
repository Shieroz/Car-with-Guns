using System.Collections;
using System.Collections.Generic;

public static class Pprop
{
    //Weapon damage
    public static Dictionary<string, float> damage = new Dictionary<string, float> {
        {"Proj", 20f},
        {"Plsm", 13f},
        {"Msle", 100f}
     };
    
    //Tick time for DoT weapons
    public static Dictionary<string, float> tick = new Dictionary<string, float>{
        {"Plsm", 0.1f}
     };

    //Projectile speed
    public static Dictionary<string, float> speed = new Dictionary<string, float>{
        {"Proj", 50f},
        {"Plsm", 100f},
        {"Msle", 25f}
     };

    //Weapon range
    public static Dictionary<string, float> range = new Dictionary<string, float>{
        {"Proj", 7f},
        {"Plsm", 5f},
        {"Msle", 10f}
     };

    //Impact force
    public static Dictionary<string, float> force = new Dictionary<string, float>{
        {"Proj", 500f},
        {"Msle", 1200f}
     };
    
    //Turn rate for homing projectiles
    public static Dictionary<string, float> turnRate = new Dictionary<string, float>{
        {"Msle", 6f}
     };

    //Impact radius
    public static Dictionary<string, float> radius = new Dictionary<string, float>{
        {"Msle", 4f}
     };
}
