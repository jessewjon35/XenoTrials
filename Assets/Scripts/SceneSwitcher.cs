using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public TMP_Text titleText;
    public Button playButton;
    public Button optionsButton;
    public Button creditsButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {

        SceneManager.LoadScene("Game");



    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Restart()
    {
       
        SceneManager.LoadScene("Game");
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

}
