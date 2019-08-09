using Ditzelgames;
using LowPolyWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloatPolyWater : MonoBehaviour {

    //Tutorial used; https://www.youtube.com/watch?v=yEGdYM0nk1I&t=9s
    //Dit is zelf verder ook aangepast

    //Public variables
    public float AirDrag = 1;
    public float WaterDrag = 10;
    public Transform[] FloatPoints;
    public bool AttachToSurface;

    //Outside of code collected data
    protected Rigidbody Rigidbody;
    protected Waves Waves;
    protected float waveHeight;

    //Water Line
    protected float WaterLine;
    protected Vector3[] WaterLinePoints;

    //Helping Vectors
    protected Vector3 CenterOffset;
    public Vector3 Center { get { return transform.position + CenterOffset; } }
    protected Vector3 TargetUp;
    protected Vector3 SmoothVectorRotation;


    // Use this for initialization
    void Awake () {
        Waves = FindObjectOfType<Waves>();
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.useGravity = false;

        WaterLinePoints = new Vector3[FloatPoints.Length];
        for (int i = 0; i < FloatPoints.Length; i++)
            WaterLinePoints[i] = FloatPoints[i].position;
        CenterOffset = PhysicsHelper.GetCenter(WaterLinePoints) - transform.position;
	}
	
	void Update () {

        var NewWaterLine = 0f;
        var pointUnderWater = false;

        for (int i = 0; i < FloatPoints.Length; i++) {
            WaterLinePoints[i] = FloatPoints[i].position;
            WaterLinePoints[i].y = waveHeight;
            NewWaterLine += WaterLinePoints[i].y / FloatPoints.Length;
            if (WaterLinePoints[i].y > FloatPoints[i].position.y)
                pointUnderWater = true;
        }

        var WaterLineDelta = NewWaterLine - WaterLine;
        WaterLine = NewWaterLine;

        //Gravity of the Boat
        var Gravity = Physics.gravity;
        Rigidbody.drag = AirDrag;
        if (WaterLine > Center.y) {
            Rigidbody.drag = WaterDrag;

            if (AttachToSurface){
                Rigidbody.position = new Vector3(Rigidbody.position.x, WaterLine - CenterOffset.y, Rigidbody.position.z);
            }
            else{
                Gravity = -Physics.gravity;
                transform.Translate(Vector3.up * WaterLineDelta * 0.9f);
            }
        }
        //Apply gravity
        Rigidbody.AddForce(Gravity * Mathf.Clamp(Mathf.Abs(WaterLine - Center.y), 0, 1));

        //Compute the vector of the waterline points
        TargetUp = PhysicsHelper.GetNormal(WaterLinePoints);

        //Rotation
        if (pointUnderWater) {
            TargetUp = Vector3.SmoothDamp(transform.up, TargetUp, ref SmoothVectorRotation, 0.2f);
            Rigidbody.rotation = Quaternion.FromToRotation(transform.up, TargetUp) * Rigidbody.rotation;
        }
	}
    
    //Draws Cubes to Show where it's Floating
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (FloatPoints == null)
            return;

        for (int i = 0; i < FloatPoints.Length; i++)
        {
            if (FloatPoints[i] == null)
                continue;

            if (Waves != null)
            {

                //draw cube
                Gizmos.color = Color.red;
                Gizmos.DrawCube(WaterLinePoints[i], Vector3.one * 0.1f);
            }

            //draw sphere
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(FloatPoints[i].position, 0.1f);

        }

        //draw center
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(Center.x, WaterLine, Center.z), Vector3.one * 0.5f);
            Gizmos.DrawRay(new Vector3(Center.x, WaterLine, Center.z), TargetUp * 0.5f);
        }
    }
}
