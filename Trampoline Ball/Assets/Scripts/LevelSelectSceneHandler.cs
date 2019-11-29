using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectSceneHandler : MonoBehaviour
{
    public string backButtonSceneName;
    public string levelOneSceneName;

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

    public void selectLevelOne()
    {
        Debug.Log("Clicked Level 1");
        SceneManager.LoadScene(levelOneSceneName);
    }
}
