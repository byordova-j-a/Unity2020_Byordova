using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject obj;
	private Rigidbody rb;

    private float c1 = 0f;
	public int z=0;
	private Vector3 v0;
	private Vector3 start_impulse;
	private float distanse=0;
	private Vector3 cos;
	public float alfa;
	private float[] mu = new float[4];
	private Vector3 c0;
    enum Trj
    { prb = 1, elp, gpr, crc }
    void Start()
    { 
		rb=GetComponent<Rigidbody>();
		distanse=transform.position.magnitude;
		//float c0;
		//c0 = Mathf.Sqrt(2f * distanse * 9.8f);

		switch ((Trj)z) {
			case Trj.prb:
			v0=new Vector3(-transform.position.z / distanse, 0, transform.position.x / distanse)*Mathf.Sqrt(2f*9.8f*distanse);
			v0=Vector3.RotateTowards(v0,transform.position,alfa,0);
			//start_impulse=c0*new Vector3(-transform.position.y/distanse,0,transform.position.x/distanse);
			start_impulse = v0;
			//rb.velocity= start_impulse;
			rb.AddForce(start_impulse, ForceMode.Impulse);
			c0=Vector3.Cross(transform.position,v0);
			c1=c0.magnitude;
			//Debug.Log(c1);
			mu[0]=distanse*distanse*9.8f;
			
			
				break;
			case Trj.elp:
			
				v0=new Vector3(-transform.position.z / distanse, 0, transform.position.x / distanse)*Mathf.Sqrt(1.5f*9.8f*distanse);
			v0=Vector3.RotateTowards(v0,transform.position,alfa,0);
			//start_impulse=c0*new Vector3(-transform.position.y/distanse,0,transform.position.x/distanse);
			start_impulse = v0;
			//rb.velocity= start_impulse;
			rb.AddForce(start_impulse, ForceMode.Impulse);
			c0=Vector3.Cross(v0,transform.position);
			c1=Mathf.Sqrt(c0.x*c0.x+c0.y*c0.y+c0.z*c0.z);
			mu[1]=distanse*distanse*9.8f;
			
				break;
			case Trj.gpr:
				v0=new Vector3(-transform.position.z / distanse, 0, transform.position.x / distanse)*Mathf.Sqrt(6f*9.8f*distanse);
			v0=Vector3.RotateTowards(v0,transform.position,alfa,0);
			//start_impulse=c0*new Vector3(-transform.position.y/distanse,0,transform.position.x/distanse);
			start_impulse = v0;
			//rb.velocity= start_impulse;
			rb.AddForce(start_impulse, ForceMode.Impulse);
			c0=Vector3.Cross(v0,transform.position);
			c1=Mathf.Sqrt(c0.x*c0.x+c0.y*c0.y+c0.z*c0.z);
			mu[2]=distanse*distanse*9.8f;
				break;

			case Trj.crc:
			//alfa= Mathf.PI/2;
			//v0= transform.position.normalized;
			v0=new Vector3(-transform.position.z / distanse, 0, transform.position.x / distanse)*Mathf.Sqrt(9.8f*distanse);
			v0=Vector3.RotateTowards(v0,transform.position,alfa,0);
			//start_impulse=c0*new Vector3(-transform.position.y/distanse,0,transform.position.x/distanse);
			start_impulse = v0;
			//rb.velocity= start_impulse;
			rb.AddForce(start_impulse, ForceMode.Impulse);
			c0=Vector3.Cross(v0,transform.position);
			c1=Mathf.Sqrt(c0.x*c0.x+c0.y*c0.y+c0.z*c0.z);
			mu[3]=distanse*distanse*9.8f;
				break;			
		}
		
		
		
		print(z.ToString() + ": " + start_impulse.magnitude.ToString());
		
	
		//calc();

    }

void FixedUpdate()
    {   
        distanse=transform.position.magnitude;


		if (distanse < 0.5f)
		{
			Vector3 nul = new Vector3(0, 0, 0);
			//transform.position=nul;
			rb.AddForce(nul, ForceMode.Impulse);
			rb.isKinematic = true;
			rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
			Debug.Log("Full Stop!");
			Debug.Log(z.ToString() + ": " + transform.position.x.ToString() + " " + transform.position.y.ToString() + " " + transform.position.z.ToString());
			enabled = false;
		}
		else
		{
			Vector3 prit = -transform.position * mu[z-1] / (distanse * distanse * distanse);
			if (z == 4)
			{
				//Debug.Log(prit.magnitude);
			}
			rb.AddForce(prit, ForceMode.Force);
		}
	}

    // Update is called once per frame
    
		
		
		
		
		
		//Debug.Log(distanse);
    
}
