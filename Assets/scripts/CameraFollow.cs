using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position; 
        offset.y = 0;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z) + offset, Time.deltaTime * 3);
    }
}
