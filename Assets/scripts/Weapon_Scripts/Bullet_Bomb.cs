using UnityEngine;
using System.Collections;

public class Bullet_Bomb : Bullet {

    public float ExplosionDistance;
    public float explosionTime;

    // Use this for initialization
    public override void Start () {
		speed = 7;
        explosionTime = Random.Range(1f, 3f);
	}

    void Explode()
    {
        speed = 0;
    }

    public override void DestroyBullet()
    {
        Explode();
    }
    public override void Update()
    {
        Move(speed);
        if (explosionTime > 0)
        {
            explosionTime -= Time.deltaTime;
        }
        else
        {
            Explode();
        }
    }
    

}
