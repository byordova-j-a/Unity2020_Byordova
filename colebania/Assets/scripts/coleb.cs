using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coleb : MonoBehaviour
{
   
    public float v0=0;
  private float alfa=0;
    public float m=0;
    public float c=0;
private float a=0;
private float k=0;
private float t=0;
private float x0=0;
    // Start is called before the first frame update
    void Start()
    { x0=transform.position.x;
        k= Mathf.Sqrt(c/m);
	   if (v0==0){ alfa= Mathf.PI/2;}
		else {
		alfa= Mathf.Atan(x0*k/v0);}
      a= Mathf.Sqrt(x0*x0+v0*v0/(k*k));
    
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
      t= t+Time.fixedDeltaTime;
   
    transform.position=new Vector3(a*Mathf.Sin(k*t+alfa),0.5f,0);
        
    }
}
