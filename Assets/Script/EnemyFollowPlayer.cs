using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private GameObject player;
    private bool haslineofsight = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player2");
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);
        if (ray.collider != null)
        {
            haslineofsight = ray.collider.CompareTag("player2");
            if (haslineofsight)
            {
                Debug.DrawLine(transform.position, player.transform.position, Color.red);
            }
            else
            {
                Debug.DrawLine(transform.position, player.transform.position, Color.green);
            }
        }
    }

}
