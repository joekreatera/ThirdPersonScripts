using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum STATE {
        CLOSED,
        OPENING,
        OPENED,
        CLOSING
    };

    public STATE state;

    public Vector3 originalPosition;
    public Vector3 finalPosition;
    private float animTime = 0.0f;
    public float ANIMATION_TIME = 2; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(originalPosition, Vector3.one*2);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(finalPosition, Vector3.one*2);

    }

    public void Open() {
        this.state = STATE.OPENING;
    }

    public void Close()
    {
        this.state = STATE.CLOSING;
    }

    // Update is called once per frame
    void Update()
    {
        if(  state == STATE.CLOSED) {
            animTime = 0;
        }

        if (state == STATE.OPENING) {
            animTime += Time.deltaTime;
            float pct = animTime / ANIMATION_TIME;

            if (pct >= 1) {
                pct = 1;
                state = STATE.OPENED;
            }

            float h = Mathf.Sin(Mathf.PI*0.5f*pct); 
            this.transform.position = originalPosition + (finalPosition - originalPosition) * h;
        }

        if (state == STATE.OPENED) {
            animTime = ANIMATION_TIME;
        }

        if (state == STATE.CLOSING) {
            animTime -= Time.deltaTime;
            float pct = animTime / ANIMATION_TIME;

            if (pct <= 0)
            {
                pct = 0;
                state = STATE.CLOSED;
            }
            //float h = Mathf.Sin(Mathf.PI * 0.5f * pct);
            float h = Mathf.Pow(pct*1.59f-0.8f,3) + 0.5f;
            this.transform.position = originalPosition + (finalPosition - originalPosition) * h;
        }
    }
}
