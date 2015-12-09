using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
    public float spawnTime;
    public string enemy;

    public virtual void Start () 
	{
	}

	public virtual void Move(float mySpeed)
	{
		transform.position += (transform.forward * mySpeed) * Time.deltaTime;
	}

	public virtual void Update () 
	{
        checkSide();

        if (spawnTime > 0)
        {
            Move(speed);
            spawnTime -= Time.deltaTime;
        }
        else
        {
            DestroyBullet();
        }

        
    }

    public virtual void DestroyBullet()
    {
        Destroy(this.gameObject);
        //gameObject.SetActive(false);
    }

    public void checkSide()
    {
        if(transform.rotation == new Quaternion(0,0,0,1))
        {
            enemy = "Enemy";
        }
        else
        {
            enemy = "Player";
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == enemy)
        {
                other.gameObject.GetComponent<Character>().hp = other.gameObject.GetComponent<Character>().hp - 1;
                DestroyBullet();
        }
    }
}
