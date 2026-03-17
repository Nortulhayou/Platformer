using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb = new Rigidbody2D();
    public float speed = 10f;
    public float jumpForce = 250;
    public bool grounded = true;
    public int coinsCollected = 0;
    public int currentHealth = 3;
    public TMP_Text coinText;
    public TMP_Text healthText;
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
                rb.AddForce(Vector2.up * jumpForce);
                grounded = false;
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collectable>())
        {
            coinsCollected++;
            coinText.text = coinsCollected.ToString();
        }
        else if(other.GetComponent<Hazard>())
        {
            currentHealth--;
            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene($"Dead");
            }
        }
    }
   
}
