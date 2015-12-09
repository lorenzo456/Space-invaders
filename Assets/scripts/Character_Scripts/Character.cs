using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

    //public GameObject[] weapons;
	public List<GameObject>	Weapons = new List<GameObject> ();

    public bool isAlive;
    public int hp;
    public float speed;
	public int currentWeapon;
    public float reloadTime;
    public bool reloaded;
    public Vector3 bulletSpawn;
    public int myDirection;

    public float colDistance = 0.5f;
    public bool colDown = false;
    public bool colUp = false;
    public bool colLeft = false;
    public bool colRight = false;

    public virtual void Start()
    {
        isAlive = true;
        myDirection = 1;
        for (int i = 0; i < 5; i++)
        {
            GameObject newWeapon = Resources.Load("Prefab/Weapons/Weapon" + i) as GameObject;
            if (newWeapon == null)
            {
                break;
            }
            else
            {
                Weapons.Add(newWeapon);
            }
        }
    }

    public void Die()
    {
        isAlive = false;
        this.gameObject.SetActive (false);
    }
 
    public void Collision()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, colDistance) && hit.transform.gameObject.tag == "Wall")
        {
            colUp = true;
        }
        else
        {
            colUp = false;
        }

        Vector3 bwd = transform.TransformDirection(-Vector3.forward);
        if (Physics.Raycast(transform.position, bwd, out hit, colDistance) && hit.transform.gameObject.tag == "Wall")
        {
            colDown = true;
        }
        else
        {
            colDown = false;
        }


        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, out hit, colDistance) && hit.transform.gameObject.tag == "Wall")
        {
            colRight = true;
        }
        else
        {
            colRight = false;
        }

        Vector3 left = transform.TransformDirection(-Vector3.right);
        if (Physics.Raycast(transform.position, left, out hit, colDistance) && hit.transform.gameObject.tag == "Wall")
        {
            colLeft = true;
        }
        else
        {
            colLeft = false;
        }


        if (Physics.Raycast(transform.position, bwd, out hit, colDistance) && hit.transform.gameObject.tag == "DeathZone" || Physics.Raycast(transform.position, fwd, out hit, colDistance) && hit.transform.gameObject.tag == "DeathZone" ||
            Physics.Raycast(transform.position, right, out hit, colDistance) && hit.transform.gameObject.tag == "DeathZone" || Physics.Raycast(transform.position, left, out hit, colDistance) && hit.transform.gameObject.tag == "DeathZone")
        {
            isAlive = false;
        }

        Debug.DrawRay(transform.position, fwd * colDistance);
        Debug.DrawRay(transform.position, bwd * colDistance);
        Debug.DrawRay(transform.position, right * colDistance);
        Debug.DrawRay(transform.position, left * colDistance);

    }

    public void Reload()
        {
            if (reloadTime > 0)
            {
                reloaded = false;
                reloadTime -= Time.deltaTime;
            }
            else
            {
                reloadTime = 0;
                reloaded = true;
            }
        }

    public virtual void Move()
    {
        Collision();
    }

    public virtual void Shoot()
    {
        bulletSpawn = this.transform.position - new Vector3(0, 0, 2);
        if (reloaded == true)
        {
            Instantiate(Weapons[currentWeapon], bulletSpawn, transform.rotation * new Quaternion(0, 0, 0, -1));
            reloadTime = Random.Range(1f, 5f);
        }
    }

    public virtual void Update()
    {
        Move();
        Shoot();
        Reload();

        if ( hp < 0 || isAlive == false)
        {
            Die();
        }
    }
}
