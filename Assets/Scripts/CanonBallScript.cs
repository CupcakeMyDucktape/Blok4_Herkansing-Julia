using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallScript : MonoBehaviour {

    public void OnCollisionEnter(Collision Hit) {

        if (Hit.collider.tag == "Player") {
            Hit.gameObject.GetComponent<PlayerController>().Damage();

        }
    }
}
