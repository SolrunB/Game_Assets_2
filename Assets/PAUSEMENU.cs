using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class PAUSEMENU : MonoBehaviour
{
    

    public GameObject pauseMenuUI;
    public static bool isPaused; 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; 
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); 
        }
        else
        {
            Debug.LogError("PauseMenuUI not assigned"); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); 
            }
            else
            {
                Pause();
            }
        }
    }

   

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true; 
         
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false; 
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
