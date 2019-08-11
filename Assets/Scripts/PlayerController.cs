using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {

    //What you can and can't click
    public LayerMask Clickable;

    //Tutorial used for this; https://www.youtube.com/watch?v=MAbei7eMlXg

    Vector3 TargetPosition;
    Vector3 LookAtTarget;
    Quaternion PlayerRot;
    public float ClickDistance = 100f;

    public float RotSpeed = 2;
    public float Speed = 10;

    Rigidbody Rb;

    //Health
    float MaxHealth;
    public float Health = 10;
    public TextMeshProUGUI HealthBar;

    //UI
    public UIScript UI;

    //So the player doesn't instantly move after you pressed play
    bool moving = false;

    private void Awake() {
        Rb = GetComponent<Rigidbody>();
        MaxHealth = Health;
    }

    void Update() {
        HealthBar.text = Health.ToString();

        if (Health <= 0) {
            UI.GameOver();
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
        if (Physics.Raycast(ray, out hit, ClickDistance, Clickable)) {

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
        Health -= 1;
        Debug.Log(Health);
    }

}
