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


    void Awake()
    {
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start () {
        //Previous frame had the current frame's camera position
        previousCamPos = cam.position;

        //Assigning corresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }

	}
	
	// Update is called once per frame
	void Update () {
        //For each background
        for (int i = 0; i < backgrounds.Length; i++){
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // set a target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create a target position which is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // fade between current position and target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
	}
}
