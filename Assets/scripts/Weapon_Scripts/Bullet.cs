using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public float ExplosionDistance;


	public virtual void Start () 
	{
	
	}

	public virtual void Move(float mySpeed)
	{
		transform.position += (Vector3.forward * mySpeed) * Time.deltaTime;
	}

	void Update () 
	{
		Move (speed);
	}
}
