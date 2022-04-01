using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Range(0.01f, 10f)]
    public float turnMultiplier = 1;

    CharacterController controller;
    float fallingTime = 0.0f;
    float v0y = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    bool IsGrounded() {

        Ray r = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;

        bool crashed = Physics.Raycast(r, out hit, 1.2f);

        if (crashed) {
            return true;
        }

        return false;

    }

    float ApplyGravity(float t, float v0y) {

        return v0y + Physics.gravity.y*.5f * t;

    }

    // Update is called once per frame
    void Update()
    {

       
        this.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * turnMultiplier);
        Vector3 rot = this.transform.eulerAngles;  
        bool c = IsGrounded();
        float vy = 0;
        bool doJump = false;
        if (Input.GetButtonDown("Jump")) {
            v0y = 1;
            doJump = true;
        }
        if (!c || doJump)
        {
            fallingTime += Time.deltaTime;
            vy = ApplyGravity(fallingTime, v0y);
        }
        else {
            fallingTime = 0;
            v0y = 0;
        }
        Vector3 dir = this.transform.TransformDirection(Vector3.forward)*.6f * Input.GetAxis("Vertical");
        dir.y = vy;
        controller.Move(dir);
    }
}
