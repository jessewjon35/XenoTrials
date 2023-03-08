using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public PlayerUI playerUi;
    public GunStations gunStations;
    public Enemy enemy;
    public WeaponSwitch weaponSwitch;
    public Pistol pistolScript;

    public GameObject pistol;
    public GameObject shotgun;


    public GameObject pelletPrefab;
    public Transform shotgunBulletSpawner1;
    public Transform shotgunBulletSpawner2;
    public Transform shotgunBulletSpawner3;

    public ParticleSystem shotgunShootingEffect;

    public int maxAmmoCapacity = 32;
    public int minAmmoCapacity = 0;
    public int currentAmmoCapacity;
    public int maxAmmoClip = 16;
    public int minAmmoClip = 0;
    public int currentAmmoClip;

    public int shotgunCurrencyPerHit = 5;

    public float reloadTime = .5f;

    public int shotgunDamage = 15;

    public bool isReloading = false;

    

    // Start is called before the first frame update
    void Start()
    {
        

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
        
        if (shotgun.activeSelf == true && currentAmmoClip > minAmmoClip && currentAmmoCapacity >= minAmmoCapacity && weaponSwitch.shotgunBought == true && isReloading == false)
        {
            
            Instantiate(pelletPrefab, shotgunBulletSpawner1.position, shotgunBulletSpawner1.rotation);
            Instantiate(pelletPrefab, shotgunBulletSpawner2.position, shotgunBulletSpawner2.rotation);
            Instantiate(pelletPrefab, shotgunBulletSpawner3.position, shotgunBulletSpawner3.rotation);

            shotgunShootingEffect.Play();

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
