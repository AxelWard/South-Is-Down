using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public static float SENSITIVIY = 500f;
    public static float VOLUME = 1f;

    public Canvas pauseMenu;
    public Canvas HUD;
    public Canvas optionsMenu;

    public static bool GAME_IS_PAUSED = false;

    public Slider senseSlider;
    public Slider volumeSlider;

    private void Awake()
    {
        SENSITIVIY = PlayerPrefs.GetFloat("SENSITIVITY", 500f);
        AudioListener.volume = PlayerPrefs.GetFloat("VOLUME", 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu != null) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GAME_IS_PAUSED)
                {
                    CloseMenu();
                }
                else
                {
                    OpenMenu();
                }
            }
        }
    }

    public void CloseMenu()
    {
        GAME_IS_PAUSED = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        HUD.gameObject.SetActive(true);
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        GAME_IS_PAUSED = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenu.gameObject.SetActive(true);
        HUD.gameObject.SetActive(false);
    }

    public void PauseMenuToOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);

        senseSlider.value = SENSITIVIY / 100f;
        volumeSlider.value = VOLUME;
    }

    public void OptionsMenuToPauseMenu()
    {
        optionsMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
    }

    public void UpdateSensitivity()
    {
        float value = senseSlider.value;
        SENSITIVIY = value * 100f;
        PlayerPrefs.SetFloat("SENSITIVITY", value * 100f);
    }

    public void UpdateVolume()
    {
        float value = volumeSlider.value;
        VOLUME = value;
        PlayerPrefs.SetFloat("VOLUME", value);
        AudioListener.volume = value;
    }
}
