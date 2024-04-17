using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapFalling : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform player;
    public Transform trapfalling;
    [SerializeField] private float distance;
    bool isIn;

    private void Awake()
    {
    }
    void Start()
    {

    }

    void Update()
    {
        TrapManager.instance.TrapFalling(player, trapfalling, speed, distance, ref isIn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }
}
