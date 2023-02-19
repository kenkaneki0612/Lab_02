using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;

    public TextMeshProUGUI textCount;
    public TextMeshProUGUI textSpeed;

    public TextMeshProUGUI positionSpeed;
    public TextMeshProUGUI positionCharacter;

    private Rigidbody theRB;
    private float movementX, movementY;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        textCount.text = count.ToString();

        if (count >= 7)
        {
            winTextObject.SetActive(true);
            //gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        theRB.AddForce(movement * speed);

        positionCharacter.text = this.transform.position.ToString();
        positionSpeed.text = speed.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }
}
