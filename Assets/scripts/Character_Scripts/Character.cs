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

    public float colDistance = 0.5f;
    public bool colDown = false;
    public bool colUp = false;
    public bool colLeft = false;
    public bool colRight = false;

	public virtual void Awake (){
	}
    public virtual void Start()
    {
		for (int i = 0; i < 5; i++) 
		{
			GameObject newWeapon = Resources.Load("Prefab/Weapons/Weapon"+i) as GameObject;
			if(newWeapon == null)
			{
				break;
			}else
			{
				Weapons.Add(newWeapon);
			}
		}
        
    }

	public virtual void Move() { }

    public virtual void Shoot(){ }

    public virtual void WeaponSwitch()
    {
        
    }

    public virtual void Die()
    {
        isAlive = false;
        Destroy(this.gameObject);
    }
 
    public virtual void Collision()
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


        Debug.DrawRay(transform.position, fwd * colDistance);
        Debug.DrawRay(transform.position, bwd * colDistance);
        Debug.DrawRay(transform.position, right * colDistance);
        Debug.DrawRay(transform.position, left * colDistance);

    }

    public virtual void Reload()
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

    void Update()
    {
        Move();
        Shoot();
        Reload();
        WeaponSwitch();

        if ( hp < 0)
        {
            Die();
        }
    }
}
