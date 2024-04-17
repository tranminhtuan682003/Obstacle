using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatformPatrol : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    private float startPosition;
    

    void Start()
    {
        startPosition = transform.position.x;
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 position = transform.position;
        position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        transform.position = position;
        if (position.x < startPosition - distance || position.x > startPosition + distance)
        {
            speed = -speed;
        }

    }
}
