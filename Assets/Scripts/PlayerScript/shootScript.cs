using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    [SerializeField] private float shootForce;
    void Start()
    {
        bulletRB=GetComponent<Rigidbody2D>(); 
    }
    private void Update() 
    {
        bulletRB.velocity=new Vector2(shootForce,0f);    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Destroy(collision.gameObject);   
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer==LayerMask.NameToLayer("shootLimit"))
        {
            Destroy(this.gameObject);
        }   
    }
}
