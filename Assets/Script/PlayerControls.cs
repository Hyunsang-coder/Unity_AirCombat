using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{


    [SerializeField] float xSensitivity = 10;
    [SerializeField] float ySensitivity = 10;
    [SerializeField] float xRange = 5;
    [SerializeField] float yRange = 3;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -10f;
    [SerializeField] float controlRollFactor = -5f;

    public float xAxis;
    public float yAxis;
    void Start()
    {
        
    }

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

        float xOffset = xAxis * Time.deltaTime * xSensitivity;
        float yOffset = yAxis * Time.deltaTime * ySensitivity;
        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange + 5);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
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
