 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform bulletSpawner;

    private float maxAmmo = 16;
    private float minAmmo = 0;
    private float currentAmmo;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float timeBtwReload;
    
    public float pistolDamage = 5;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public void Shoot()
    {
        if(timeBtwShots <= 0 && currentAmmo > minAmmo)
        {
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            timeBtwShots = startTimeBtwShots;
            //currentAmmo -= 1;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;

        }
        

    }

    



}
