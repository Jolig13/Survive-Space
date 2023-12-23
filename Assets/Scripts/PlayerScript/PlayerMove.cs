using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedMove;
    private float MoveY;
    private float MoveX;
    private Rigidbody2D rb2d;
    [SerializeField] private ParticleSystem deathFX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        MoveY = Input.GetAxisRaw("Vertical");
        MoveX = Input.GetAxisRaw("Horizontal");
        Vector2 playerMove = new Vector2(MoveX, MoveY).normalized;
        rb2d.velocity = playerMove * speedMove * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Destroy(collision.gameObject);
            AudioManager.AudioInstance.AsteroidSound();
            gameObject.SetActive(false);
            Instantiate(deathFX, transform.position, Quaternion.identity);
            GameManager.Instance.GameOver();
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            AudioManager.AudioInstance.AsteroidSound();
            gameObject.SetActive(false);
            Instantiate(deathFX, transform.position, Quaternion.identity);
            GameManager.Instance.GameOver();
        }
        if (collision.gameObject.CompareTag("LimitMap"))
        {
            Destroy(this.gameObject);
            AudioManager.AudioInstance.AsteroidSound();
            GameManager.Instance.GameOver();
            Instantiate(deathFX,transform.position,Quaternion.identity);
        }
    }
}


