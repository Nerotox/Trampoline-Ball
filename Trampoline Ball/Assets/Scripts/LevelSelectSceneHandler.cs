using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectSceneHandler : MonoBehaviour
{
    public string backButtonSceneName;
    public string level1SceneName;
    public string level2SceneName;
    public string level3SceneName;
    public string level4SceneName;
    public string level5SceneName;
    public string level6SceneName;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectBackToMenuButton()
    {
        Debug.Log("Clicked Back to Menu");
        SceneManager.LoadScene(backButtonSceneName);
    }

    public void SelectLevel1()
    {
        Debug.Log("Clicked Level 1");
        SceneManager.LoadScene(level1SceneName);
    }
    public void SelectLevel2()
    {
        Debug.Log("Clicked Level 1");
        SceneManager.LoadScene(level2SceneName);
    }
    public void SelectLevel3()
    {
        Debug.Log("Clicked Level 1");
        SceneManager.LoadScene(level3SceneName);
    }
    public void SelectLevel4()
    {
        Debug.Log("Clicked Level 1");
        SceneManager.LoadScene(level4SceneName);
    }
    public void SelectLevel5()
    {
        Debug.Log("Clicked Level 1");
        SceneManager.LoadScene(level5SceneName);
    }
    public void SelectLevel6()
    {
        Debug.Log("Clicked Level 1");
        SceneManager.LoadScene(level6SceneName);
    }
}
