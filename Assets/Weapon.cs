using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;

    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;

    float timeToFire = 0;
    Transform firepoint;

	// Use this for initialization
	void Awake () {
        //firepoint is the empty child object called "FirePoint"
        firepoint = transform.FindChild("FirePoint");
        if(firepoint == null)
        {
            Debug.LogError("No emptyobject called FirePoint!");
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        //If a single pistol
		if(fireRate == 0)
        {
            //When left mouse click
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        //Else if it's a machine gun 
        else
        {
            //When left mouse hold down
            if(Input.GetButton("Fire1") && Time.time > timeToFire) // Time.time = time in seconds since the start of the game
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        //Main camera's World Screen (not PC screen), the x/y point is the mouse's x and y position.
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Stores firepoint's position
        Vector2 firePointPosition = new Vector2(firepoint.position.x, firepoint.position.y);

        //Physics2D.Raycast(origin or the start, direction it will go to, distance= how long the line will be,
        //layerMask used to select only which layers to hit)
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100,whatToHit);

        //If current time from start is bigger than time to spawn
        if(Time.time >= timeToSpawnEffect)
        {
            //Spawns effects
            Effect();
            //time to spawn 
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        
        //Draws a line of where the bullet will shoot
        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);

        //If the Raycast hits something, then it will say the object's collider's name.
        if(hit.collider != null)
        {
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
            Debug.DrawLine(firePointPosition, hit.point, Color.red);

        }
    }

    void Effect()
    {
        //Spawn a bullet trail at the firepoint
        Instantiate(BulletTrailPrefab,firepoint.position, firepoint.rotation);

        //Spawn a clone location at the firepoint, and also spawn a muzzle flash
        Transform clone  = (Transform)Instantiate(MuzzleFlashPrefab, firepoint.position, firepoint.rotation);

        //Clone's parent is empty object called "FirePoint"
        clone.parent = firepoint;

        //Create a new variable called size with a random range
        float size = Random.Range(0.6f, 0.9f);

        //Change clone's Scale to a random vector3 size using all "size" variables for xyz
        clone.localScale = new Vector3(size, size, size);
        
        //Destroy clone after 0.02 seconds
        Destroy(clone.gameObject, 0.02f);
    }
}
