using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public Vector3 minValue, maxValue;

    [SerializeField] private Transform target;

    private void Start()
    {
        Follow();
    }
    private void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 boundPosition = new Vector3(Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x), Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y), Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothTime * Time.fixedDeltaTime);

        transform.position = smoothPosition;
    }
}
