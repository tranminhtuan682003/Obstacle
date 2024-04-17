using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObject = new List<GameObject>();
    private int amounttoPool = 10;
    [SerializeField] private GameObject prefabbullet;
    private void Awake()
    {
       if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for(int i = 0;i< amounttoPool; i++)
        {
            GameObject obj = Instantiate(prefabbullet);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }
        return null;
    }
}
