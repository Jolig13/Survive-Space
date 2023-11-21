using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorSccrippt : MonoBehaviour
{
    private Rigidbody2D obstacleRb;
    [SerializeField] private float meteorSpeed;
    void Start()
    {
        obstacleRb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {   
        obstacleRb.velocity=new Vector2(meteorSpeed,0f);
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("limitMap"))
        {   
            Destroy(this.gameObject);
        }  
    }
}
