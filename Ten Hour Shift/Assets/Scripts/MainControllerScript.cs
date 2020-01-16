using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //print(Globals.mabel.dialogue[2].patientDialogues.Count);
        int skitNumber = Globals.dolores.dialogue.Count;
        print(skitNumber);
        /*
        while (Globals.mabel.dialogue[skitNumber].hasNextLine())
        {
           print(Globals.mabel.dialogue[skitNumber].getNextLine());
        }
        print(Globals.mabel.dialogue[skitNumber].hasNextLine());
        */
        PatientClass.Patient patient = Globals.dolores;
        while (patient.dialogue[skitNumber].hasNextLine())
        {
            print(patient.dialogue[skitNumber].getNextLine());
        }
        if (patient.dialogue[skitNumber].needPlayerInputNow)
        {
            print(patient.dialogue[skitNumber].playerResponses[0]);
            while (patient.dialogue[skitNumber].hasNextBranchingLine(0))
            {
                print(patient.dialogue[skitNumber].getBranchingLine(0));
            }
            patient.dialogue[skitNumber].reset();
            print(patient.dialogue[skitNumber].playerResponses[1]);
            while (patient.dialogue[skitNumber].hasNextBranchingLine(1))
            {
                print(patient.dialogue[skitNumber].getBranchingLine(1));
            }

            patient.dialogue[skitNumber].reset();
            print(patient.dialogue[skitNumber].playerResponses[2]);
            while (patient.dialogue[skitNumber].hasNextBranchingLine(2))
            {
                print(patient.dialogue[skitNumber].getBranchingLine(2));
            }
            

        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
