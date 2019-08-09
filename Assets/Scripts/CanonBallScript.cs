using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallScript : MonoBehaviour {

    PlayerController PC = new PlayerController();

    public void OnCollisionEnter(Collision Hit) {

        if (Hit.collider.tag == "Player") { 
            PC.Damage();
            //Destroy(gameObject);
        }
    }
}
