using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Tutorial used; https://www.youtube.com/watch?v=MFQhpwc6cKE

    public Transform Target;

    public float SmoothSpeed = 0.125f;
    public Vector3 Offset;

    void FixedUpdate()
    {
        Vector3 DesiredPosition = Target.position + Offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
        transform.position = SmoothedPosition;  
    }

}
