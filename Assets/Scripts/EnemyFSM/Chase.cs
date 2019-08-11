using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : EnemyBaseFSM {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator,stateInfo,layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        var Direction = Opponent.transform.position - Enemy.transform.position;
        Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation,
                                                    Quaternion.LookRotation(Direction),
                                                    RotSpeed * Time.deltaTime);
        Enemy.transform.Translate(0, 0, Time.deltaTime * Speed);

    }

}
