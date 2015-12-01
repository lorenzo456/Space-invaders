using UnityEngine;
using System.Collections;

public class Monster : Character {

    public override void Start()
    {
        base.Start();
        hp = 3;
        speed = 0.1f;
        currentWeapon = 0;
        reloadTime =  Random.Range(1f, 5f);
    }

    public override void Move()
    {
        base.Move();

        Collision();

        if (colLeft || colRight)
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
    }
}
