//LMSC-281 Logic and Programming
//adopted from http://answers.unity3d.com/questions/312149/create-a-cube-of-cubes.html
//Fall 2016 Jeanine Cowen

using UnityEngine;
using System.Collections;

public class CreateCubeOfCubes : MonoBehaviour {

	public GameObject cubePrefab;
	int cubeSize = 5;
	int offset = 1;
	
	void Start () {
//		StartCoroutine(CreateCubes()); 	//use if wanting to do this overtime
		CreateCubes();					//use if wanting to do within a single cycle
	}

//	IEnumerator CreateCubes () { 		//use if wanting to do this function over time
	void CreateCubes () {				//use if wanting to complete this function within a single cycle
		for (int zz = 0; zz<cubeSize*offset; zz+=offset) {
			for (int yy = 0; yy<cubeSize*offset; yy+=offset) {
				for (int xx = 0; xx<cubeSize*offset; xx+=offset) {
					Instantiate (cubePrefab, new Vector3(transform.position.x + xx, transform.position.y +yy, transform.position.z + zz), Quaternion.identity);

//					yield return new WaitForEndOfFrame();	//use if wanting to complete these steps over time
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
