using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public PlayerUI playerUi;
    public GunStations gunStations;
    public Enemy enemy;

    public GameObject pelletPrefab;
    public Transform shotgunBulletSpawner1;
    public Transform shotgunBulletSpawner2;
    public Transform shotgunBulletSpawner3;

    public float maxAmmoCapacity = 32;
    public float minAmmoCapacity = 0;
    public float currentAmmoCapacity;
    public float maxAmmoClip = 16;
    public float minAmmoClip = 0;
    public float currentAmmoClip;

    public float shotgunCurrencyPerHit = 5f;

    public float reloadTime = .5f;

    public float shotgunDamage = 15;

    public bool isReloading = false;

    public Button shootButton;

    // Start is called before the first frame update
    void Start()
    {
        shootButton.gameObject.SetActive(true);

        currentAmmoClip = maxAmmoClip;
        currentAmmoCapacity = maxAmmoCapacity;
        playerUi.SetShotgunAmmo();
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
        Debug.Log("ButtonWorks");
        if (currentAmmoClip > minAmmoClip && currentAmmoCapacity >= minAmmoCapacity && gunStations.shotgunBought == true && isReloading == false)
        {
            
            Instantiate(pelletPrefab, shotgunBulletSpawner1.position, shotgunBulletSpawner1.rotation);
            Instantiate(pelletPrefab, shotgunBulletSpawner2.position, shotgunBulletSpawner2.rotation);
            Instantiate(pelletPrefab, shotgunBulletSpawner3.position, shotgunBulletSpawner3.rotation);
            

            currentAmmoClip -= 1;
            playerUi.SetShotgunAmmo();
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
        playerUi.SetShotgunAmmo();
    }

    public void ReloadTimerReset()
    {
        reloadTime = .5f;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.enemy1CurrentHealth -= shotgunDamage;
        }
    }*/

}
