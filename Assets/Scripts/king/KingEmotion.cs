using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingEmotion : Singleton<KingEmotion>
{

    [SerializeField] private AudioClip clipMad;
    [SerializeField] private AudioClip clipNeutral;
    [SerializeField] private AudioClip clipHappy;

    [SerializeField] private Sprite spriteMad;
    [SerializeField] private Sprite spriteNeutral;
    [SerializeField] private Sprite spriteHappy;


    [SerializeField] private AudioSource SFXSource;
    private AudioClip activeClip;
    [SerializeField] private Image activeSprite;

    [SerializeField] private GameObject kingFeedbackBox;


    public enum emotion
    {
        mad,
        neutral,
        happy
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
            default:
                break;
        }

    }

    private void OnKingMad()
    {
        activeClip = clipMad;
        activeSprite.sprite = spriteMad;
    }

    private void OnKingNeutral()
    {
        activeClip = clipNeutral;
        activeSprite.sprite = spriteNeutral;
    }

    private void OnKingHappy()
    {
        activeClip = clipHappy;
        activeSprite.sprite = spriteHappy;
    }

    public void PlayEmotionClip()
    {
        kingFeedbackBox.SetActive(true);
        SFXSource.clip = activeClip;
        SFXSource.Play();
    }


}
