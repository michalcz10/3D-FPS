using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    [SerializeField] private GameObject bulletHolePrefab;
    public float damage;
    public float bulletRange;
    private Transform playerCam;

    public AudioSource audioSource;
    public AudioClip gunShot;
    void Start()
    {
        playerCam = Camera.main.transform;
    }
    public void Shoot()
    {
        Ray gunRay = new Ray(playerCam.position, playerCam.forward);
        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            if(hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= damage;
            }
            else 
            {
                GameObject obj = Instantiate(bulletHolePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                obj.transform.position += obj.transform.forward / 1000;
            }
        }

        audioSource.PlayOneShot(gunShot);
    }
}
