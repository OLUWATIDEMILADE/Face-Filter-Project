using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject welcomePanel, infoPanel, navPanel;

    void Start()
    {
        ShowWelcome();
    }

    public void ShowWelcome()
    {
        welcomePanel.SetActive(true);
        infoPanel.SetActive(false);
        navPanel.SetActive(false);
    }

    public void ShowInfo()
    {
        welcomePanel.SetActive(false);
        infoPanel.SetActive(true);
        navPanel.SetActive(false);
    }

    public void ShowNav()
    {
        welcomePanel.SetActive(false);
        infoPanel.SetActive(false);
        navPanel.SetActive(true);
    }

    public void LoadARScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ARScene");
    }
}
