using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField] private float speedMove;
    private float moveX;
    private float MoveY;
    private Rigidbody2D rb2d;
    [SerializeField] private float addSpeed;
    [SerializeField] private float timeSpeed;
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }
    void Update()  
    {
        Movement();
    }
    private void Movement()
    {
        moveX=Input.GetAxisRaw("Horizontal");
        MoveY=Input.GetAxisRaw("Vertical");
        Vector2 playerMove=new Vector2(moveX,MoveY).normalized;
        rb2d.velocity=playerMove*speedMove*Time.deltaTime;
        GameManager.Instance.Score();
    }
    private void OnTriggerEnter2D(Collider2D trigger2D) 
    {
        if (trigger2D.gameObject.CompareTag("SpeedUp"))
        {
            StartCoroutine(SpeedUp());
            Destroy(trigger2D.gameObject);
        }
    }
    IEnumerator SpeedUp()
    {
        speedMove+=addSpeed;
        yield return new WaitForSeconds(timeSpeed);
        speedMove+=addSpeed/timeSpeed;
    }
}
