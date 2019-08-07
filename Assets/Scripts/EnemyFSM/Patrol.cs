using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : EnemyBaseFSM {

    GameObject NPC;
    GameObject[] waypoints;
    int currentWP;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //When the state begins the enemy returns to waypoint 0
        NPC = animator.gameObject;
        base.OnStateEnter(animator,stateInfo,layerIndex);
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position,
                             NPC.transform.position) < Accuracy) {

            currentWP++;
            if (currentWP >= waypoints.Length) {
                currentWP = 0;
            }
        }

        //Rotate towards target (the player)
        var direction = waypoints[currentWP].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  1.0f * Time.deltaTime);
        //How fast it moves to the player
        NPC.transform.Translate(0,0, Time.deltaTime * Speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
