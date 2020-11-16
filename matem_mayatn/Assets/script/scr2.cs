using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float phi0=0;
    public float omega0=0;

    public float l=0;
     private float pphi0=0;

private float omega=0;
private float phi=0;
private float k=0;

    // Start is called before the first frame update
    void Start()
    {   pphi0=phi0*2*Mathf.PI/180;
        k= Mathf.Sqrt(9.8f/l);
	
     
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
	omega=omega0-Time.fixedDeltaTime*k*Mathf.Sin(pphi0);
	phi=pphi0+Time.fixedDeltaTime*omega;
	omega0=omega;
	pphi0=phi;
     
    transform.position=new Vector3(l*Mathf.Sin(phi),l-l*Mathf.Cos(phi),0);
}
}