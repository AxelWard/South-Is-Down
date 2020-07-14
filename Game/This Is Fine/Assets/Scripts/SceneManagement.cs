using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private static bool MoveToNextLevel = false;
    private static bool ReturnToMainMenu = false;

    public Animator transition;
    public float transitionTime;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveToNextLevel)
        {
            MoveToNextLevel = false;
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        if (ReturnToMainMenu)
        {
            ReturnToMainMenu = false;
            StartCoroutine(LoadLevel(1));
        }
    }

    public static void LevelComplete()
    {
        MoveToNextLevel = true;
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(2));
    }

    public static void ReturnToMain()
    {
        ReturnToMainMenu = true;
    }

    public void ResetLevel()
    {
        GetComponent<PauseMenuManager>().CloseMenu();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void ExitToDesktop()
    {
        PauseMenuManager p = GetComponent<PauseMenuManager>();

        if(p != null)
        {
            p.CloseMenu();
        }

        StartCoroutine(ApplicationExit());
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator ApplicationExit()
    {
        yield return new WaitForSeconds(.25f);
        Application.Quit();
    }
}
