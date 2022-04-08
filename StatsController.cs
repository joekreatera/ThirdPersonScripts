using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public Image lifeImage;
    float life;
    public float MAX_LIFE = 100;
    public bool isBillboard;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        life = MAX_LIFE;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public float GetLife() {
        return life;
    }

    public void Update()
    {
        if (isBillboard) {
            lifeImage.gameObject.transform.LookAt(player.transform.position);
        }
    }

    public void ReceiveDamage(float d) {
        life = Mathf.Max(0, life - d);
        float pctLife = life / MAX_LIFE;

        lifeImage.fillAmount = pctLife;
        lifeImage.color = (Color.green*pctLife  +  Color.red*(1-pctLife));
    }

}
