using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
public TextMeshProUGUI countText;
	public GameObject winTextObject;
    private float movementX;
    private float movementY;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
         count = 0;

		SetCountText ();
winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
                 count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
        }
    }
void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}
}