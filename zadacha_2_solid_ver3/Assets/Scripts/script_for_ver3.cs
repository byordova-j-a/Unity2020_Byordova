using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_for_ver3 : MonoBehaviour
{
	private float G=0.667f;
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
	  private Vector3 h;
	    private Vector3 y1;
		  private Vector3 x1;
	   private Vector3 z1;
	   private float c=0;
	   private float p=0;
	   private float mu=0;
	   private float phi;
	   private float phi0=0;
	   private float phi00=0;
	   private float rx=0;
	   private float ry=0;
	   private float rz=0;
	     private float e=0;
		 private float rr=0;
		 private Matrix4x4 r44;
		 private Vector4 r4;
	 private float t=0;
	 private Matrix4x4 A;
	private Matrix4x4 Aminus;
    // Start is called before the first frame update
    void Start()
    { 
	mu=G*(m1+m2);
	r10=obj1.transform.position;
	 r20=obj2.transform.position;
	 obj3.transform.position=(m1*r10+m2*r20)/(m1+m2);
	 r0=r20-r10;
	 v0=v20-v10;
        h=Vector3.Cross(r0,v0);
		 z1=Vector3.Cross(r0,h);
		
		y1=Vector3.Normalize(h);
		z1=Vector3.Normalize(z1);
		x1=Vector3.Normalize(r0);
		c=h.magnitude;
		p=c*c/mu;
	if (Mathf.Abs(c*c/r0.magnitude-mu)<1f/1000f) {phi0=0;}
		else
			if (Mathf.Abs(v0.magnitude*v0.magnitude-c*c/(r0.magnitude*r0.magnitude))<1f/1000f) {phi0=0;}
		else
		{phi0=Mathf.Atan2((c*Mathf.Sqrt(v0.magnitude*v0.magnitude-c*c/(r0.magnitude*r0.magnitude))),(c*c/r0.magnitude-mu));}
	
	 e=Mathf.Abs(Mathf.Sqrt(1f+c*c/(mu*mu)*(v0.magnitude*v0.magnitude-2*mu/r0.magnitude)));
	 phi00=phi0;
	 phi =phi0;
	// A=new Matrix4x4(new Vector4(x1.x,x1.y,x1.z,0),new Vector4(y1.x,y1.y,y1.z,0),new Vector4(z1.x,z1.y,z1.z,0),new Vector4(0,0,0,1));
    // Update is called once per frame
	Debug.Log(r0.magnitude);
    }
	

    void FixedUpdate()
    { 
	rr=p/(1f+e*Mathf.Cos(phi-phi0));
        
		phi=phi00+Time.fixedDeltaTime*c*(1+e*Mathf.Cos(phi00-phi0))*(1+e*Mathf.Cos(phi00-phi0))/(p*p);
		
		//r44=A* new Matrix4x4(new Vector4(rr*Mathf.Cos(phi-phi0),0,0,0),new Vector4(0,0,0,0),new Vector4(rr*Mathf.Sin(phi-phi0),0,0,0),new Vector4(1,0,0,0));
		//r4=r44.GetRow(0);
		rx=x1.x*rr*Mathf.Cos(phi-phi0)+z1.x*rr*Mathf.Sin(phi-phi0);
		ry=x1.y*rr*Mathf.Cos(phi-phi0)+z1.y*rr*Mathf.Sin(phi-phi0);
		rz=x1.z*rr*Mathf.Cos(phi-phi0)+z1.z*rr*Mathf.Sin(phi-phi0);
		
		
		r=new Vector3(rx,ry,rz);
	
		rst=((m1*v10+m2*v20)/(m1+m2))*t+((m1*r10+m2*r20)/(m1+m2));
		Debug.Log(r0);
		Debug.Log(x1);
		//Debug.Log(Mathf.Sqrt(r0.x*r0.x+r0.y*r0.y+r0.z*r0.z));
		//Debug.Log(r44);
		//Debug.Log(r.magnitude);
		r1=-m2/(m1+m2)*r+rst;
		r2=m1/(m1+m2)*r+rst;
		obj1.transform.position=r1;
		obj2.transform.position=r2;
		  phi00=phi;
		obj3.transform.position=rst;
			t= t+Time.fixedDeltaTime;
    }
}
