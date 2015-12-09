using UnityEngine;
using System.Collections;

public class Bullet_Lazer : Bullet {


    public override void Start()
    {
        speed = 100;
        spawnTime = 2;
    }

    public override void Move(float mySpeed)
    {
        if (enemy == "Enemy")
        {
            
        }
        else
        {
            mySpeed = -mySpeed;
        }

        transform.localScale += new Vector3(0, 0, mySpeed) * Time.deltaTime;
        transform.position += new Vector3(0, 0, mySpeed) * Time.deltaTime / 2;
    }
}
