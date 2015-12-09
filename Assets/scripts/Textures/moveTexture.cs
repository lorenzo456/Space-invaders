using UnityEngine;
using System.Collections;

public class moveTexture : MonoBehaviour {

    Vector2 offset;
    float speed = 0.01f;
 
 void Update()
    {
        offset.y = offset.y + -speed * Time.deltaTime;
        this.GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
