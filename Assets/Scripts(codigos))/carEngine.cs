using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEngine : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFE;
    public WheelCollider wheelFD;
    public WheelCollider wheelTE;
    public WheelCollider wheelTD;
    private  List<Transform> nodes;
    public int currentNode = 0;
    private void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i=0; i < pathTransforms.Length; i++){
            if(pathTransforms[i] != path.transform){
                nodes.Add(pathTransforms[i]);
            }
        }
    }
    private void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWaypointDistance();
    }

    private void ApplySteer(){
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude)*maxSteerAngle;
        wheelFD.steerAngle = newSteer;
        wheelFE.steerAngle = newSteer;
    }

    private void Drive(){
        wheelTD.motorTorque = 100f;
        wheelTE.motorTorque = 100f;
    }

    private void CheckWaypointDistance(){
        print(Vector3.Distance(transform.position, nodes[currentNode].position));
        if(Vector3.Distance(transform.position, nodes[currentNode].position) <5f){
            if(currentNode == nodes.Count -1){
                currentNode = 0;
            }else{
                currentNode++;
            }
        }
    }
}
