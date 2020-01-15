using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour
{
    public Camera m_camera;
    public Vector3 starting_camere_position;
    //public Transform[] rooms;
    // Start is called before the first frame update
    Vector3 originalEulerAngle, upperRoomEulerAngle, buttomRoomEulerAngle;
    void Start()
    {
        starting_camere_position = m_camera.transform.position;
        originalEulerAngle = m_camera.transform.rotation.eulerAngles;
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
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (gameObject.name == "GreenClickable")
        {
            Debug.Log("Move to green");
            m_camera.transform.position = new Vector3(-37.0f, 7.0f, -29.0f);
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
        }
        else if (gameObject.name == "BlueClickable")
        {
            Debug.Log("Move to blue");
            m_camera.transform.position = new Vector3(-11.0f, 7.0f, -29.0f);
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
        }
        else if (gameObject.name == "GrassClickable")
        {
            Debug.Log("Move to grass");
            m_camera.transform.position = new Vector3(-11.0f, 7.0f, 33.0f);
            m_camera.transform.eulerAngles = upperRoomEulerAngle;
        }
        else if (gameObject.name == "PurpleClickable")
        {
            Debug.Log("Move to purple");
            m_camera.transform.position = new Vector3(12.0f, 7.0f, 33.0f);
            m_camera.transform.eulerAngles = upperRoomEulerAngle;
        }
    }
}
