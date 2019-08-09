using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Tutorial used for this; https://www.youtube.com/watch?v=MAbei7eMlXg

    Vector3 TargetPosition;
    Vector3 LookAtTarget;
    Quaternion PlayerRot;

    public float RotSpeed = 2;
    public float Speed = 10;

    Rigidbody Rb;

    //Health
    float MaxHealth;
    public float Health = 10;
    public Image HealthBar;

    //UI
    UIScript GO = new UIScript();

    //So the player doesn't instantly move after you pressed play
    bool moving = false;

    private void Awake() {
        Rb = GetComponent<Rigidbody>();

        MaxHealth = Health;
    }

    void Update() {
        HealthBar.fillAmount = Health / MaxHealth;
        //Health -=1;

        if (Health <= 0) {
            GO.GameOver();
        }
    }

    void FixedUpdate () {
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

            TargetPosition = hit.point;

            //TargetPosition.y = Rb.position.y;

            LookAtTarget = new Vector3(TargetPosition.x - Rb.position.x, 
                TargetPosition.y - Rb.position.y,
                TargetPosition.z - Rb.position.z);
            PlayerRot = Quaternion.LookRotation(LookAtTarget);

            moving = true;
        }
    }

    void Move() {
        //Rotate the tank with a smooth move not instantly
        Rb.rotation = Quaternion.Slerp(Rb.rotation,
                                              PlayerRot,
                                               RotSpeed * Time.deltaTime);
        Rb.position = Vector3.MoveTowards(Rb.position, 
                                              TargetPosition,
                                               Speed * Time.deltaTime);

        if (Rb.position == TargetPosition) {
            moving = false;
        }
    }

    public void Damage() {
        Debug.Log("Ah fuck, I can't believe you've done this.");
        Health -= 2;
        Debug.Log(Health);
    }

}
