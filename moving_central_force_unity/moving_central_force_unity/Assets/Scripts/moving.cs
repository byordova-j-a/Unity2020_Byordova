using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    // Start is called before the first frame update
//	public GameObject obj;
	private Rigidbody rb;
    private float c = 0f;
	public int z=0;
	private Vector3 start_impulse;
	private float distanse=0;
	private Vector3 cos;
	private float alfa;
    enum Trj
    { prb = 1, elp, gpr, crc }
    void Start()
    { 
		rb=GetComponent<Rigidbody>();
		distanse=transform.position.magnitude;
		float c0;
		c0 = Mathf.Sqrt(2f * distanse * 9.8f);

		switch ((Trj)z) {
			case Trj.prb:
			//start_impulse=c0*new Vector3(-transform.position.y/distanse,0,transform.position.x/distanse);
			start_impulse = c0 * new Vector3(-transform.position.y / distanse, 0, transform.position.x / distanse);
			//rb.velocity= start_impulse;
			rb.AddForce(start_impulse, ForceMode.Impulse);
				break;
			case Trj.elp:
			alfa= Mathf.PI/2-Mathf.Atan(1/2);
			start_impulse=c0*new Vector3(-Mathf.Cos(alfa),0,Mathf.Sin(alfa));
			//rb.velocity = start_impulse;
			rb.AddForce(start_impulse, ForceMode.Impulse);
				break;
			case Trj.gpr:
			alfa= Mathf.PI/2-Mathf.Atan(7/4);
			start_impulse=c0*new Vector3(-Mathf.Cos(alfa),0,Mathf.Sin(alfa));
			//rb.velocity = start_impulse;
			rb.AddForce(start_impulse, ForceMode.Impulse);
				break;

			case Trj.crc:
			alfa= Mathf.PI/2;
			//start_impulse=c0*new Vector3(0,0,1);
			start_impulse = c0 * new Vector3(-transform.position.y / distanse, 0, transform.position.x / distanse);
			rb.AddForce(start_impulse, ForceMode.Impulse);
				break;			
		}
		print(z.ToString() + ": " + start_impulse.magnitude.ToString());
		c= distanse*distanse*9.8f;
		calc();
    }
	void calc()
    {
		distanse = transform.position.magnitude;



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
			Vector3 prit = -transform.position * c / (distanse * distanse * distanse);
			if (z == 4)
			{
				//Debug.Log(prit.magnitude);
			}
			rb.AddForce(prit, ForceMode.Force);
		}
	}
    // Update is called once per frame
    void FixedUpdate()
    {

		calc();
		//Debug.Log(distanse);
    }
}
