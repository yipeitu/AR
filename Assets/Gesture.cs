using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesture : MonoBehaviour {
    public GameObject testObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Debug.Log("its here");
            //Fetch the Renderer from the GameObject
            Renderer rend = testObject.GetComponent<Renderer>();

            //Create a new Material
            Material material = new Material(Shader.Find("Standard"))
            {
                color = Color.green
            };

            //Switch to new material
            rend.material = material;

        }
    }
}
