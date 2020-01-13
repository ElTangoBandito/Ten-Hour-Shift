using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static PatientClass.Patient mabel;
    public static PatientClass.Patient michael;
    public static PatientClass.Patient dolores;
    public static PatientClass.Patient Tracy;

    public static Dictionary<int, string> playerDialogue = new Dictionary<int, string>();
    public static Dictionary<int, string> mabelDialogue = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        //all patients and player dialogue should be initialized here
        mabel = new PatientClass.Patient("Mabel Coleman");
        michael = new PatientClass.Patient("Michael Kodskey");
        dolores = new PatientClass.Patient("Dolores Valerio");
        Tracy = new PatientClass.Patient("Tracy");

        initializeRubyDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initializeRubyDialogue()
    {
        mabelDialogue.Add(1, "Hello dear, how are you?");
        mabelDialogue.Add(2, "Good bye.");
    }

}
