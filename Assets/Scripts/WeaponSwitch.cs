using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSwitch : MonoBehaviour
{
    
    public GunStations gunStations;
    public PlayerUI playerUi;
    

    public GameObject pistol;
    public GameObject shotgun;

    public Button swapButton;

    public TMP_Text pistolAmmoText;
    public TMP_Text shotgunAmmoText;

    public bool pistolBought;
    public bool shotgunBought;


    // Start is called before the first frame update
    void Start()
    {
        pistolBought = false;
        shotgunBought = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void SwapEnabledCheck()
    {
        if(pistol.activeSelf == true)
        {
            pistolBought = true;
        }
        else if(shotgun.activeSelf == true)
        {
            shotgunBought = true;
        }

        if(pistolBought == true && shotgunBought == true)
        {
            swapButton.gameObject.SetActive(true);
        }
    }

    public void WeaponSwitching()
    {
        if(shotgun.activeSelf == true)
        {
            pistol.SetActive(true);
            
            shotgun.SetActive(false);

            pistolAmmoText.enabled = true;
            shotgunAmmoText.enabled = false;

            //playerUi.SetPistolAmmo();
           
            
        }
        else if(pistol.activeSelf == true)
        {
            pistol.SetActive(false);

            shotgun.SetActive(true);

            pistolAmmoText.enabled = false;
            shotgunAmmoText.enabled = true;

           // playerUi.SetShotgunAmmo();
            
        }

        
    }
}
