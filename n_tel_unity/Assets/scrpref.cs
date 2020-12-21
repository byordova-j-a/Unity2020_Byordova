using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpref : MonoBehaviour
{
	private float G=1;
	private float rmod=0;
	private Vector3 F;
	private Rigidbody rbb;
	private float flag=0;
	private List<int> ii=new List<int>();
	private int iii=0;
	

	void OnCollisionEnter(Collision coll)
	
	{ 
			
			
		//Destroy(coll.gameObject.GetComponent<scrpref>());
		Debug.Log("delete");
		Debug.Log(int.Parse(coll.gameObject.name));
		//coll.gameObject.enabled =false;
		ii.Add(int.Parse(coll.gameObject.name));
		Destroy(coll.gameObject);
		flag=1;
		iii=iii+1;
		//if(this.isDestroyed) {}
	//coll.gameObject.name="deleted";
	 // coll.gameObject.tag="deleted";
	 // Debug.Log(GameObject.Find("Scene"));
	  //Debug.Log(coll.gameObject.activeSelf);
	}
	
	
	
	
    // Start is called before the first frame update
    void Start()
    { rbb= GetComponent<Rigidbody>();
         F=new Vector3(0,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
	
	
    { F=new Vector3(0,0,0);
	//Debug.Log(iii+"i");
	//for (int i=0;i<iii;i++)
//	{
	//	Debug.Log(ii[i]+"list");
	//}
	//Debug.Log(flag+"flag");
		
			 //for (int j=0;j<script.n;j++)
		//{ 
//	Debug.Log(script.sphere[j].activeSelf);
	//}
       // Debug.Log(F);
		//Debug.Log("F");
     
			 for (int j=0;j<script.n;j++)
		{ 
	if ( (flag==0)&&(this.name!=script.sphere[j].name))   
			{  //Debug.Log(script.sphere[j].name);
		
		if (!ii.Contains(j)) 
			{//Debug.Log("j");
		//Debug.Log(j+" j");
		//Debug.Log(this.gameObject.activeSelf);
	
	//Debug.Log((this.name!=script.sphere[1].name));

		rmod=(script.sphere[j].transform.position-this.transform.position).magnitude;
		F=F+ G*script.rb[j].mass*rbb.mass*(script.rb[j].transform.position-this.transform.position)/(rmod*rmod*rmod);
			//F=new Vector3(1,1,1);
			//Debug.Log(F);
			}
			}
		}
		if (flag==0)
		this.GetComponent<Rigidbody>().AddForce(F,ForceMode.Force);			
			 
			 
			 
		 
		 
		 
    }
}
