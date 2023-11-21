using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffScript : MonoBehaviour
{
    private Rigidbody2D buffRB;
    [SerializeField] private float speed;
    void Start()
    {
        buffRB=GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        buffRB.velocity=new Vector2(speed,0f);
        Destroy(this.gameObject,15f);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("limitMap"))
        {
            Destroy(this.gameObject);
        }    
    }
}
