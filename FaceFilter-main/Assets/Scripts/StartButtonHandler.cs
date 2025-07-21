using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHandler : MonoBehaviour
{
    // Call this method from your button
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("HomePageScene");
    }
}
