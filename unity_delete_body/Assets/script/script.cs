using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script: MonoBehaviour
{ 	private  List<Material> texture=new List<Material>();
    private Material materiall;
	public Material materialll;
	private float G=1;
	private float rmod=0;
	static public int n=6;
	public GameObject prefab;
	static public List<GameObject> sphere=new List<GameObject>();
	static public List<Rigidbody> rb=new List<Rigidbody>();
	private List<Vector3> F=new List<Vector3>();
	private List<Vector3> r=new List<Vector3>();
	private List<float> m=new List<float>();
	private List<Renderer> colour=new List<Renderer>();
	private List<TrailRenderer> tail=new List<TrailRenderer>();
	private Collision colls;

	
	GameObject MakePrefab(int i)
	{
		
		GameObject prefab = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Create basic cube instead of prefab
   // GameObject cube = (GameObject)Instantiate(Resources.Load("platform-lg"));
    prefab.AddComponent<SphereCollider>();
     prefab.AddComponent<Rigidbody>();
	prefab.AddComponent<TrailRenderer>();
	prefab.GetComponent<Rigidbody>().useGravity = false;
	prefab.AddComponent<scrpref>();
	prefab.SetActive(true);
	Material mat= new Material(materialll);
	prefab.GetComponent<Renderer>().material=mat;
	prefab.GetComponent<TrailRenderer>().material=mat;
	prefab.GetComponent<TrailRenderer>().time=Mathf.Infinity;
	prefab.GetComponent<TrailRenderer>().startWidth=0.2f;
	prefab.GetComponent<TrailRenderer>().generateLightingData=true;
	prefab.name=i.ToString();
	
	//Instantiate(prefab, r0, Quaternion.identity);	
		//Destroy(prefab);
		
		return prefab;
	}
	
	//void OnTriggerEnter(Collider coll)
	
	//{
		
	//	Destroy(coll.gameObject);
		//coll.gameObject.SetActive(false);
		//Debug.Log("delete");
	//}
	
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
	
	void Awake()
	{   
	 // add rigid body
   // cube.transform.position = new Vector3(x, y, 0);
	//Instantiate(cube, new Vector3(-1,-1,-1), Quaternion.identity);
	
	
	
		 for (int i=0;i<n;i++)
			 
		 {    // Debug.Log(i);
		 
		// F.Add(new Vector3(0,0,0));
			 //sphere.Add(prepfab);
			 //sphere[i].transform.position=new Vector3 (i,i,i);
			// sphere.Add(Instantiate(prefab, new Vector3(Random_position(i),Random_position(i*3),Random_position(-i)), Quaternion.identity));
			 sphere.Add(MakePrefab(i));
			 sphere[i].transform.position=new Vector3 (2*i,3*i,2*i);
			 rb.Add(sphere[i].GetComponent<Rigidbody>());
			 colour.Add(sphere[i].GetComponent<Renderer>());
			 
			 colour[i].material=Random_colour(i,materialll);
			 tail.Add(sphere[i].GetComponent<TrailRenderer>());
			 tail[i].material=Random_colour(i,materialll);
			 if (i==0) {rb[i].mass=1;}else
			 {
			 rb[i].mass=i;
			 }
			 m.Add(rb[i].mass);
			
			 
			 r.Add(sphere[i].transform.position);
			 
			
			rb[i].AddForce(new Vector3(2*i,i,i), ForceMode.Impulse);
			
			//rb[i].AddForce(new Vector3(Random_velocity(i),Random_velocity(i+1),Random_velocity(i-1)), ForceMode.Impulse);
			 
		 }
		 
		 for (int i=0;i<n;i++)
			 {
				 
				  for (int j=0;j<n;j++)
				  {
					  if ((i!=j)&&((r[i]-r[j]).magnitude<=1)&&(sphere[i])&&(sphere[j])) {Destroy(sphere[i]); Destroy(sphere[j]);}
				  }					  
				 
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
	  //  int x = 0;
   // int y = 0;

    // Adding a Prefab/GameObject to Scene using C#. Make sure you create a prefab with the file name
    // "platform-lg" and put it in /assets/resources/

    //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create basic cube instead of prefab
   // int x = 0;
   // int y = 0;

    // Adding a Prefab/GameObject to Scene using C#. Make sure you create a prefab with the file name
    // "platform-lg" and put it in /assets/resources/

   
	
    }
 
    // Update is called once per frame
    void FixedUpdate()
    { 
	//for (int i=0;i<n;i++)
	//{
		//if (sphere[i]!=null)
		//Destroy(sphere[i].gameObject.GetComponent<scrpref>());

	//}
	
    }
}
