using UnityEngine;
using System.Collections;

public class Ship : Character {

	float zAxis;
	float newZAxis;

	public override void Awake ()
	{
		base.Awake ();
		zAxis = transform.position.z;
	}
	public override void Start ()
	{
		base.Start ();
		speed = 0.1f;
	}


	public override void Move ()
	{
		base.Move ();
		transform.position += new Vector3 (speed, 0, newZAxis);
		//transform.position = new Vector3 (0, 0, zAxis + GenerateSin());
		//newZAxis = zAxis + GenerateSin ();
	}

	float GenerateSin(){
		Debug.Log(Mathf.Sin (Mathf.PI * 2 * Time.deltaTime + transform.position.x));
		return Mathf.Sin (Mathf.PI * 2 * Time.deltaTime + transform.position.x);
	}
}
