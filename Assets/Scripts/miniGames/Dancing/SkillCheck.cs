using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    bool pass = false;

    private void Awake()
    {
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
            }
            else
            {
                Debug.Log("Skill Check : Failed");
            }
        }
    }

}
