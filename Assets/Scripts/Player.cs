using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float deceleration = 3f;
    public float rotationSpeed = 100f;
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform headCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private float headCheckRadius = 0.2f;

    public int maxHealth = 1;
    private int currentHealth;
    private Animator animator;
    public GameObject gameOverMenu;

    private float currentSpeed = 0f;
    private bool isTouching = false;
    private bool isInAir = false;
    private bool isDead = false;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        bool headHit = Physics2D.OverlapCircle(headCheck.position, headCheckRadius, groundLayer);

        if (headHit)
        {
            Die();
        }

        isInAir = !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            isTouching = touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary;
        }
        else
        {
            isTouching = Input.GetMouseButton(0);
        }

        if (isInAir && isTouching)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (!isInAir)
        {
            if (isTouching)
            {
                // Якщо торкаємось екрану – прискорюємось
                currentSpeed += acceleration * 2f * Time.fixedDeltaTime;
            }
            else
            {
                // Якщо не торкаємось – швидкість = 0
                currentSpeed -= deceleration * 2f * Time.fixedDeltaTime;
            }

            // Обмежуємо швидкість в межах дозволеного
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

            // Рух відносно локальної системи координат персонажа
            rb.velocity = transform.right * currentSpeed;
        }
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Гравець помер!");

        // Зупиняємо рух персонажа
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Static; // Заморожуємо фізику

        // Запускаємо анімацію смерті
        animator.SetTrigger("Die");

        // Запускаємо корутину для очікування завершення анімації
        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        // Отримуємо тривалість анімації смерті
        float deathAnimTime = animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(deathAnimTime); // Чекаємо завершення анімації

        // Після анімації вимикаємо об'єкт
        gameObject.SetActive(false);

        // Показуємо меню Game Over
        ShowGameOverMenu();
    }



    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

        if (headCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(headCheck.position, headCheckRadius);
        }
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
