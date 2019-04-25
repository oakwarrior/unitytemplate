using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string GameSceneName = "";

    public Button ButtonPlay;
    public Button ButtonExit;


    // Start is called before the first frame update
    void Start()
    {
        ButtonPlay.onClick.AddListener(OnPlayClicked);
        ButtonExit.onClick.AddListener(OnExitClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
