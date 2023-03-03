 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    public Player player;
    public PlayerUI playerUi;
    public GunStations gunStations;
    public Enemy enemy;


    public GameObject bulletPrefab;
    public Transform bulletSpawner;

    public float maxAmmoCapacity = 32;
    public float minAmmoCapacity = 0;
    public float currentAmmoCapacity;
    public float maxAmmoClip = 16;
    public float minAmmoClip = 0;
    public float currentAmmoClip;

    public float pistolCurrencyPerHit = 20f;

    public float reloadTime = .5f;


    public float pistolDamage = 25f;

    public bool isReloading = false;

    public Button shootButton;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmoClip = maxAmmoClip;
        currentAmmoCapacity = maxAmmoCapacity;
        playerUi.SetPistolAmmo();

        shootButton.gameObject.SetActive(true);

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
        if (currentAmmoClip > minAmmoClip && currentAmmoCapacity >= minAmmoCapacity && gunStations.pistolBought == true && isReloading == false)
        {
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);

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
    }

    


}

    




