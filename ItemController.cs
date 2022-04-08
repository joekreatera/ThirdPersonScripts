using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int keyId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("ReceiveKey", keyId , SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }
}
