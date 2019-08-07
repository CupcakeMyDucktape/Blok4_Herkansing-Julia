using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Animator Anim;
    public GameObject Player;

    public GameObject GetPlayer() {
        return Player;
    }

	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	void Update () {
        Anim.SetFloat("Distance", Vector3.Distance(transform.position, Player.transform.position));
	}
}
