using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_adams : MonoBehaviour
{ private float G=10;
	public GameObject obj1;
   public GameObject obj2;
    public GameObject obj3;
   private Vector3 r1;
    private Vector3 r2;
	 private Vector3 rr1;
	  private Vector3 rr2;
    private Vector3 r10;
	 private Vector3 r20;
	 private Vector3 r;
	 private Vector3 r0;
	 public Vector3 v10;
	 public Vector3 v20;
	 private Vector3 v1;
	 private Vector3 v2;
	  //public Vector3 v30;
	 private Vector3 rct;
	 private Vector3 v0;
	  private Vector3 v;
	 private Vector3 rst;
	 public float m1;
	 public float m2;
	 private float m=0;
	  private float m3=5;
	 private float t=0;
	 private Vector3 a;
	 private Vector3 b;
	  private Vector3 vi1;
	  private Vector3 vi2;
	  private Vector3 ri1;
	  private Vector3 ri2;
	  private Vector3 ri0;
	  
	// private Vector3 r30;
	// private Vector3 v3;
	  //private Vector3 r3;
	 
	private Matrix4x4 A;
    // Start is called before the first frame update
    void Start()
    {
        r10=obj1.transform.position;
	 r20=obj2.transform.position;
	 obj3.transform.position=(m1*r10+m2*r20)/(m1+m2);
	 a=(m1*r10+m2*r20)/(m1+m2);
	 b=(m1*v10+m2*v20)/(m1+m2);
	 r0=r20-r10;
	 v0=v20-v10;
	 m= m1*m2/(m1+m2);
	 r1=r10;
	 r2=r20;
	 r=r0;
	 v=v0;
	vi1=v10+r*Time.fixedDeltaTime*G*m2/(r.magnitude*
	r.magnitude*r.magnitude);
	vi2=v20-r*Time.fixedDeltaTime*G*m1/(r.magnitude*
	r.magnitude*r.magnitude);
	ri1=r10+v10*Time.fixedDeltaTime;
	ri2=r20+v10*Time.fixedDeltaTime;
	ri0=ri2-ri1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {  //Debug.Log(Mathf.Sqrt((r.x*r.x+r.y*r.y+r.z*r.z)));
		//if (Mathf.Sqrt((r.magnitude)) > 1f)
		//
			v1=vi1+Time.fixedDeltaTime*(ri0*3/2*G*m2/(ri0.magnitude*
	ri0.magnitude*ri0.magnitude) +1/2*r0*G*m2/(r0.magnitude*
	r0.magnitude*r0.magnitude));
		r1=ri1+Time.fixedDeltaTime*(3/2*vi1 +1/2*v10);
		v2=vi2-Time.fixedDeltaTime*(ri0*3/2*G*m1/(ri0.magnitude*
	ri0.magnitude*ri0.magnitude) +1/2*r0*G*m1/(r0.magnitude*
	r0.magnitude*r0.magnitude));
		r2=ri2+Time.fixedDeltaTime*(3/2*vi2 +1/2*v20);
		
		r0=ri0;
		ri2=r2;
		ri1=r1;
		ri0=ri2-ri1;
		v10=vi1;
		v20=vi2;
		vi1=v1;
		vi2=v2;
		
		//v1=v10+r*Time.fixedDeltaTime*G*m2/(r.magnitude*
	//r.magnitude*r.magnitude);
	// r1=r10+v10*Time.fixedDeltaTime;
	// v2=v20-r*Time.fixedDeltaTime*G*m1/(r.magnitude*
	//r.magnitude*r.magnitude);
	 //r2=r20+v20*Time.fixedDeltaTime;
	  //rst= (m1*v10+m2*v20)/(m1+m2)*t+(m1*r10+m2*r20)/(m1+m2);
	 // obj1.transform.position=new Vector3(rst.x+m2/(m1+m2)*r.x,rst.y+m2/(m1+m2)*r.y,rst.z+m2/(m1+m2)*r.z);
	 // obj2.transform.position=new Vector3(rst.x-m1/(m1+m2)*r.x,rst.y-m1/(m1+m2)*r.y,rst.z-m1/(m1+m2)*r.z);
    // r10=r1;
	//v10=v1;
	//r20=r2;
	//v20=v2;
	//r=r2-r1;
	//v=v2-v1;
	// 
	  // v0=v;
	//v3=v30-r30*Time.fixedDeltaTime*G*(m3)/((r30.x*r30.x+r30.y*r30.y+r30.z*r30.z)*
	//Mathf.Sqrt((r30.x*r30.x+r30.y*r30.y+r30.z*r30.z)));
	// Vector3 r3=r30+v30*Time.fixedDeltaTime;
		
	// t= t+Time.fixedDeltaTime;
		//rct= b*t+a;
		obj3.transform.position=(r1*m1+r2*m2)/(m1+m2);
		
		
			
		
		//r1=-m2/(m1+m2)*r+rct;
		//r2=m1/(m1+m2)*r+rct;
		obj1.transform.position=r1;
		obj2.transform.position=r2;
		//Debug.Log(Vector3.Cross(r,v));
		}
	//	v30=v3;
	//	r30=r3;
    }