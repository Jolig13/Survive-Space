using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField] private float speedMove;
    private float MoveY;
    private Rigidbody2D rb2d;
    [SerializeField] private float addSpeed;
    [SerializeField] private float timeSpeed;
    [SerializeField] private float gameoverDelay;
    [SerializeField] private ParticleSystem deathFX;
    [SerializeField] private GameObject GameOverPanel;
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
        MoveY=Input.GetAxisRaw("Vertical");
        Vector2 playerMove=new Vector2(0f,MoveY).normalized;
        rb2d.velocity=playerMove*speedMove*Time.deltaTime;
        GameManager.Instance.Score();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Destroy(collision.gameObject);
            AudioManager.AudioInstance.AsteroidSound();
            gameObject.SetActive(false);
            Instantiate(deathFX,transform.position,Quaternion.identity);
            Invoke("GameOver",gameoverDelay);
        }   
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            AudioManager.AudioInstance.AsteroidSound();
            gameObject.SetActive(false);
            Instantiate(deathFX,transform.position,Quaternion.identity);
            Invoke("GameOver",gameoverDelay);
        }   
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
        speedMove+=addSpeed/(timeSpeed*2);
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
}
