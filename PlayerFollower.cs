using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    GameObject player;
    public float horDistanceToPlayer = 5;
    public float verDistanceToPlayer = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

       Vector3 pos = player.transform.position;
        Vector3 playerDir = player.transform.TransformDirection(Vector3.forward);     
        Vector3 newPos = pos - horDistanceToPlayer * playerDir;
        newPos += new Vector3(0, verDistanceToPlayer, 0);
        this.transform.position = newPos;
        this.transform.LookAt(player.transform.position);

    }
}
