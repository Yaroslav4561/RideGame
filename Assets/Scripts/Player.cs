using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    private bool canControl = true;


    public GameObject shopUI;
    public GameObject mainMenuUI;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if ((shopUI != null && shopUI.activeSelf) ||
            (mainMenuUI != null && mainMenuUI.activeSelf))
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (!canControl) return;

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
        if ((shopUI != null && shopUI.activeSelf) ||
            (mainMenuUI != null && mainMenuUI.activeSelf))
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (!canControl) return;

        if (!isInAir)
        {
            if (isTouching)
            {
                currentSpeed += acceleration * 2f * Time.fixedDeltaTime;
            }
            else
            {
                currentSpeed -= deceleration * 2f * Time.fixedDeltaTime;
            }

            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
            rb.velocity = new Vector2(transform.right.x, transform.right.y).normalized * currentSpeed;

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

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Static;

        animator.SetTrigger("Die");
        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        float deathAnimTime = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(deathAnimTime);

        gameObject.SetActive(false);
        ShowGameOverMenu();
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);

        float finalScore = FindObjectOfType<DistanceTracker>().DistanceTravelled;

        Transform inputPanel = gameOverMenu.transform.Find("InputPanel");
        Transform leaderboardPanel = gameOverMenu.transform.Find("LeaderboardPanel");

        if (LeaderboardManager.Instance.IsHighScore(finalScore))
        {
            inputPanel.gameObject.SetActive(true);
            leaderboardPanel.gameObject.SetActive(false);

            Button confirmBtn = inputPanel.Find("ConfirmButton").GetComponent<Button>();
            TMP_InputField input = inputPanel.Find("NameInput").GetComponent<TMP_InputField>();

            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                string name = string.IsNullOrEmpty(input.text) ? "Player" : input.text;
                LeaderboardManager.Instance.AddEntry(name, finalScore);
                inputPanel.gameObject.SetActive(false);
                ShowLeaderboard();
            });
        }
        else
        {
            inputPanel.gameObject.SetActive(false);
            ShowLeaderboard();
        }
    }

    private void ShowLeaderboard()
    {
        Transform leaderboardPanel = gameOverMenu.transform.Find("LeaderboardPanel");
        leaderboardPanel.gameObject.SetActive(true);

        Transform content = leaderboardPanel.Find("Content");
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        GameObject prefab = Resources.Load<GameObject>("LeaderboardEntryPrefab");
        if (prefab == null)
        {
            Debug.LogError("❌ Не знайдено префаб LeaderboardEntryPrefab у Resources!");
            return;
        }

        foreach (var entry in LeaderboardManager.Instance.GetEntries())
        {
            GameObject item = Instantiate(prefab, content);
            item.GetComponent<TextMeshProUGUI>().text = $"{entry.playerName} - {entry.score:F1} м";
        }
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

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetControl(bool state)
    {
        canControl = state;
    }

    public void ResetPlayer()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        isDead = false;
        transform.rotation = Quaternion.identity;
        currentSpeed = 0f;
        rb.bodyType = RigidbodyType2D.Dynamic;
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
