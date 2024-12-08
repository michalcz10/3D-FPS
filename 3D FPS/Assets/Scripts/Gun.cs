using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunShoot;
    public float fireCoolDown;
    public bool automatic;
    

    private float currentCooldown;


    void Start()
    {
        currentCooldown = fireCoolDown;
    }


    void Update()
    {
        if(automatic)
        {
            if(Input.GetMouseButton(0))
            {
                if(currentCooldown <= 0f)
                {
                    //if not null (?)
                    onGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                }
            }
        }
        else 
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(currentCooldown <= 0f)
                {
                    //if not null (?)
                    onGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                }
            }
        }

        currentCooldown -= Time.deltaTime;
    }
}
