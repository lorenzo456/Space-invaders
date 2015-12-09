using UnityEngine;
using System.Collections;

public class Bullet_Bomb : Bullet {

    public float ExplosionDistance;
    public float explosionTime;
    public ParticleSystem explosion;
    public BoxCollider myCollider;
    public bool isExploding;

    // Use this for initialization
    public override void Start () {
		speed = 5;
        spawnTime = 3;
        explosionTime = 5;
        explosion = this.gameObject.GetComponent<ParticleSystem>();
        myCollider = this.gameObject.GetComponent<BoxCollider>();
	}

    public override void DestroyBullet()
    {
        speed = 0;
        isExploding = true;
        
        if (explosionTime > 0) {
            myCollider.size += new Vector3(0.01f,0,0.01f);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public override void Update()
    {
        base.Update();
        if (isExploding)
        {
            explosionTime -= Time.deltaTime;
        }
    }

    void OnCollisionStay(Collision other)
    {

        if (other.gameObject.tag == enemy)
        {
            other.gameObject.GetComponent<Character>().hp = other.gameObject.GetComponent<Character>().hp - 1;
            DestroyBullet();
        }
    }

}
