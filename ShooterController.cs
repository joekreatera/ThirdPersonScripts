using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject originalBullet;
    public GameObject bulletOrigin;
    GameObject player;

    public bool isPlayerController;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
    }
    public void Shoot() {

        GameObject bullet = Instantiate(originalBullet.gameObject, bulletOrigin.transform.position, Quaternion.identity);
        Rigidbody body = bullet.GetComponent<Rigidbody>();
        Vector3 dir = player.transform.TransformDirection(Vector3.forward);
        body.AddForce(dir * 20, ForceMode.Impulse);
    }
    public void Update()
    {
        if (isPlayerController) {
            if (Input.GetButtonDown("Fire1")) {
                Shoot();
            }
        }
    }

}
