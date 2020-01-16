using UnityEngine;
using UnityEngine.UI;
public class PatientsUIStats : MonoBehaviour
{
    public Text michael;
    public Text mabel;
    public Text dolores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //michael.gameObject.SetActive(true);
        michael.text = Globals.michael.patientName +":\n Health: " + Globals.michael.health + "\n Happiness: " + Globals.michael.happiness;
        mabel.text = Globals.mabel.patientName +":\n Health: " + Globals.mabel.health + "\n Happiness: " + Globals.mabel.happiness;
        dolores.text = Globals.dolores.patientName +":\n Health: " + Globals.dolores.health + "\n Happiness: " + Globals.dolores.happiness;

        switch (Globals.roomNumber){
            case 1:
                michael.gameObject.SetActive(true);
                michael.transform.parent.gameObject.SetActive(true);
                mabel.gameObject.SetActive(true);
                mabel.transform.parent.gameObject.SetActive(true);
                dolores.gameObject.SetActive(true);
                dolores.transform.parent.gameObject.SetActive(true);
                break;
            case 2:
                michael.gameObject.SetActive(true);
                mabel.transform.parent.gameObject.SetActive(false);
                mabel.gameObject.SetActive(false);
                dolores.gameObject.SetActive(false);
                dolores.transform.parent.gameObject.SetActive(false);
                break;
            case 3:
                michael.gameObject.SetActive(false);
                michael.transform.parent.gameObject.SetActive(false);
                mabel.gameObject.SetActive(true);
                dolores.gameObject.SetActive(false);
                dolores.transform.parent.gameObject.SetActive(false);
                break;
            case 4:
                michael.gameObject.SetActive(false);
                michael.transform.parent.gameObject.SetActive(false);
                dolores.gameObject.SetActive(true);
                mabel.gameObject.SetActive(false);
                mabel.transform.parent.gameObject.SetActive(false);
                break;
            case 5:
                michael.gameObject.SetActive(false);
                michael.transform.parent.gameObject.SetActive(false);
                mabel.gameObject.SetActive(false);
                mabel.transform.parent.gameObject.SetActive(false);
                dolores.gameObject.SetActive(false);
                dolores.transform.parent.gameObject.SetActive(false);
                break;

        } 
    }
}
