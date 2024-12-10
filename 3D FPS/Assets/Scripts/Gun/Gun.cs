using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunShoot;
    public float fireCoolDown;
    public bool automatic;
    public int ammo;
    public float reloadCooldown;
    

    private float currentCooldown;
    private float currentReloadCooldown;
    private int currAmmo;

    public AudioSource audioSource;
    public AudioClip reloadSound;

    public TextMeshProUGUI ammoTxt;

    void Start()
    {
        currentCooldown = fireCoolDown;
        currAmmo = ammo;
        ammoTxt.text = currAmmo.ToString() + "/" + ammo.ToString();
    }


    void Update()
    {
        if(automatic)
        {
            if(Input.GetMouseButton(0))
            {
                if(currentCooldown <= 0f && currentReloadCooldown <= 0f && currAmmo != 0)
                {
                    //if not null (?)
                    onGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                    currAmmo--;
                    ammoTxt.text = currAmmo.ToString() + "/" + ammo.ToString();
                }
            }
        }
        else 
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(currentCooldown <= 0f && currentReloadCooldown <= 0f && currAmmo != 0)
                {
                    //if not null (?)
                    onGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                    currAmmo--;
                    ammoTxt.text = currAmmo.ToString() + "/" + ammo.ToString();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(currentReloadCooldown <= 0f)
            {
                currAmmo = ammo;
                currentReloadCooldown = reloadCooldown;
                audioSource.PlayOneShot(reloadSound);

                ammoTxt.text = currAmmo.ToString() + "/" + ammo.ToString();
            }
        }

        currentCooldown -= Time.deltaTime;

        currentReloadCooldown -= Time.deltaTime;
    }
}
