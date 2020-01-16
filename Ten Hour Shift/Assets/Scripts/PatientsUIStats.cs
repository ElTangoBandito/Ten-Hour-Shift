using UnityEngine;
using UnityEngine.UI;
public class PatientsUIStats : MonoBehaviour
{
    public Text michael;
    public Text mabel;
    public Text dolores;
    // Start is called before the first frame update
    Vector3 inRoomStat, topStat, middleStat;

    void Start()
    {
        inRoomStat = dolores.transform.parent.position;
        topStat = michael.transform.parent.position;
        middleStat = mabel.transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        //michael.gameObject.SetActive(true);
        michael.text =  Globals.michael.patientName +":\n Health: " + Globals.michael.health + "\n Happiness: " + Globals.michael.happiness;
        mabel.text = Globals.mabel.patientName +":\n Health: " + Globals.mabel.health + "\n Happiness: " + Globals.mabel.happiness;
        dolores.text = Globals.dolores.patientName +":\n Health: " + Globals.dolores.health + "\n Happiness: " + Globals.dolores.happiness;

        switch (Globals.roomNumber){
            case 1: //display everything
                michael.transform.parent.gameObject.SetActive(true);
                michael.transform.parent.gameObject.transform.position = topStat;
                mabel.transform.parent.gameObject.SetActive(true);
                mabel.transform.parent.gameObject.transform.position = middleStat;
                dolores.transform.parent.gameObject.SetActive(true);
                break;
            case 2:
                michael.transform.parent.gameObject.SetActive(true);
                michael.transform.parent.gameObject.transform.position = inRoomStat;
                mabel.transform.parent.gameObject.SetActive(false);
                dolores.transform.parent.gameObject.SetActive(false);
                break;
            case 3:
                michael.transform.parent.gameObject.SetActive(false);
                mabel.transform.parent.gameObject.SetActive(true);
                mabel.transform.parent.gameObject.transform.position = inRoomStat;
                dolores.transform.parent.gameObject.SetActive(false);
                break;
            case 4:
                michael.transform.parent.gameObject.SetActive(false);
                dolores.transform.parent.gameObject.SetActive(true);
                dolores.transform.parent.gameObject.transform.position = inRoomStat;
                mabel.transform.parent.gameObject.SetActive(false);
                break;
            default:
                michael.transform.parent.gameObject.SetActive(false);
                mabel.transform.parent.gameObject.SetActive(false);
                dolores.transform.parent.gameObject.SetActive(false);
                break;

        } 
    }
}
