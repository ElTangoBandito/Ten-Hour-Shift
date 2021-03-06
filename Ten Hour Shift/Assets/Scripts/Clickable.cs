﻿
using UnityEngine;
using UnityEngine.UI;
public class Clickable : MonoBehaviour
{
    public Text patientUIDialogue;
    public Text stupidButton;
    public Text stupidButtonBigBrother;
    public Text stupidButtonLilBrother;
    public Camera m_camera;
    public Vector3 starting_camere_position;
    public GameObject[] clickables;
    public GameObject breakButton;
    public GameObject nextButton;
    //public Transform[] rooms;
    // Start is called before the first frame update
    Vector3 originalEulerAngle, upperRoomEulerAngle, buttomRoomEulerAngle, breakRoomEulerAngle;
    void Start()
    {
        starting_camere_position = m_camera.transform.position;
        originalEulerAngle = m_camera.transform.rotation.eulerAngles;
        breakRoomEulerAngle = new Vector3(10.0f, 90.0f, 0.0f);
        upperRoomEulerAngle = new Vector3(30.0f, 180.0f, 0.0f);
        buttomRoomEulerAngle = new Vector3(30.0f, 0.0f, 0.0f);
        //Debug.Log("cameraPos" + cameraPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            m_camera.transform.position = starting_camere_position;
            m_camera.transform.eulerAngles = originalEulerAngle;
            Globals.roomNumber = 1;
            for (int i = 0; i < clickables.Length; i++)
            {
                clickables[i].SetActive(true);
            }
            breakButton.SetActive(false);
            clearTexts();
        }
    }
    public void clickOnLeave()
    {
        m_camera.transform.position = starting_camere_position;
        m_camera.transform.eulerAngles = originalEulerAngle;
        Globals.roomNumber = 1;
        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].SetActive(true);
        }
        breakButton.SetActive(false);
        clearTexts();
    }
    void clearTexts(){
        stupidButton.text = "";
        stupidButtonBigBrother.text = "";
        stupidButtonLilBrother.text = "";
        patientUIDialogue.text = "";
    }
    private void OnMouseDown()
    {
        if (gameObject.name == "GreenClickable")
        {
            m_camera.transform.position = new Vector3(-37.0f, 7.0f, -29.0f); //green room cam position
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
            Globals.roomNumber = 2;
            for(int i =1; i<clickables.Length; i++) {
                clickables[i].SetActive(false);
            }
            nextButton.SetActive(false);
        }
        else if (gameObject.name == "BlueClickable")
        {

            m_camera.transform.position = new Vector3(-11.0f, 7.0f, -29.0f); //blue room cam position
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
            Globals.roomNumber = 3;
            for (int i = 0; i < clickables.Length; i++)
            {
                if (i == 3)
                    continue;
                clickables[i].SetActive(false);
            }
            nextButton.SetActive(false);
        }
        else if (gameObject.name == "GrassClickable")
        {
            m_camera.transform.position = new Vector3(-11.0f, 7.0f, 33.0f); //grass room cam position
            m_camera.transform.eulerAngles = upperRoomEulerAngle;
            Globals.roomNumber = 4;
            for (int i = 0; i < clickables.Length; i++)
            {
                if (i == 4)
                    continue;
                clickables[i].SetActive(false);
            }
            nextButton.SetActive(false);
        }
        else if (gameObject.name == "PurpleClickable")
        {
            m_camera.transform.position = new Vector3(12.0f, 7.0f, 33.0f); //purple room cam position
            m_camera.transform.eulerAngles = upperRoomEulerAngle;
            Globals.roomNumber = 5;
            for (int i = 0; i < clickables.Length; i++)
            {
                if (i == 5)
                    continue;
                clickables[i].SetActive(false);
            }
        }
        else if (gameObject.name == "BreakroomClickable")
        {
            m_camera.transform.position = new Vector3(-60.0f, 7.0f, 11.0f); //break room cam position
            m_camera.transform.eulerAngles = breakRoomEulerAngle;
            Globals.roomNumber = 5;
            for (int i = 0; i < clickables.Length; i++)
            {
                if (i == 2)
                    continue;
                clickables[i].SetActive(false);
            }
            breakButton.SetActive(true);
        }
        else if (gameObject.name == "MeetingRoomClickable")
        {

            m_camera.transform.position = new Vector3(12.0f, 8.0f, -29.0f); //break room cam position
            m_camera.transform.eulerAngles = buttomRoomEulerAngle;
            Globals.roomNumber = 6;
            for (int i = 0; i < clickables.Length; i++)
            {
                if (i == 1)
                    continue;
                clickables[i].SetActive(false);
            }
        }
    }
}
