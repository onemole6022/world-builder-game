
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{

    public FixedJoystick LeftJoystick;
    //public FixedButton Button;
    public FixedTouchField TouchField;
    protected ThirdPersonUserControl Control;
    [SerializeField] Camera cam;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();

    }

    // Update is called once per frame
    void Update()
    {
        //Control.m_Jump = Button.Pressed;
        Control.Hinput = LeftJoystick.Horizontal;
        Control.Vinput = LeftJoystick.Vertical;

        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        cam.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3, 4);
        cam.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - cam.transform.position, Vector3.up);

    }
}