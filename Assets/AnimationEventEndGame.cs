using UnityEngine;

public class AnimationEventEndGame : MonoBehaviour
{
    public void LoadWinScene()
    {
        TransitionManager.Instance.LoadWinScene();
    }
}
