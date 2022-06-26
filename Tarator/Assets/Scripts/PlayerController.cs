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

    private Inventory inventory;

    public UI_inventory uiInvetory;

    // Variables for health
    public int maxHealth = 100;
    public int Health {
        set {
            health = value;

            if(health <= 0)
            {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public int health = 50;

    public HealthBar healthBar;

   // Variables for flipX
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>(); 

    // Variables for melee attack
    public bool isMeleeSelected = false;
    public StaffAttack staffAttack;

    // Variables for ranged attack
    public bool isRangedSelected = false;
    public RangedAttack rangeAttack;

    // Variables for splash attack
    //public bool isSplashSelected = false;
    //public SplashAttack splashAttack;


    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    private void Start()
    {
        inventory = new Inventory();
        uiInvetory.SetInventory(inventory);

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set currentHealth to maxHealth
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void Update() 
    {
        uiInvetory.SetInventory(inventory);
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            isMeleeSelected = true;
            isRangedSelected = false;
            //isSplashSelected = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            isMeleeSelected = false;
            isRangedSelected = true;
            //isSplashSelected = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            isMeleeSelected = false;
            isRangedSelected = false;
            //isSplashSelected = true;
        }

        StaffAttack(isMeleeSelected);
        RangedAttack(isRangedSelected);
       // SplashAttack(isSplashSelected);


        healthBar.SetHealth(health);
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

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void RangedAttack(bool isSelected)
    {
        if(isSelected && Input.GetKeyDown(KeyCode.E))
        {
            rangeAttack.Shoot();
        }   
    }

    void StaffAttack(bool isSelected)
    {
        if(isSelected && Input.GetKeyDown(KeyCode.E))
        {
            if(spriteRenderer.flipX == true)
            {
                staffAttack.AttackLeft();
            }
            else
            {
                staffAttack.AttackRight();
            }
        }
        if(isSelected && Input.GetKeyUp(KeyCode.E))
        {
            staffAttack.StopAttack();
        }
    }

    // void SplashAttack(bool isSelected)
    // {
    //     if(isSelected && Input.GetKeyDown(KeyCode.E))
    //     {
    //         splashAttack.Splash();
    //     }
    //     if(isSelected && Input.GetKeyUp(KeyCode.E))
    //     {
    //         splashAttack.StopSplash();
    //     }
    // }

    public void Defeated()
    {
        Debug.Log("DED");
        Destroy(gameObject);
    }  
}