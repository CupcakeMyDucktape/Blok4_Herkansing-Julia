using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseFSM : StateMachineBehaviour {

    public GameObject Enemy;
    public GameObject Opponent;

    public float Speed = 5.0f;
    public float RotSpeed = 2.0f;
    public float Accuracy = 3.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemy = animator.gameObject;
        Opponent = Enemy.GetComponent<EnemyAI>().GetPlayer();
    }

}
