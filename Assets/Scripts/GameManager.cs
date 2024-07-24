using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    public string mainMenu;

    private bool doEsc = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        pauseMenu.SetActive(false);
        //DontDestroyOnLoad(pauseMenu);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            pauseFalse();
        }

        if (Input.GetMouseButton(1))
        {
            LockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void resumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void pauseFalse()
    {

        if (PlayerController.instance.currentHealth == 0)
        {
            pauseMenu.SetActive(false);
            doEsc = false;
            UnlockCursor();
            //Time.timeScale = 0f;
        }
    }

    public void menu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
