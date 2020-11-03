using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayatnik : MonoBehaviour
{
    // Start is called before the first frame update
    public float phi0=0;
    public float v0=0;
  private float alfa=0;
    public float l=0;
  
private float a=0;
private float k=0;
private float t=0;
private float x0=0;
    // Start is called before the first frame update
    void Start()
    {   x0=phi0*2*Mathf.PI/180;
        k= Mathf.Sqrt(9.8f/l);
      alfa= Mathf.Atan(x0*k/v0);
      a= Mathf.Sqrt(x0*x0+v0*v0/(k*k));
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
      t= t+Time.fixedDeltaTime;
   
    transform.position=new Vector3(l*Mathf.Sin(a*Mathf.Sin(k*t+alfa)),l-l*Mathf.Cos(a*Mathf.Sin(k*t+alfa)),0);
}
}