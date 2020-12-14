using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_adams : MonoBehaviour
{ 	private  List<Material> texture=new List<Material>();
    private Material materiall;
	public Material materialll;
	private float G=1;
	private float rmod=0;
	public int n;
	public GameObject prefab;
	private List<GameObject> sphere=new List<GameObject>();
	private List<Rigidbody> rb=new List<Rigidbody>();
	private List<Vector3> F=new List<Vector3>();
	private List<Vector3> r=new List<Vector3>();
	private List<float> m=new List<float>();
	private List<Renderer> colour=new List<Renderer>();
	private List<TrailRenderer> tail=new List<TrailRenderer>();
	float Random_position(int i)
	{ 
		if (i%2==0) return (-i+2);
		else return (i/2-2);
		
	}
	float Random_velocity(int i)
	{ 
		if (i%2==0) return (-i*2+2);
		else return (i*3-2);
		
	}
	Material Random_colour(int i, Material materialls)
	{  //materiall=materialll;
	 Material mat= new Material(materialll);
	   switch (i%5)
	   { 
	   case 0: 
	    // Material material = new Material(Shader.Find("Transparent/Diffuse"));
        //material.color = Color.green;
	   //Material mat = new Material(Shader.Find("Specular"));
	 
		
	  mat.color=new Vector4(0f,0f,0f,1f);
	    return mat;
	   break;
	   
		case 1: 
	   mat.color=new Vector4(0f,0f,1f,1f);
	    return mat;
	   break;
	   case 2: 
	   mat.color=new Vector4(0f,1f,1f,1f);
	    return mat;
	   break;
	   case 3: 
	   mat.color=new Vector4(1f,0f,0f,1f);
	    return mat;
	   break;
	    return mat;
	   case 4: 
	   mat.color=new Vector4(1f,1f,1f,1f);
	    return mat;
	   break;
	   default:
               mat.color=new Vector4(0f,1f,1f);
			    return mat;
              break;
			  
	   }
	}
	
	//private List<Vector3> v0=new List<Vector3>();
    // Start is called before the first frame update
    void Start()
	
	
	
	
    { //GameObject a;
//GameObject[] sphere = new GameObject[n];
		// GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Renderer rend = cube.GetComponent<Renderer> ();
       // rend.material = new Material(Shader.Find("Specular"));
		 for (int i=0;i<n;i++)
		 {     F.Add(new Vector3(0,0,0));
			 //sphere.Add(prepfab);
			 //sphere[i].transform.position=new Vector3 (i,i,i);
			 sphere.Add(Instantiate(prefab, new Vector3(Random_position(i),Random_position(i*3),Random_position(-i)), Quaternion.identity));
			 rb.Add(sphere[i].GetComponent<Rigidbody>());
			 colour.Add(sphere[i].GetComponent<Renderer>());
			 
			 colour[i].material=Random_colour(i,materialll);
			 tail.Add(sphere[i].GetComponent<TrailRenderer>());
			 tail[i].material=Random_colour(i,materialll);
			 if (i!=0)
			 {
			 rb[i].mass=i;
			 }
			 m.Add(rb[i].mass);
			
			 
			 r.Add(sphere[i].transform.position);
			 rb[i].AddForce(new Vector3(Random_velocity(i),Random_velocity(i+1),Random_velocity(i-1)), ForceMode.Impulse);
			 
		 }
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
      for (int i=0;i<n;i++)
		 {
			 for (int j=0;j<n;j++)
		{ if (j!=i)
			{ rmod=(r[j]-r[i]).magnitude;
		F[i]=F[i]+ G*m[j]*(r[j]-r[i])/(rmod*rmod*rmod);
			}
		}
			rb[i].AddForce(F[i],ForceMode.Force);			
			 
			 Debug.Log(sphere[i].transform.position);
			 
		 }
		 for (int i=0;i<n;i++)
		 {
			 r[i]=sphere[i].transform.position;
		 }
		 
    }
}
