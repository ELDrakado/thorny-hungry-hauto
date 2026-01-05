using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;

    [SerializeField] TMP_Text boostText;

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    void Update()
    {
        float steer = 0f;
        float move = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedBoost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject, 0.25f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        boostText.gameObject.SetActive(false);
    }
}
