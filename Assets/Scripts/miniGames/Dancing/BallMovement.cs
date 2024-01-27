using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] private float speedMultiply = 1.5f;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;


    private float speed = 1f;
    private RectTransform rect;
    private RectTransform startRect;
    private RectTransform endRect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        startRect = start.GetComponent<RectTransform>();
        endRect = end.GetComponent<RectTransform>();
    }

    private void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        float t = Mathf.PingPong(Time.fixedTime * speed, 1f);
        rect.position = Vector2.Lerp(startRect.position, endRect.position, t);
    }
    public void SpeedX2()
    {
        speed *= speedMultiply;
    }
    public void ResetSpeed()
    {
        speed = 1f;
    }
}
