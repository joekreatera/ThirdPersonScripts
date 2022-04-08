using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class DynamicEnemy : MonoBehaviour
{
    GameObject player;
    ShooterController shooter;
    CharacterController controller;
    public float CHASE_DISTANCE = 10;
    public float ATTACK_DISTANCE = 3;

    public enum STATE {
        IDLE,
        CHASING,
        ATTACKING,
        DEAD
    };

    public STATE state;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shooter = this.GetComponent<ShooterController>();
        controller = this.GetComponent<CharacterController>();
        
    }

    void Shoot() {
        shooter.Shoot();
        Invoke("Shoot", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == STATE.IDLE) {
            Vector3 distance = player.transform.position - this.transform.position;
            
            if (distance.magnitude < CHASE_DISTANCE ) {
                state = STATE.CHASING;
                Shoot();
            }
        }

        if (state == STATE.CHASING)
        {
            Vector3 posToLook = player.transform.position;
            posToLook.y = this.transform.position.y;
            this.transform.LookAt(posToLook);
            Vector3 dir = this.gameObject.transform.TransformDirection(Vector3.forward);
            controller.Move(dir * 0.2f);

            Vector3 distance = player.transform.position - this.transform.position;
            

            if (distance.magnitude < ATTACK_DISTANCE)
            {
                state = STATE.ATTACKING;
                CancelInvoke("Shoot");
            }
            if (distance.magnitude > CHASE_DISTANCE)
            {
                state = STATE.IDLE;
                CancelInvoke("Shoot");
            }
        }

        if (state == STATE.ATTACKING) {
            Debug.Log("Im attacking");

            Vector3 distance = player.transform.position - this.transform.position;

            player.SendMessage("ReceiveDamage", 2);

            if (distance.magnitude > ATTACK_DISTANCE)
            {
                state = STATE.CHASING;
                Shoot();
            }
        }

        if (state == STATE.DEAD) {

        }
        
    }
}
