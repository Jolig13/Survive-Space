using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayShootScript : MonoBehaviour
{
    private Rigidbody2D rayRb;
    [SerializeField] private float raySpeed;
   
    void Start()
    {
        rayRb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rayRb.velocity=new Vector2(raySpeed,0f);
        Destroy(this.gameObject,10f);
    }
    private void OnCollisionEnter2D(Collision2D collider) 
    {
        if (collider.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Meteor"))
        {
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.layer==LayerMask.NameToLayer("shootLimit"))
        {
            Destroy(this.gameObject);
        }
    }
}
