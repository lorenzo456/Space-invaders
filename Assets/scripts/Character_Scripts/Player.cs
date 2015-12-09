using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {

    public override void Start()
    {
        base.Start();
        speed = 4;
		currentWeapon = 0;
        hp = 3;
    }

    void WeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentWeapon < Weapons.Count -1)
        {
            currentWeapon = currentWeapon + 1;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentWeapon > 0 )
        {
            currentWeapon = currentWeapon - 1;
        }

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
        bulletSpawn = this.gameObject.transform.GetChild(0).GetComponent<Transform>().position;

        if (Input.GetButtonDown ("Jump") && reloaded == true) {
			Instantiate (Weapons [currentWeapon], bulletSpawn, transform.rotation);
            reloadTime = .2f;
		}
    }

    public override void Update()
    {
        base.Update();
        WeaponSwitch();
    }
}
