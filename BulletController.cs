using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 5);
    }


    public void SelfDestroy() {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        CancelInvoke("SelfDestoy");
        Destroy(this.gameObject);
    }
}
