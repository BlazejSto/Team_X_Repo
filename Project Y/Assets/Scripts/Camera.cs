using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform attachedPlayer;
    public float blendAmount = 0.05f;

    Vector3 curPos;
    Vector3 targetPos;
    float zVal;

    void Start()
    {
        curPos = transform.position;//stores the cameras current position
        zVal = curPos.z;//stores the camera's z position
    }
     
    // Update is called once per frame 
    void Update()
    {
        targetPos = attachedPlayer.transform.position;//sets target pos to the player object's position
        curPos = targetPos * blendAmount + curPos * (1.0f - blendAmount);//slowly moves the camera towards the target position
        curPos.z = zVal;//ensures z value never changes
        transform.position = curPos;
    }
}
