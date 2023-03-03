using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    
    public GunStations gunStations;
    public PlayerUI playerUi;

    public GameObject pistol;
    public GameObject shotgun;

    public Button swapButton;


    // Start is called before the first frame update
    void Start()
    {
        swapButton.gameObject.SetActive(false);
        pistol.SetActive(false);
        shotgun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gunStations.pistolBought == true && gunStations.shotgunBought == true)
        {
            swapButton.gameObject.SetActive(true);
        }
        else
        {
            swapButton.gameObject.SetActive(false);
        }
    }

    public void WeaponSwitching()
    {
        if(gunStations.pistolBought == true && gunStations.shotgunBought == true && shotgun.activeSelf == true)
        {
            pistol.SetActive(true);
            
            shotgun.SetActive(false);

            playerUi.SetPistolAmmo();
        }
        else if(gunStations.pistolBought == true && gunStations.shotgunBought == true && pistol.activeSelf == true)
        {
            pistol.SetActive(false);

            shotgun.SetActive(true);

            playerUi.SetShotgunAmmo();
        }
    }
}
