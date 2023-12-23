
using UnityEngine;

public class coinSpawnerScript : MonoBehaviour
{   
    private Rigidbody2D rbody2D;
    private float SpeedMoveChip = 1f;
    private void Start() 
    {
        rbody2D= GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        rbody2D.velocity=new Vector2(-SpeedMoveChip,0f);    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            GameManager.totalCoins++;
            PlayerPrefs.SetInt("totalCoins", GameManager.totalCoins);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("LimitMap"))
        {
            Destroy(this.gameObject);
        }
    }
}
