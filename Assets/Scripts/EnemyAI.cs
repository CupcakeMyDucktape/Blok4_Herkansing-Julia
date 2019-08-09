using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Animator Anim;
    public GameObject Player;
    public GameObject CanonBall;
    public GameObject Canon;

    ////Waypoint fixing 101
    //public GameObject[] WP;
    //GameObject Self;
    //int currentWP;

    ////Enemy Spice
    //public float Speed = 10.0f;
    //public float RotSpeed = 2.0f;
    //public float Accuracy = 3.0f;

    void Start()
    {
        Anim = GetComponent<Animator>();


        //Self = gameObject;
        //currentWP = 0;
    }

    void Update()
    {
        Anim.SetFloat("Distance", Vector3.Distance(transform.position, Player.transform.position));
    }

    public GameObject GetPlayer() {
        return Player;
    }

    void Fire() {

        GameObject b = Instantiate(CanonBall, Canon.transform.position, Canon.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(Canon.transform.forward*500);
    }

    public void StartFiring()
    {

        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    public void StopFiring() {

        CancelInvoke("Fire");
    }

   //public void FuelMyDepression() {
   //     Debug.Log("I want to die but I work.");
   //     if (WP.Length == 0) return;
   //     if (Vector3.Distance(WP[currentWP].transform.position,
   //                          Self.transform.position) < Accuracy)
   //     {

   //         currentWP++;
   //         if (currentWP >= WP.Length)
   //         {
   //             currentWP = 0;
   //         }
   //     }

   //     //Rotate towards target (the player)
   //     var direction = WP[currentWP].transform.position - Self.transform.position;
   //     Self.transform.rotation = Quaternion.Slerp(Self.transform.rotation,
   //                                               Quaternion.LookRotation(direction),
   //                                               1.0f * Time.deltaTime);

   //     //How fast it moves to the player
   //     Self.transform.Translate(0, 0, Time.deltaTime * Speed);

   // }
}

