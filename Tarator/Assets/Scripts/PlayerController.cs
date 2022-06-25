using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables for movement
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public Vector2 movementInput;
    public ContactFilter2D movementFilter;

    // Variables for health
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

   // Variables for flipX
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>(); 

    // Variables for ranged attack
    public bool isRangedSelected;

    // Variables for splash attack
    public bool isSplashSelected;
    public CircleCollider2D area;

    public GameObject projectile;


    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set currentHealth to maxHealth
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // Disable circle collider
        area = GetComponent<CircleCollider2D>();
        area.enabled = false;
    }

    private void Update() 
    {
        // Checks if space key is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Call TakeDamage function
            TakeDamage(20);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2");
            area.enabled = false;
            isRangedSelected = true;
            isSplashSelected = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3");
            area.enabled = true;
            isRangedSelected = false;
            isSplashSelected = true;
        }

        RangeAttack(isRangedSelected);
        Splash(isSplashSelected);
    }

    // Lower health depending on damage
    void TakeDamage(int damage)
	{
        currentHealth -= damage;

        // Check if health is lower than 0
        if(currentHealth <= 0)
        {
            currentHealth = 1;
        }

        // Set slider's value to currentHealth
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

    public Transform point;
    private float timeBetweenShots = 0;
    public float startTimeBetweenShots;

    public int offset;


    public void Timer(float timeBetweenShots, float startTimeBetweenShots)
    {
        
    }


    public void RangeAttack(bool isSelected)
    {
        if(isSelected && Input.GetKey(KeyCode.E))
        {
            if(timeBetweenShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    public BoxCollider2D box;
    // Splash attack
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy" && isSplashSelected)
        {
            Debug.Log("enemy");
        }
    }

    void Splash(bool isSelected)
    {
        if(isSelected && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("is enabled");
        }
    }
}
