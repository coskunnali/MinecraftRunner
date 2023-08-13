using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;
    //public Canvas mainMenu;
    //public Canvas options;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
}
