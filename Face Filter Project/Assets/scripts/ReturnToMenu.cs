using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    // Call this method from a UI Button to return to the main menu
    public void ReturnToMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
