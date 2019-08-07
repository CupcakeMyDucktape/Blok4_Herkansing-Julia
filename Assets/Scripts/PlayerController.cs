using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Tutorial used for this; https://www.youtube.com/watch?v=MAbei7eMlXg

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    public float rotSpeed = 2;
    public float speed = 10;

    //So the player doesn't instantly move after you pressed play
    bool moving = false;

	void Update () {
		if (Input.GetMouseButtonDown(0)){

            SetTargetPosition();
        }
        if (moving) {
            Move();
        }

    }

    void SetTargetPosition() {

        // Turn the mouse position to the envoirment
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Check where you click with your mouse.
        if (Physics.Raycast(ray, out hit, 1000)) {

            targetPosition = hit.point;

            targetPosition.y = transform.position.y;

            lookAtTarget = new Vector3(targetPosition.x - transform.position.x, 
                transform.position.y,
                targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);

            moving = true;
        }
    }

    void Move() {
        //Rotate the tank with a smooth move not instantly
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              playerRot,
                                               rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, 
                                              targetPosition,
                                               speed * Time.deltaTime);

        if (transform.position == targetPosition) {
            moving = false;
        }
    }
}
