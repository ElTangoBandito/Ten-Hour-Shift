using UnityEngine;
using UnityEngine.UI;

public class DialogueUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogueUIObject;
    public GameObject visitingRoomUIObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.roomNumber == 2 || Globals.roomNumber == 3 || Globals.roomNumber == 4)
        {
            dialogueUIObject.SetActive(true);
            visitingRoomUIObject.SetActive(false);
        }

        else if (Globals.roomNumber == 6)
        {
            dialogueUIObject.SetActive(false);
            visitingRoomUIObject.SetActive(true);
        }

        else
        {
            dialogueUIObject.SetActive(false);
            visitingRoomUIObject.SetActive(false);
        }

    }
}
