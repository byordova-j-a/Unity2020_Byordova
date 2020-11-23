using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving2 : MonoBehaviour
{
   public GameObject obj;
	private Rigidbody rb;
	public float c=0;
	public Vector3 start_impulse;
	private float distanse=0;
	private Vector3 cos;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
		rb.AddForce(start_impulse, ForceMode.Impulse);
		
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanse=rb.transform.position.magnitude;
		cos=obj.transform.position/distanse;
		rb.AddForce(-cos*c/(distanse*distanse));
		//Debug.Log(distanse);
    }
}
