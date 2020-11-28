using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject obj;
	private Rigidbody rb;
	private float c=0;
	public float z=0;
	private Vector3 start_impulse;
	private float distanse=0;
	private Vector3 cos;
	private float alfa;
    void Start()
    { rb=GetComponent<Rigidbody>();
	distanse=transform.position.magnitude;
		if (z==1f)
		{
		start_impulse=Mathf.Sqrt(2*distanse*9.8f)*new Vector3(-Mathf.Sqrt(2)/2,0,Mathf.Sqrt(2)/2);
       
		rb.AddForce(start_impulse, ForceMode.VelocityChange);
		}
		if (z==2f)
		{
			alfa= Mathf.PI/2-Mathf.Atan(1/2);
			start_impulse=Mathf.Sqrt(distanse*9.8f)*new Vector3(-Mathf.Cos(alfa),0,Mathf.Sin(alfa));
       
		rb.AddForce(start_impulse, ForceMode.VelocityChange);
			
		}
		if (z==3)
		{
			alfa= Mathf.PI/2-Mathf.Atan(7/4);
			start_impulse=Mathf.Sqrt(6f*distanse*9.8f)*new Vector3(-Mathf.Cos(alfa),0,Mathf.Sin(alfa));
       
		rb.AddForce(start_impulse, ForceMode.VelocityChange);
			
		}
		if (z==4)
		{
			alfa= Mathf.PI/2;
			start_impulse=Mathf.Sqrt(1.5f*distanse*9.8f)*new Vector3(0,0,1);
       
		rb.AddForce(start_impulse, ForceMode.VelocityChange);
			
		}
		c= distanse*distanse*9.8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        distanse=transform.position.magnitude;
		
		
		
		if (distanse < 0.15)
		{
			Vector3 nul = new Vector3(0,0,0);
			transform.position=nul;
			//rb.AddForce(nul,ForceMode.Acceleration);
			rb.isKinematic=true;
			
		} else{
		
		rb.AddForce(-transform.position*c/(distanse*distanse*distanse), ForceMode.Impulse);
		}
		
		//Debug.Log(distanse);
    }
}
