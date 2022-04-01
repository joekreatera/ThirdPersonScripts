using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemy : MonoBehaviour
{
    GameObject player;
    ShooterController shooter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shooter = this.GetComponent<ShooterController>();
        Invoke("Shoot",3);
    }

    void Shoot() {
        shooter.Shoot();
        Invoke("Shoot", 3);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform.position);
    }
}
