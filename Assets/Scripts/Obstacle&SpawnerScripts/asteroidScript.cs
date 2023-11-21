using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteoroidScript : MonoBehaviour
{
    private Rigidbody2D obstacleRb;
    [SerializeField] private float asteoridSpeed;
    void Start()
    {
        obstacleRb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {   
        obstacleRb.velocity=new Vector2(asteoridSpeed,0f);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameManager.Instance.GameOver();
        }
        if (other.gameObject.layer==LayerMask.NameToLayer("limitMap"))
        {
            Destroy(this.gameObject);
        }
    }
}
