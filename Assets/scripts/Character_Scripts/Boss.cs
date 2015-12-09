using UnityEngine;
using System.Collections;

public class Boss : Character {

    public int shootPattern;
    public int phase;

    public override void Start()
    {
        base.Start();
        hp = 25;
        speed = 0.01f;
        currentWeapon = 0;
        phase = 0;
        colDistance = 3;
    }

    public override void Move()
    {
        base.Move();

        if (!colDown)
        {
            this.transform.position += new Vector3(0, 0, -speed);
        }
    }

    void checkBossPattern()
    {
        if (hp > 20)
        {
            switch (phase)
            {
                case 2:
                    currentWeapon = 0;
                    shootPattern = 3;
                    reloadTime = 3f;
                    phase = -1;
                    break;
                case 1:
                    currentWeapon = 0;
                    shootPattern = 2;
                    reloadTime = 3f;
                    break;
                case 0:
                    currentWeapon = 0;
                    shootPattern = 1;
                    reloadTime = 3f;
                    break;
            }
        }
        else if (hp > 15 && hp <= 20)
        {
            switch (phase)
            {
                case 2:
                    currentWeapon = 0;
                    shootPattern = 3;
                    reloadTime = 2f;
                    phase = -1;
                    break;
                case 1:
                    currentWeapon = 1;
                    shootPattern = 2;
                    reloadTime = 2f;
                    break;
                case 0:
                    currentWeapon = 0;
                    shootPattern = 2;
                    reloadTime = 2f;
                    //speed++;
                    break;
            }
        }
        else if (hp >= 10 && hp <= 15)
        {
            switch (phase)
            {
                case 3:
                    currentWeapon = 0;
                    shootPattern = 3;
                    reloadTime = 2f;
                    phase = -1;
                    break;
                case 2:
                    currentWeapon = 0;
                    shootPattern = 3;
                    reloadTime = 2f;
                    break;
                case 1:
                    currentWeapon = 1;
                    shootPattern = 1;
                    reloadTime = 2f;
                    break;
                case 0:
                    currentWeapon = 2;
                    shootPattern = 1;
                    reloadTime = 2f;
                    break;
            }
        }
        else
        {
            switch (phase)
            {
                case 5:
                    currentWeapon = 2;
                    shootPattern = 2;
                    reloadTime = 2f;
                    phase = -1;
                    break;
                case 4:
                    currentWeapon = 0;
                    shootPattern = 3;
                    reloadTime = 2f;
                    break;
                case 3:
                    currentWeapon = 2;
                    shootPattern = 1;
                    reloadTime = 2f;
                    break;
                case 2:
                    currentWeapon = 0;
                    shootPattern = 3;
                    reloadTime = 2f;
                    break;
                case 1:
                    currentWeapon = 1;
                    shootPattern = 3;
                    reloadTime = 2f;
                    break;
                case 0:
                    currentWeapon = 0;
                    shootPattern = 3;
                    reloadTime = 2f;
                    break;
            }
        }
    }

    public override void Shoot()
    {
        bulletSpawn = transform.position + new Vector3(0,0,-4);
        if (reloaded == true)
        {
            checkBossPattern();

            if (shootPattern == 1)
            {
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(1, 0, 0), transform.rotation * new Quaternion(0, 0, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(0, 0, 0), transform.rotation * new Quaternion(0, 0, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(-1, 0, 0), transform.rotation * new Quaternion(0, 0, 0, -1));
                phase++;
            }
            else if (shootPattern == 2)
            {
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(1, 0, 0), transform.rotation * new Quaternion(0, -0.1f, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(0, 0, 0), transform.rotation * new Quaternion(0, 0, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(-1, 0, 0), transform.rotation * new Quaternion(0, 0.1f, 0, -1));
                phase++;
            }
            else if (shootPattern == 3)
            {
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(3, 0, 0), transform.rotation * new Quaternion(0, -0.2f, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(2, 0, 0), transform.rotation * new Quaternion(0, -0.1f, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(1, 0, 0), transform.rotation * new Quaternion(0, -0.05f, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(0, 0, 0), transform.rotation * new Quaternion(0, 0, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(-1, 0, 0), transform.rotation * new Quaternion(0, 0.05f, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(-2, 0, 0), transform.rotation * new Quaternion(0, 0.1f, 0, -1));
                Instantiate(Weapons[currentWeapon], bulletSpawn + new Vector3(-3, 0, 0), transform.rotation * new Quaternion(0, 0.2f, 0, -1));
                phase++;
            } 
            Debug.Log("phase: " + phase);
            return;
        }
    }

}
