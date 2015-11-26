using UnityEngine;
using System.Collections;

public class Player : Character {

    public float playerX;
    public float playerZ;


    public override void Start()
    {
        base.Start();
        speed = 4;
		currentWeapon = 0;
    }

  

    public override void Move()
    {
        base.Move();
        float playerX = Input.GetAxis("Horizontal");
        float playerZ = Input.GetAxis("Vertical");

        Collision();
        if (colDown == true && playerZ < 0)
        {
            playerZ = 0;
        }
        else if (colUp == true && playerZ > 0)
        {
            playerZ = 0;
        }

        if (colLeft == true && playerX < 0)
        {
            playerX = 0;
        }
        else if (colRight == true && playerX > 0)
        {
            playerX = 0;
        }

        if (Input.GetButton("Horizontal"))
        {

            this.transform.position += new Vector3(playerX / speed, 0, 0);
        }
        else if (Input.GetButton("Vertical"))
        {
            this.transform.position += new Vector3(0, 0, playerZ / speed);
        }
        
    }


    public override void Shoot()
    {
        base.Shoot();
        if (Input.GetButtonDown ("Fire1")) {
			Instantiate (Weapons [currentWeapon], transform.position, transform.rotation);
		} 
    }

    public override void Die()
    {
        base.Die();
    }

}
