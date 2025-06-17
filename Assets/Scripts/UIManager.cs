using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject HUD;
    public GameObject gameOverUI;
    public GameObject shopUI;
    public PlatformLift[] platforms1;
    public PlatformLift2[] platforms2;


    public Transform player;
    private Vector3 startPosition;

    private Player playerScript;

    void Start()
    {
        startPosition = player.position;
        playerScript = player.GetComponent<Player>();

        ShowMainMenu(); // або ShowHUD() €кщо одразу хочеш гру
    }

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        HUD.SetActive(false);
        gameOverUI.SetActive(false);
        shopUI.SetActive(false);
    }

    public void ShowHUD()
    {
        mainMenuUI.SetActive(false);
        HUD.SetActive(true);
        gameOverUI.SetActive(false);
        shopUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        HUD.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void ShowShop()
    {
        mainMenuUI.SetActive(false);
        HUD.SetActive(false);
        gameOverUI.SetActive(false);
        shopUI.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverUI.SetActive(false);
        HUD.SetActive(true);
        mainMenuUI.SetActive(false);
        shopUI.SetActive(false);

        foreach (var platform in platforms1)
        {
            if (platform != null)
                platform.ResetPlatform();
        }

        foreach (var platform in platforms2)
        {
            if (platform != null)
                platform.ResetPlatform2();
        }

        // ”в≥мкнути обТЇкт гравц€
        player.gameObject.SetActive(true);

        // —кинути позиц≥ю
        player.position = startPosition;
        player.rotation = Quaternion.identity;

        if (playerScript != null)
        {
            playerScript.ResetPlayer();
        }

        Debug.Log("√ру перезапущено без поверненн€ до меню.");
    }

}
