using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPonit : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            if(goNextLevel)
            {
                SceneManaGer.instance.NextLevel();
            }
            else
            {
                SceneManaGer.instance.LoadScene(levelName);
            }
        }
    }
}
