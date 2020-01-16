﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour
{
    public Camera m_camera;
    public Vector3 starting_camere_position;
    //public Transform[] rooms;
    // Start is called before the first frame update
    Vector3 originalEulerAngle, upperRoomEulerAngle, buttomRoomEulerAngle, breakRoomEulerAngle;
    void Start()
    {
        starting_camere_position = m_camera.transform.position;
        originalEulerAngle = m_camera.transform.rotation.eulerAngles;
        breakRoomEulerAngle = new Vector3(30.0f, 90.0f, 0.0f);
        upperRoomEulerAngle = new Vector3(30.0f, 180.0f, 0.0f);
        buttomRoomEulerAngle = new Vector3(30.0f, 0.0f, 0.0f);
        //Debug.Log("cameraPos" + cameraPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Move Back");
            m_camera.transform.position = starting_camere_position;
            m_camera.transform.eulerAngles = originalEulerAngle;
            Globals.roomNumber = 1;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (gameObject.name == "GreenClickable")
        {
            Debug.Log("Move to green");
            m_camera.transform.position = new Vector3(-37.0f, 7.0f, -29.0f); //green room cam position
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
            Globals.roomNumber = 2;
        }
        else if (gameObject.name == "BlueClickable")
        {
            Debug.Log("Move to blue");
            m_camera.transform.position = new Vector3(-11.0f, 7.0f, -29.0f); //blue room cam position
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
            Globals.roomNumber = 3;
        }
        else if (gameObject.name == "GrassClickable")
        {
            Debug.Log("Move to grass");
            m_camera.transform.position = new Vector3(-11.0f, 7.0f, 33.0f); //grass room cam position
            m_camera.transform.eulerAngles = upperRoomEulerAngle;
            Globals.roomNumber = 4;
        }
        else if (gameObject.name == "PurpleClickable")
        {
            Debug.Log("Move to purple");
            m_camera.transform.position = new Vector3(12.0f, 7.0f, 33.0f); //purple room cam position
            m_camera.transform.eulerAngles = upperRoomEulerAngle;
            Globals.roomNumber = 5;
        }
        else if (gameObject.name == "BreakroomClickable")
        {
            Debug.Log("Move to break room");
            m_camera.transform.position = new Vector3(-55.0f, 8.0f, 11.0f); //break room cam position
            m_camera.transform.eulerAngles = breakRoomEulerAngle;
            Globals.roomNumber = 5;
        }
        else if (gameObject.name == "MeetingRoomClickable")
        {
            Debug.Log("Move to meeting room");
            m_camera.transform.position = new Vector3(12.0f, 8.0f, -29.0f); //break room cam position
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
            Globals.roomNumber = 5;
        }
    }
}
