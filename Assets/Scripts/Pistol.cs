 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    
    /*public PlayerUI playerUi;
    public GunStations gunStations;
    public Enemy enemy;
    public WeaponSwitch weaponSwitch;
    public Shotgun shotgunScript;
    

    public GameObject pistol;
    public GameObject shotgun;

    public GameObject bulletPrefab;
    public Transform bulletSpawner;

    public ParticleSystem pistolShootingEffect;

    public int maxAmmoCapacity = 32;
    public int minAmmoCapacity = 0;
    public int currentAmmoCapacity;
    public int maxAmmoClip = 16;
    public int minAmmoClip = 0;
    public int currentAmmoClip;

    public int pistolCurrencyPerHit = 20;

    public float reloadTime = .5f;


    public int pistolDamage = 25;

    public bool isReloading = false;
    

    


    // Start is called before the first frame update
    void Start()
    {
        currentAmmoClip = maxAmmoClip;
        currentAmmoCapacity = maxAmmoCapacity;
        playerUi.SetPistolAmmo();

        


    }

    // Update is called once per frame
    void Update()
    {

        if (currentAmmoClip <= minAmmoClip && currentAmmoCapacity > minAmmoCapacity)
        {
            isReloading = true;
        }

        if (isReloading == true)
        {
            ReloadTimer();
        }

        if (reloadTime <= 0)
        {
            Reload();
            ReloadTimerReset();
            isReloading = false;
        }

        if (currentAmmoCapacity <= minAmmoCapacity)
        {
            currentAmmoCapacity = minAmmoCapacity;
        }
        else if (currentAmmoCapacity >= maxAmmoCapacity)
        {
            currentAmmoCapacity = maxAmmoCapacity;
        }

        

    }

    public void Shoot()
    {
        
        if (pistol.activeSelf == true && currentAmmoClip > minAmmoClip && currentAmmoCapacity >= minAmmoCapacity && weaponSwitch.pistolBought == true && isReloading == false)
        {
            
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);

            pistolShootingEffect.Play();

            currentAmmoClip -= 1;
            playerUi.SetPistolAmmo();
            
        }
       
        

    }

    public void ReloadTimer()
    {
        reloadTime -= Time.deltaTime;
    }

    public void Reload()
    {
        currentAmmoClip = maxAmmoClip;
        currentAmmoCapacity -= maxAmmoClip;
        playerUi.SetPistolAmmo();
    }

    public void ReloadTimerReset()
    {
        reloadTime = .5f;
    }*/

    


}

    




