using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingEmotion : Singleton<KingEmotion>
{
    [SerializeField] private Animator kingAnim;

    [SerializeField] private AudioClip clipMad;
    [SerializeField] private AudioClip clipNeutral;
    [SerializeField] private AudioClip clipHappy;
    [SerializeField] private AudioClip clipLaughing;

    [SerializeField] private Sprite spriteMad;
    [SerializeField] private Sprite spriteNeutral;
    [SerializeField] private Sprite spriteHappy;
    [SerializeField] private Sprite spriteLaughing;
    [SerializeField] private Sprite spriteRllyMad;


    [SerializeField] private AudioSource SFXSource;
    private AudioClip activeClip;
    [SerializeField] private Image activeSprite;

    [SerializeField] private GameObject kingFeedbackBox;

    private string correctAnimation;
    public enum emotion
    {
        mad,
        neutral,
        happy,
        laughing,
        rllyMad

    }

    private emotion currentEmotion;
    public void SetEmotion(emotion newEmotion)
    {
        currentEmotion = newEmotion;
        StopAllCoroutines();
        switch (currentEmotion)
        {
            case emotion.mad:
                OnKingMad();
                break;
            case emotion.neutral:
                OnKingNeutral();
                break;
            case emotion.happy:
                OnKingHappy();
                break; 
            case emotion.laughing:
                OnLaughing();
                break;
            case emotion.rllyMad:
                OnRllyMad();
                break;
            default:
                break;
        }

    }
    public void PlayEmotionClip()
    {
        kingFeedbackBox.SetActive(true);
        kingAnim.SetTrigger(correctAnimation);
        SFXSource.clip = activeClip;
        SFXSource.Play();
    }


    private void OnKingMad()
    {
        activeClip = clipMad;
        activeSprite.sprite = spriteMad;
        correctAnimation = "KingMad";
    }

    private void OnKingNeutral()
    {
        activeClip = clipNeutral;
        activeSprite.sprite = spriteNeutral;
        correctAnimation = "KingNeutral";
    }

    private void OnKingHappy()
    {
        activeClip = clipHappy;
        activeSprite.sprite = spriteHappy;
        correctAnimation = "KingHappy";

    }

    private void OnLaughing()
    {
        correctAnimation = "KingFinalLaugh";
        activeClip = clipLaughing;
        activeSprite.sprite = spriteLaughing;
    }

    private void OnRllyMad()
    {
        correctAnimation = "KingReallyMad";
        activeClip = clipMad;
        activeSprite.sprite = spriteRllyMad;
    }

    #region King Animations 

    public void TriggerChoosingAnim()
    {
        kingAnim.SetTrigger("KingChoosing");
    }
    #endregion


}
