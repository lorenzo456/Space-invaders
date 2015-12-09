using UnityEngine;
using System.Collections;

public class Ship : Character {

	float zAxis;

	void Awake ()
	{
		zAxis = transform.position.z;
	}

	public override void Start ()
	{
		base.Start ();
		speed = 0.1f;
        currentWeapon = 2;
	}

	public override void Move ()
	{
		base.Move ();
        if (colRight || colLeft)
        {
            zAxis -= 2;
            myDirection *= -1;
        }

        transform.position += new Vector3 (speed * myDirection, 0, 0);
		transform.position = new Vector3 (transform.position.x, transform.position.y, zAxis + GenerateSin());       
    }

	float GenerateSin(){
		return Mathf.Sin (Mathf.PI * 2 * Time.deltaTime + transform.position.x);
	}
}
