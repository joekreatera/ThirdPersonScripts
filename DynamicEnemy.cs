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

    float attackTimer = 0.0f;
    public float ATTACK_TIME = 2.0f;
    StatsController stats;

    public Animator animationController;

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
        stats = this.GetComponent<StatsController>();
    }

    public void UpdateState() {
        if (stats != null) {
            if (stats.GetLife() <= 0) {
                state = STATE.DEAD;
            }
        }
    }

    void Shoot() {
        shooter.Shoot();
        Invoke("Shoot", 3);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, CHASE_DISTANCE);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(this.transform.position, ATTACK_DISTANCE);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        if (state == STATE.IDLE) {
            Vector3 distance = player.transform.position - this.transform.position;
            animationController.SetFloat("MoveSpeed", 0.0f);
            animationController.SetBool("OnAttack", false);
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
            animationController.SetFloat("MoveSpeed", 1.0f);
            animationController.SetBool("OnAttack", false);

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

            // animationController.SetFloat("MoveSpeed", 0.0f);
            animationController.SetBool("OnAttack", true);

            Vector3 posToLook = player.transform.position;
            posToLook.y = this.transform.position.y;
            this.transform.LookAt(posToLook);

            Vector3 distance = player.transform.position - this.transform.position;


            if (attackTimer >= ATTACK_TIME) {
                player.SendMessage("ReceiveDamage", 2);
                attackTimer = 0.0f;
            }
            attackTimer += Time.deltaTime;

            if (distance.magnitude > ATTACK_DISTANCE)
            {
                state = STATE.CHASING;
                Shoot();
            }
        }

        if (state == STATE.DEAD) {
            animationController.SetTrigger("IsDead");
        }
        
    }
}
