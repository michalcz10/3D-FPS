using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public Transform gunTransform;
    public float recoilDistance = 0.1f;
    public float recoilRotation = 5f;
    public float recoilSpeed = 10f;
    public float recoverySpeed = 5f;

    private Vector3 gunCurrPos;
    private Vector3 gunOriginalPos;
    private Quaternion originalRotation;
    private Vector3 currentRecoilRotation;

    void Start()
    {
        gunOriginalPos = gunTransform.localPosition;
        originalRotation = gunTransform.localRotation;
    }

    void Update()
    {
        gunCurrPos = Vector3.Lerp(gunCurrPos, Vector3.zero, Time.deltaTime * recoverySpeed);
        currentRecoilRotation = Vector3.Lerp(currentRecoilRotation, Vector3.zero, Time.deltaTime * recoverySpeed);

        gunTransform.localPosition = gunOriginalPos + gunCurrPos;
        gunTransform.localRotation = originalRotation * Quaternion.Euler(currentRecoilRotation);
    }

    public void ApplyRecoil()
    {
        gunCurrPos += new Vector3(0, 0, -recoilDistance);
        currentRecoilRotation += new Vector3(-recoilRotation, Random.Range(-recoilRotation / 2, recoilRotation / 2), 0);
    }
}
