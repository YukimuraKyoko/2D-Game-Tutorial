using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;

    float timeToFire = 0;
    Transform firepoint;

	// Use this for initialization
	void Awake () {
        firepoint = transform.FindChild("FirePoint");
        if(firepoint == null)
        {
            Debug.LogError("No emptyobject called FirePoint!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        Debug.Log("Test");
    }
}
