using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject _creditsMenu;
    [SerializeField]
    private AudioClip _mainMenuClip;


    private AudioSource mainSpeaker;

    private void Awake()
    {
        if (_creditsMenu == null)
            Debug.LogWarning("No credits menu found");
        else
            _creditsMenu.SetActive(false);


        mainSpeaker = GetComponent<AudioSource>();
        if (_mainMenuClip != null)
        {
            mainSpeaker.clip = _mainMenuClip;
            mainSpeaker.Play();
        }
        else
            Debug.LogWarning("No main menu clip found");

    }


    public void PlayGame()
    {
      SceneManager.LoadScene("02_Game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void ToggleCredits()
    {
        _creditsMenu.SetActive(!_creditsMenu.activeSelf);
    }
}
