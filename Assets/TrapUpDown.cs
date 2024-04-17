using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapUpDown : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float pointTranform;
    [SerializeField] private float timeDelay;
    private float startPosition;

    void Start()
    {
        startPosition = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitDelay());
    }
    private void Move()
    {
        Vector3 position = transform.position;
        float topLimit = startPosition + pointTranform;
        transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        if (position.y >= topLimit)
        {
            speed = -Mathf.Abs(speed);
        }
        if (position.y <= startPosition)
        {
            speed = Mathf.Abs(speed);
        }
        position = transform.position;
    }
    IEnumerator WaitDelay()
    {
        yield return new WaitForSeconds(timeDelay);
        Move();
    }
}
