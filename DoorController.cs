using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public int keyId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player inside" + other.gameObject);
        InventoryController inventory = other.gameObject.GetComponent<InventoryController>();

        if (inventory != null) {
            bool doOpen = inventory.GetKey(keyId);
            if (doOpen) { 
                Destroy(this.gameObject.transform.GetChild(0).gameObject);
            }
        }
    }
    
}
