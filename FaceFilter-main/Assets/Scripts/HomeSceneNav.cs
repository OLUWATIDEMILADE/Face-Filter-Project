using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeSceneNav : MonoBehaviour
{
    //Panels
    public GameObject MainPanel;
    public GameObject SettingsPanel;
    public GameObject AboutPanel;

    public void BackToHomePage()
    {
        SettingsPanel.SetActive(false);
        AboutPanel.SetActive(false);
        
        MainPanel.SetActive(true);
    }

    
    public void BackToHomePageScene()
    {
        
        SceneManager.LoadScene("HomePageScene");
    }
}
