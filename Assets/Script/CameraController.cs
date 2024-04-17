using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    public float smothTime;
    public Vector3 positionOfset;
    [Header("Axit Limition")]
    public Vector2 xlimit;
    public Vector2 ylimit;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("CameraFollow").transform;
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + positionOfset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xlimit.x, xlimit.y), Mathf.Clamp(targetPosition.y, ylimit.x, ylimit.y),-10);
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity, smothTime);
    }
}
