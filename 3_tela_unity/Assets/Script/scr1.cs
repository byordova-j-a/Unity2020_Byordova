using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr1 : MonoBehaviour
{
	private float G=1;
	private Vector3 r10;
	//private Vector3 F;
	//private Vector3 F1;
	 private Vector3 r20;
	 private Vector3 r30;
	 public Vector3 v10;
	 public Vector3 v20;
	  public Vector3 v30;
	// private Vector3 r1;
	// private Vector3 r2;
	//  private Vector3 vv1;
	// private Vector3 vv2;
	 // private Vector3 r;
	// private Vector3 v1;
	// private Vector3 v2;
	// private Vector3 rst;
	public GameObject obj1;
	private Rigidbody rb1;
	public GameObject obj2;
	private Rigidbody rb2;
	public GameObject obj3;
	private Rigidbody rb3;
	private float rmod=0;
	 private float m1=0;
	 private float m2=0;
	 private float m3=0;
	// private float m=0;
	 private float t=0;
	private Vector3[] F = new Vector3[3];
	private float[] m = new float[3];
	private Vector3[] r = new Vector3[3];
	private Vector3[] r0 = new Vector3[3];
    // Start is called before the first frame update
    void Start()
    {
        r10=obj1.transform.position;
	 r20=obj2.transform.position;
	  r30=obj3.transform.position;
	
	 rb1=obj1.GetComponent<Rigidbody>();
	 rb2=obj2.GetComponent<Rigidbody>();
	 rb3=obj3.GetComponent<Rigidbody>();
	 m1=rb1.mass;
	 m2=rb2.mass;
	 m3=rb3.mass;
	m[0]=m1;
	m[1]=m2;
	m[2]=m3;
	r0[0]=r10;
	r0[1]=r20;
	r0[2]=r30;
	r[0]=r10;
	r[1]=r20;
	r[2]=r30;
	for ( int i=0;i<3;i++)
	{
		F[i]=new Vector3(0,0,0);
		
	}
	// m=m1+m2;
	  //obj3.transform.position=(m1*r10+m2*r20)/(m1+m2);
	  rb1.AddForce(v10, ForceMode.Impulse);
	  rb2.AddForce(v20, ForceMode.Impulse);
	  rb3.AddForce(v30, ForceMode.Impulse);
	 
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
	for (int i=0;i<3;i++)
	{ 
		for (int j=0;j<3;j++)
		{ if (j!=i)
			{ rmod=(r[j]-r[i]).magnitude;
		F[i]=F[i]+ G*m[j]*(r[j]-r[i])/(rmod*rmod*rmod);
			}
		}
		
	
	}
	
	r[0]=obj1.transform.position;
	 r[1]=obj2.transform.position;
	  r[2]=obj3.transform.position;
	//r=obj2.transform.position-obj1.transform.position;
	//rst= obj1.transform.position+m1/(m1+m2)*r;
	// F=G*m1*m2*r/(r.magnitude * r.magnitude* r.magnitude);
//	rb1.AddForce(F, ForceMode.Force);
	//F1=-G*m1*m2*r/(r.magnitude * r.magnitude* r.magnitude);
	rb1.AddForce(F[0], ForceMode.Force);
	rb2.AddForce(F[1], ForceMode.Force);
	rb3.AddForce(F[2], ForceMode.Force);
	// Debug.Log(F);
	// Debug.Log(F1);
		//rst=((m1*v10+m2*v20)/(m1+m2))*t+((m1*r10+m2*r20)/(m1+m2));
		//rst= obj1.transform.position+m1/(m1+m2)*r;
		//rst= (m1*obj1.transform.position+m2*obj2.transform.position)/(m1+m2);
		//Debug.Log(rst);
	//	vv1=rb1.velocity;
		//vv2=rb2.velocity;
		//Debug.Log(Vector3.Cross(r,(vv2-vv1)));
		//obj3.transform.position=rst;
      //  t= t+Time.fixedDeltaTime;
    }
}