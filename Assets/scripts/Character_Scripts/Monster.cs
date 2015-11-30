using UnityEngine;
using System.Collections;

public class Monster : Character {

    public int myDirection;

    public override void Start()
    {
        base.Start();
        hp = 3;
        speed = 0.1f;
        myDirection = 1;
        currentWeapon = 0;
        reloadTime =  Random.Range(1f, 5f);
    }
    public override void Move()
    {
        base.Move();

        Collision();

        if (colDown == true && this.transform.position.z < 0)
        {
            
        }
        else if (colUp == true && this.transform.position.z > 0)
        {
            
        }

        if (colLeft == true && this.transform.position.x < 0)
        {
            MoveForward();
            myDirection *= -1;
        }
        else if (colRight == true && this.transform.position.x > 0)
        {
            MoveForward();
            myDirection *= -1;
        }

        this.transform.position += new Vector3(speed, 0, 0) * myDirection;
    }

    public void MoveForward()
    {
        transform.position += new Vector3(0, 0,-2f);
    }

    public override void Shoot()
    {
        base.Shoot();
        bulletSpawn = this.transform.position - new Vector3(0, 0, 2);
     if(reloaded == true)
        {
            Instantiate(Weapons[currentWeapon], bulletSpawn, transform.rotation);
            reloadTime = Random.Range(1f, 5f);

        }

    }
}
