using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltAround : MonoBehaviour
{
    private Quaternion localRotation; // 
    public float speed = 1.0f; // ajustable speed from Inspector in Unity editor
    public GameObject testObject;
    // Use this for initialization
    void Start()
    {
        // copy the rotation of the object itself into a buffer
        localRotation = transform.rotation;
    }


    void Update() // runs 60 fps or so
    {
        Renderer rend = testObject.GetComponent<Renderer>();
        //Create a new Material
        Material material = new Material(Shader.Find("Standard"));
        if (Input.touchCount > 0)
        {

            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                case TouchPhase.Moved:
                    material.color = Color.green;
                    //Fetch the Renderer from the GameObject
                    Debug.Log(localRotation);
                    Debug.Log(Input.acceleration);

                    if (Input.acceleration.x < -0.9)
                    {

                        //localRotation = Quaternion.Euler(0, -90, 0);
                        localRotation.y = -1;
                    }
                    else if (Input.acceleration.x > 0.9)
                    {
                        //localRotation = Quaternion.Euler(0, 90, 0);
                        localRotation.y = 1;
                    }
                    else
                    {
                        localRotation = Quaternion.Euler(90, 0, 0);
                        //localRotation.y = 0;
                        //localRotation.y += Input.acceleration.x * curSpeed;
                        //localRotation.x += Input.acceleration.y * curSpeed;
                    }
                    transform.rotation = localRotation;
                    break;
                case TouchPhase.Ended:
                    material.color = Color.white;
                    break;
            }
            //Switch to new material
            rend.material = material;
        }

    }

}
