using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    int[] keys = new int[10];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < keys.Length; i++) {
            keys[i] = 0;
        }
    }

    public void ReceiveKey(int key) {
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] == 0){
                keys[i] = key;
                return;
            }
        }
    }

    public bool GetKey(int key)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] == key)
            {
                keys[i] = 0;
                return true;
            }
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
