using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Camera mainCam;
    public static cameraShake instance;
    float shakeAmount = 0;
    float shakeLength = 0;
    float shakeFade = 0f;

    void Awake()
    {
        instance = this;
        if (mainCam == null)
            mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        if (shakeLength > 0)
        {
            shakeLength -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakeAmount;
            float yAmount = Random.Range(-1f, 1f) * shakeAmount;
            transform.position += new Vector3(xAmount, yAmount, 0f);
            shakeAmount = Mathf.MoveTowards(shakeAmount, 0f, shakeFade * Time.deltaTime);
        }
    }
    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        shakeLength = length;
        shakeFade = amt / length;
    }
}
