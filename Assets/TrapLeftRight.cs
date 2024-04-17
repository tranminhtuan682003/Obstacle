using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLeftRight : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    Vector3 startposition;
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 position = transform.position;
        float limit = startposition.x + distance;
        position.x += speed * Time.deltaTime;
        if(position.x < limit)
        {
            transform.position = startposition;
        }
        transform.position = position;
    }
}
