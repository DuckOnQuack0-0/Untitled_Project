using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public Vector3 levelStartLocation;
    private Transform startObject;

    private void Awake()
    {
        // Finding the transform of a gameobject via script in the scene
        startObject = FindObjectOfType<StartObject>().transform;
    }

    private void Start()
    {
        // Visual representation of the position of the starting location on the inspector
        levelStartLocation = startObject.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            print("Button has been pressed!");
            this.transform.position = new Vector3(levelStartLocation.x, levelStartLocation.y, levelStartLocation.z);
        }
    }


}
