using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public int moveSpeed = 230;

	// Update is called once per frame
	void Update () {
        //Move the bullet trail to the right by the moveSpeed
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

        //Destroy after 2 seconds
        Destroy(this.gameObject, 2);
	}
}
