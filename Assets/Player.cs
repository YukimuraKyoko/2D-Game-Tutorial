using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //To see the class and all public variables in Unity's inspector
    [System.Serializable]

    public class PlayerStats
    {
        public int Health = 100;
    }

    //Creates a PlayerStats object called "playerStats"
    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -20;

    void Update()
    {
        //if player's y position falls below the fall boundary
        if(transform.position.y <= fallBoundary)
        {
            //Kill the player
            DamagePlayer(99999999);
        }
    }

    public void DamagePlayer(int damage)
    {
        //Damage the player
        playerStats.Health -= damage;

        //If player's HP is less than 0
        if(playerStats.Health <= 0)
        {
            //Use GM's killplayer function, pass in this object.
            GameMaster.KillPlayer(this);
        }
    }

}
