
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class PatientImageController : MonoBehaviour
{
    public Sprite[] patientImages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Globals.roomNumber)
        {
            case 2: //Micheal
                gameObject.GetComponent<Image>().sprite = patientImages[0];
                break;
            case 3: //Mabel
                gameObject.GetComponent<Image>().sprite = patientImages[1];
                break;
            case 4: //Dolores
                gameObject.GetComponent<Image>().sprite = patientImages[2];
                break;
        }
    }
}
