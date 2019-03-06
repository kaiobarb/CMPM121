using UnityEngine;
using System.Collections;

// Full credit to: https://forum.unity.com/threads/click-drag-camera-movement.39513/
// by Franco-Marini

public class CameraDrag : MonoBehaviour
{
    private Vector3 WhiteSide;
    private Vector3 BlackSide;
    private Vector3 Origin;
    private Vector3 OtheSide;
    private Vector3 Diference;
    private bool Drag = false;
    private bool Moving = false;
    private float timeCount = 0.0f;

    private Vector3 m_DesiredPosition;
    private Quaternion m_DesiredRotation;
    private Quaternion m_LookAtWhite;
    private Quaternion m_LookAtBlack;
    private Vector3 m_MoveVelocity;

    private float MaxClamp = 60;
    private float MinClamp = 30;

    void Start()
    {
        WhiteSide = Camera.main.transform.position;
        BlackSide = new Vector3(17.5f, 11, 17.5f);
        m_LookAtWhite = new Quaternion(35, 45, 0, -1);
        m_LookAtBlack = new Quaternion(35, 225, 0, -1);
    }

    void Update()
    {
        //Move();
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Drag = false;
        }
        if (Drag == true)
        {
            var rot = transform.localRotation;
            var OilyAngles = new Vector3(
                  Mathf.Clamp(rot.eulerAngles.x, MinClamp, MaxClamp),
                  rot.eulerAngles.y,
                  rot.eulerAngles.z
            );
            var pos = Camera.main.transform.position;
            pos = Origin - Diference;
            //if (pos.y < 11)
            //    pos.y = 11;
            //else if (pos.y > 14)
            //    pos.y = 14;
            Camera.main.transform.position = pos;
            rot.eulerAngles = OilyAngles;
            transform.localRotation = rot;

        }
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(1) && !Moving)
        {
            //Camera.main.transform.position = WhiteSide;
            if (m_DesiredPosition != WhiteSide)
            {
                m_DesiredPosition = WhiteSide;
                m_DesiredRotation = m_LookAtWhite;
                Moving = true;
            }
            else
            {
                m_DesiredPosition = BlackSide;
                m_DesiredRotation = m_LookAtBlack;
                Moving = true;
            }
        }
        else if (Moving)
        {
            Camera.main.transform.localPosition = Vector3.SmoothDamp(Camera.main.transform.localPosition, m_DesiredPosition, ref m_MoveVelocity, 0.2f);
            //Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, m_DesiredRotation, timeCount);
            //timeCount = timeCount + Time.deltaTime;
            
            if (Mathf.Abs(Camera.main.transform.localPosition.magnitude - m_DesiredPosition.magnitude) < new Vector3(0.05f, 0.05f, 0.05f).magnitude)
                Moving = false;
            
        }
        Camera.main.transform.LookAt(new Vector3(7.5f, 0, 7.5f));

    }

    void Move()
    {
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(1))
        {
            //Camera.main.transform.position = WhiteSide;
            if (m_DesiredPosition != WhiteSide)
            {
                m_DesiredPosition = WhiteSide;
                m_DesiredRotation = m_LookAtWhite;
                Camera.main.transform.localPosition = Vector3.SmoothDamp(Camera.main.transform.localPosition, m_DesiredPosition, ref m_MoveVelocity, 0.2f);
                //Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, m_DesiredRotation, timeCount);
                timeCount = timeCount + Time.deltaTime;
            }
            else
            {
                m_DesiredPosition = BlackSide;
                m_DesiredRotation = m_LookAtBlack;
                Camera.main.transform.localPosition = Vector3.SmoothDamp(Camera.main.transform.localPosition, m_DesiredPosition, ref m_MoveVelocity, 0.2f);
                //Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, m_DesiredRotation, timeCount);
                timeCount = timeCount + Time.deltaTime;
            }
        }
        
        // Camera.main.transform.rotation = Vector3.SmoothDamp(transform.rotation, m_DesiredRotation, ref m_MoveVelocity, 0.2f);
    }
}
