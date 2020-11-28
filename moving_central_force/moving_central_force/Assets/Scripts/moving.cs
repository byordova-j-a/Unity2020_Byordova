using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class moving : MonoBehaviour
{public TextMeshProUGUI textv0;
	private float mu=0;
	private float v0=0;
	public float alpha=0;
	private float beta=0;
	private float r=0;
    private float r0=0;
    private float rx=0;
	private float ry=0;
	private float rz=0;
	private float phi0=0;
	private float phi=0;
	private float t=0;
	private float c=0;
	private float e=0;
	private float p=0;
	private float g=9.8f;
	private float alpha1=0;
	private float phi00=0;
	void Settextv0()
	{
		textv0.text="ellips,v0: "+v0.ToString();
	}
    // Start is called before the first frame update
    void Start()
    { 
	
	 r0=transform.position.magnitude;
	  //rx=transform.position.x;
		//ry=transform.position.y;
		//rz=transform.position.z;
	  // r0=Mathf.Sqrt(rx*rx+ry*ry+rz*rz);
	v0=Mathf.Sqrt( 1.5f*r0*9.8f);
	    mu=r0*r0*9.8f;
	    alpha1=alpha*2f*Mathf.PI/180f;
		
	Settextv0();
		
		c=r0*v0*Mathf.Cos(alpha1);
        e=Mathf.Abs(Mathf.Sqrt(1f+v0*v0*Mathf.Cos(alpha1)*Mathf.Cos(alpha1)*(v0*v0-2f*g*r0)/(g*g*r0*r0)));
		//Debug.Log((c*c/r0-mu).ToString()+" "+mu.ToString());
		
		if (Mathf.Abs(c*c/r0-mu)<1f/1000f) {phi0=0;}
		else
			if (Mathf.Abs(v0*v0-c*c/(r0*r0))<1f/1000f) {phi0=0;}
		else
		{phi0=Mathf.Atan2((c*Mathf.Sqrt(v0*v0-c*c/(r0*r0))),(c*c/r0-mu));}
	
		 //Debug.Log(phi0.ToString()+" phi0");
		p=c*c/mu;
		//Debug.Log(phi0);
		phi00=phi0;
		beta=Mathf.Acos(transform.position.x/r0);
    }
	

    // Update is called once per frame
   void FixedUpdate()
    {	
		//t= t+Time.fixedDeltaTime;
		phi=phi00+Time.fixedDeltaTime*c*(1+e*Mathf.Cos(phi00))*(1+e*Mathf.Cos(phi00))/(p*p);
		r=p/(1f+e*Mathf.Cos(phi));
		//Vector3 vect=new Vector3(r*Mathf.Cos(phi),ry,r*Mathf.Sin(phi));
	//Debug.Log(phi);
	//beta=Mathf.Acos(r0*Mathf.Cos(0)/r0);
		transform.position=new Vector3(r*Mathf.Cos(phi-phi0)*Mathf.Cos(beta)-r*Mathf.Sin(phi-phi0)*Mathf.Sin(beta),
		ry,r*Mathf.Cos(phi-phi0)*Mathf.Sin(beta)+r*Mathf.Sin(phi-phi0)*Mathf.Cos(beta));
		phi00=phi;
		//vec=transform.position;
	
		
	//Debug.Log(transform.position);
        
    }
}
