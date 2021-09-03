using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{


    [SerializeField] float xSensitivity = 10;
    [SerializeField] float ySensitivity = 10;
    [SerializeField] float zSensitivity = 10;
    [SerializeField] float xRange = 5;
    [SerializeField] float yRange = 3;
    [SerializeField] float zRange = 3;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -10f;
    [SerializeField] float controlRollFactor = -5f;

    public float xAxis;
    public float yAxis;
    public float zAxis;
    public float throttleForce = 5;
    
    
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        
    }

    void ProcessTranslation()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        zAxis = Input.GetAxis("Jump");

        float xOffset = xAxis * Time.deltaTime * xSensitivity;
        float yOffset = yAxis * Time.deltaTime * ySensitivity;
        float zOffset = zAxis * Time.deltaTime * zSensitivity;
        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;
        float rawZpos = transform.localPosition.z + zOffset; 
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange + 5);
        float clampedZpos = Mathf.Clamp(rawZpos, -zRange, zRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, clampedZpos);
    }

    void ProcessRotation() 
    {
        float pitchDuetoPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDuetoControl = yAxis * controlPitchFactor;
        float yawDuetoPosition = transform.localPosition.x * positionYawFactor;
        float rollDuetoControl = xAxis * controlRollFactor;

        float pitch = pitchDuetoPosition + pitchDuetoControl;
        float yaw = yawDuetoPosition;
        float roll = rollDuetoControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }



}
