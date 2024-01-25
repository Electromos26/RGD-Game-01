using UnityEngine;
using UnityEngine.Events;

public class SkillCheck : MonoBehaviour
{
    [SerializeField]
    private int left = -200;
    [SerializeField]
    private int right = 270;

    RectTransform rect;
    RectTransform originalPos;
    bool pass = false;

    bool canPress = false;

    [SerializeField] UnityEvent timerOff;

    private void Awake()
    {
       rect = GetComponent<RectTransform>();
       originalPos = rect;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("SkillBox"))
        {
            pass = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SkillBox"))
        {
            pass = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (pass)
            {
                Debug.Log("Skill Check : Passed");
                ChangePos();
                DanceMiniGame.Instance.Passed();
                //Telepot to next position
            }
            else if(canPress)
            {
                ChangePos();
                Debug.Log("Skill Check : Failed");
                DanceMiniGame.Instance.Failed();
            } else
            {
                Debug.Log("Skill Check : Waiting");
            }
        }
    }

    private void OnEnable()
    {
        canPress = true;  
    }
    private void OnDisable()
    {
        canPress = false;
    }
    private void ChangePos()
    {
        Vector2 randomPos;
        randomPos.x = Random.Range(left, right);
        randomPos.y = rect.localPosition.y;
        rect.localPosition = randomPos;
    }

    public void ResetPos()//Called when mini game is over
    {
        rect.position = originalPos.position;
    }



}
