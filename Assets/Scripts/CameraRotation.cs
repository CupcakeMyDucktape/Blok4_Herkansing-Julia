using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    //Rotation of the camera using A + D
    //Sites used for this; https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html 
    //Tutorial used; https://www.youtube.com/watch?v=iuygipAigew

    void Update() {

        if (Input.GetKey(KeyCode.A)) transform.Rotate(0, 50 * Time.deltaTime, 0);

        else if (Input.GetKey(KeyCode.D)) transform.Rotate(0, -50 * Time.deltaTime, 0);

        else transform.Rotate(0, 0 * Time.deltaTime, 0);

    }
}
