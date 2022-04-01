using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public Image lifeImage;
    float life;
    public float MAX_LIFE = 100;
    // Start is called before the first frame update
    void Start()
    {
        life = MAX_LIFE;
    }

    public void ReceiveDamage(float d) {
        life = Mathf.Max(0, life - d);
        float pctLife = life / MAX_LIFE;

        lifeImage.fillAmount = pctLife;
        lifeImage.color = (Color.green*pctLife  +  Color.red*(1-pctLife));
    }

}
