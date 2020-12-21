using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly_script : MonoBehaviour
{
	public Vector3 v0;
	private Rigidbody rb;
	private float t=0;
	private float flag=0;
	
	void OnCollisionEnter(Collision coll)
	
	{ 
	
			
			 rb.AddForce(0.9f*coll.impulse, ForceMode.Impulse);
			 Debug.Log(coll.impulse);
	
		
	}
	
	void OnCollisionStay(Collision coll)
	{
		rb.velocity=0.9f*rb.velocity;
		
	}
	
	
	
    // Start is called before the first frame update
    void Start()
    {
		rb=GetComponent<Rigidbody>();
        rb.AddForce(v0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // t=t+Time.fixedDeltaTime;
    }
}
