using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public static TrapManager instance;
    //traphide
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Another instance of TrapManager already exists.");
            Destroy(this.gameObject);
        }
    }
    public void TrapFalling(Transform player,Transform otherTrapFalling ,float speed,float distance,ref bool isIn)
    {
        if (player != null)
        {
            if (otherTrapFalling.position.x - distance <= player.position.x && player.position.x <= otherTrapFalling.position.x + distance)
            {
                isIn = true;
            }
            if(isIn == true)
            {
                otherTrapFalling.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
            }
        }
    }
    public void TrapDestroy()
    {

    }
}
