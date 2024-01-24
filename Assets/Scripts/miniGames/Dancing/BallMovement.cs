using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;

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
        float t = Mathf.PingPong(Time.time * speed, 1f);
        rect.position = Vector2.Lerp(startRect.position, endRect.position, t);
    }
    public void SpeedX2()
    {
        speed *= 2;
    }
}
