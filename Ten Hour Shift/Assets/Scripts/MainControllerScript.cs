using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.mabel.printPatientName();
        while (Globals.mabel.dialogue[1].hasNextLine())
        {
            print(Globals.mabel.dialogue[1].getNextLine());
        }
        if (Globals.mabel.dialogue[1].needPlayerInputNow)
        {
            print(Globals.mabel.dialogue[1].playerResponses[0]);
            while (Globals.mabel.dialogue[1].hasNextBranchingLine(1))
            {
                print(Globals.mabel.dialogue[1].getBranchingLine(1));
            }
            Globals.mabel.dialogue[1].reset();
            print(Globals.mabel.dialogue[1].playerResponses[1]);
            while (Globals.mabel.dialogue[1].hasNextBranchingLine(2))
            {
                print(Globals.mabel.dialogue[1].getBranchingLine(2));
            }
            Globals.mabel.dialogue[1].reset();
            print(Globals.mabel.dialogue[1].playerResponses[2]);
            while (Globals.mabel.dialogue[1].hasNextBranchingLine(3))
            {
                print(Globals.mabel.dialogue[1].getBranchingLine(3));
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
