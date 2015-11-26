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

    public float colDistance = 0.5f;
    public bool colDown = false;
    public bool colUp = false;
    public bool colLeft = false;
    public bool colRight = false;

    public virtual void Start()
    {
       // weapons = Resources.LoadAll("Prefab/Weapons/") as GameObject[];

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

        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;       
    }

	public virtual void Move() { }

    public virtual void Shoot()
	{

	}

    public virtual void Die()
    {
        isAlive = false;
        Destroy(this);
    }
 
    public virtual void Collision()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, colDistance))
        {
            colUp = true;
            //Debug.Log("There is something in front of the object!");

        }
        else
        {
            colUp = false;
        }

        Vector3 bwd = transform.TransformDirection(-Vector3.forward);
        if (Physics.Raycast(transform.position, bwd, colDistance))
        {
            colDown = true;
            //Debug.Log("There is something behind the object!");
        }
        else
        {
            colDown = false;
        }


        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, colDistance))
        {
            colRight = true;
            //Debug.Log("There is something to the right of the object!");
        }
        else
        {
            colRight = false;
        }

        Vector3 left = transform.TransformDirection(-Vector3.right);
        if (Physics.Raycast(transform.position, left, colDistance))
        {
            colLeft = true;
            //Debug.Log("There is something to the left of the object!");
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

    void Update()
    {
        Move();
        Shoot();
    }
}
