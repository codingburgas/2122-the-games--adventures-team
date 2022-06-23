using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables for movement
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
     Vector2 movementInput;
    public ContactFilter2D movementFilter;

    // Variables for health
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

   // Variables for flipX
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>(); 

    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set currentHealth to maxHealth
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update() 
    {
        // Checks if space key is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("kokus");
            TakeDamage(20);
        }
    }

    // Lower health depending on damage
    void TakeDamage(int damage)
	{
        currentHealth =- damage;

        //Set slider's value to currentHealth
        healthBar.SetHealth(currentHealth);
	}

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            bool successMove = TryMove(movementInput);

            if(!successMove)
            {
                successMove = TryMove(new Vector2(movementInput.x, 0));
                if(!successMove)
                {
                successMove = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
        if(movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
            
        if(count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
