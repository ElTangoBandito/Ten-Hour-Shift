
using UnityEngine;
using UnityEngine.UI;

public class LeaveButtonControLLer : MonoBehaviour
{
    public Text patientUIDialogue;
    public Text stupidButton;
    public Text stupidButtonBigBrother;
    public Text stupidButtonLilBrother;
    public Camera m_camera;
    public Vector3 starting_camere_position;
    Vector3 originalEulerAngle;
    public GameObject[] clickables;
    public GameObject breakButton;
    private void Start()
    {
        starting_camere_position = m_camera.transform.position;
        originalEulerAngle = m_camera.transform.rotation.eulerAngles;
    }
    // Start is called before the first frame update
    public void clickLeave()
    {
        //Debug.Log("Move Back");
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

    void clearTexts()
    {
        stupidButton.text = "";
        stupidButtonBigBrother.text = "";
        stupidButtonLilBrother.text = "";
        patientUIDialogue.text = "";
    }
}
