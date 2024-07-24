using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlPanel;

    public string sceneToLoad;
    public string sceneTutor;
    public string play;

    // Start is called before the first frame update
    void Start()
    {
        controlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cPActvie()
    {
        controlPanel.SetActive(true);
    }

    public void backButtonKhusus()
    {
        controlPanel.SetActive(false);
    }

    public void backButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void tutorial()
    {
        SceneManager.LoadScene(sceneTutor);
    }
    public void playGame()
    {
        SceneManager.LoadScene(play);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
