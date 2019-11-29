using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public string levelSceneName;
    public string themeSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLevelButton()
    {
        Debug.Log("Clicked Level");
        SceneManager.LoadScene(levelSceneName);
    }
    
    public void SelectThemeButton()
    {
        Debug.Log("Clicked Theme");
        SceneManager.LoadScene(themeSceneName);
    }
}
