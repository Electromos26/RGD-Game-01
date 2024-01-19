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
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void ToggleCredits()
    {
        _creditsMenu.SetActive(!_creditsMenu.activeSelf);
    }
}
