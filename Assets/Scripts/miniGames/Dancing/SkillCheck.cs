using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class SkillCheck : MonoBehaviour
{
    [SerializeField]
    private int left = -200;
    [SerializeField]
    private int right = 270;

    [SerializeField] float minPos= 50;

    RectTransform rect;
    RectTransform originalPos;
    float currentPos;
    float targetPos;
    bool pass = false;

    bool canPress = false;

    [SerializeField] UnityEvent PlaySucess;
    [SerializeField] UnityEvent PlayFail;

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
                PlaySucess.Invoke();
                ChangePos();
                DanceMiniGame.Instance.Passed();
                //Telepot to next position
            }
            else if (canPress)
            {
                Debug.Log("Skill Check : Failed");
                PlayFail.Invoke();
                ChangePos();
                DanceMiniGame.Instance.Failed();
            }
            else
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
        currentPos = rect.localPosition.x;

        Vector2 randomPos;
        randomPos.x = Random.Range(left, right);
        randomPos.y = rect.localPosition.y;

        targetPos = randomPos.x;

        float positionDif = Mathf.Abs(targetPos - currentPos);

        if (positionDif < minPos)
        {
            if (currentPos > 0)
            {
                randomPos.x = currentPos + minPos;
            }
            else
            {
                randomPos.x = currentPos - minPos;
            }
        }



        rect.localPosition = randomPos;
    }

    public void ResetPos()//Called when mini game is over
    {
        rect.position = originalPos.position;
    }



}
