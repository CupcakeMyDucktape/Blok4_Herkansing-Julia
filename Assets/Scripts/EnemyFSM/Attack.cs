using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : EnemyBaseFSM {

    //Tutorial used; https://www.youtube.com/watch?v=5qDadIloxvU

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        base.OnStateEnter(animator,stateInfo,layerIndex);
        Enemy.GetComponent<EnemyAI>().StartFiring();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        Enemy.transform.LookAt(Opponent.transform.position);
        var Direction = Opponent.transform.position - Enemy.transform.position;
        Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation,
                                                    Quaternion.LookRotation(Direction),
                                                    RotSpeed * Time.deltaTime);
        Enemy.transform.Translate(0, 0, Time.deltaTime * (Speed/3));
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        Enemy.GetComponent<EnemyAI>().StopFiring();
    }


}
