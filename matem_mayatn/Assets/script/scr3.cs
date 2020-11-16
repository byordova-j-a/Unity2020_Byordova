using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float phi0=0;
    public float omega0=0;

    public float l=0;
     private float phi00=0;

private float omega=0;
private float phi=0;
private float k=0;
private float k1=0;
private float k2=0;
private float k3=0;
private float k4=0;

    // Start is called before the first frame update
    void Start()
    {   phi00=phi0*2*Mathf.PI/180;
        k= Mathf.Sqrt(9.8f/l);
		
	
     
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
	k1=-k*Mathf.Sin(phi00);
	k2=-k*Mathf.Sin(phi00+k1*Time.fixedDeltaTime/2f);
	k3=-k*Mathf.Sin(phi00+k2*Time.fixedDeltaTime/2f);
	k4=-k*Mathf.Sin(phi00+k3*Time.fixedDeltaTime);
	omega=omega0+(Time.fixedDeltaTime/6f)*(k1+2f*k2+2f*k3+k4);
	k1=omega0;
	k2=omega0+k1*Time.fixedDeltaTime/2f;
	k3=omega0+k2*Time.fixedDeltaTime/2f;
	k4=omega0+k3*Time.fixedDeltaTime;
	phi=phi00+(Time.fixedDeltaTime/6f)*(k1+2f*k2+2f*k3+k4);
	omega0=omega;
	phi00=phi;
     
    transform.position=new Vector3(l*Mathf.Sin(phi),l-l*Mathf.Cos(phi),0);
}
}