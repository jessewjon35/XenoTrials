using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [HideInInspector]
    public GunStations gunStations;
    public PlayerUI playerUi;

    public GameObject pistol;
    public GameObject shotgun;
    

    // Start is called before the first frame update
    void Start()
    {
        
        pistol.SetActive(false);
        shotgun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WeaponSwitching()
    {
        if(gunStations.pistolBought && gunStations.shotgunBought == true && shotgun.activeSelf == true)
        {
            pistol.SetActive(true);
            
            shotgun.SetActive(false);

            playerUi.SetPistolAmmo();
        }
        else if(gunStations.pistolBought && gunStations.shotgunBought == true && pistol.activeSelf == true)
        {
            pistol.SetActive(false);

            shotgun.SetActive(true);
            playerUi.SetShotgunAmmo();
        }
    }
}
