using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {
    // Array of all BG's and FG's to be parallaxed
    public Transform[] backgrounds;

    //Proportion of camera's movement to move the BGs by
    private float[] parallaxScales;

    //How smooth the parallax is going to be. Must be set above 0
    public float smoothing = 1f;

    //Reference to main camera's transform
    private Transform cam;

    //The position of the camera in the previous frame
    private Vector3 previousCamPos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
