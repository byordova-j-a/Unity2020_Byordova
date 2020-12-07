using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
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
	// private Vector3 r30;
	// private Vector3 v3;
	  //private Vector3 r3;
	 
	private Matrix4x4 A;
    // Start is called before the first frame update
    void Start()
    {
        r10=obj1.transform.position;
	 r20=obj2.transform.position;
	 obj3.transform.position=(m1*r10+m2*r20)/(m1+m2);;
	 
	 r0=r20-r10;
	 v0=v20-v10;
	 m= m1*m2/(m1+m2);
	 r1=r10;
	 r2=r20;
	 r=r0;
	 v=v0;
	
    }

    // Update is called once per frame
    void FixedUpdate()
    {  //Debug.Log(Mathf.Sqrt((r.x*r.x+r.y*r.y+r.z*r.z)));
		if (Mathf.Sqrt((r.x*r.x+r.y*r.y+r.z*r.z)) > 1f)
		{
			
		
		v=v0-r0*Time.fixedDeltaTime*G*(m1*m2)/(m*(r0.x*r0.x+r0.y*r0.y+r0.z*r0.z)*
	Mathf.Sqrt((r0.x*r0.x+r0.y*r0.y+r0.z*r0.z)));
	 r=r0+v0*Time.fixedDeltaTime;
	  //rst= (m1*v10+m2*v20)/(m1+m2)*t+(m1*r10+m2*r20)/(m1+m2);
	 // obj1.transform.position=new Vector3(rst.x+m2/(m1+m2)*r.x,rst.y+m2/(m1+m2)*r.y,rst.z+m2/(m1+m2)*r.z);
	 // obj2.transform.position=new Vector3(rst.x-m1/(m1+m2)*r.x,rst.y-m1/(m1+m2)*r.y,rst.z-m1/(m1+m2)*r.z);
     r0=r;
	v0=v;
	 }
	  // v0=v;
	//v3=v30-r30*Time.fixedDeltaTime*G*(m3)/((r30.x*r30.x+r30.y*r30.y+r30.z*r30.z)*
	//Mathf.Sqrt((r30.x*r30.x+r30.y*r30.y+r30.z*r30.z)));
	// Vector3 r3=r30+v30*Time.fixedDeltaTime;
		
	 t= t+Time.fixedDeltaTime;
		rct= (m1*v10+m2*v20)/(m1+m2)*t+(m1*r10+m2*r20)/(m1+m2);
		obj3.transform.position=rct;
		
		
			
		
		r1=-m2/(m1+m2)*r+rct;
		r2=m1/(m1+m2)*r+rct;
		obj1.transform.position=r1;
		obj2.transform.position=r2;
		}
	//	v30=v3;
	//	r30=r3;
    }

