using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Гра закрита.");
        Application.Quit();
    }
}
