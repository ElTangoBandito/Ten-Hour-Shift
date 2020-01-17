using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControllerScript : MonoBehaviour
{
    public Text patientUIDialogue;
    public GameObject chatButton;
    public GameObject helpButton;
    public GameObject leaveButton;

    public GameObject button0;
    public GameObject button1;
    public GameObject button2;
    public Text stupidButton;
    public Text stupidButtonBigBrother;
    public Text stupidButtonLilBrother;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
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
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chatWithPatient(){
        turnOffButtons();
        Globals.progressTime();
        int happinessIncrease = 15;
        switch (Globals.roomNumber){
            case 2:
            Globals.currentSkitNumber = getSkitNumber(Globals.michael);
            if(Globals.michael.dialogue[Globals.currentSkitNumber].hasNextLine())
            {
                patientUIDialogue.text = Globals.michael.dialogue[Globals.currentSkitNumber].getNextLine();
            }
            Globals.michael.happiness += happinessIncrease;
                break;
            case 3:
            Globals.currentSkitNumber = getSkitNumber(Globals.mabel);
            if(Globals.mabel.dialogue[Globals.currentSkitNumber].hasNextLine())
            {
                patientUIDialogue.text = Globals.mabel.dialogue[Globals.currentSkitNumber].getNextLine();
            }
            Globals.mabel.happiness += happinessIncrease;
                break;
            case 4:
            Globals.currentSkitNumber = getSkitNumber(Globals.dolores);
            if(Globals.dolores.dialogue[Globals.currentSkitNumber].hasNextLine())
            {
                patientUIDialogue.text = Globals.dolores.dialogue[Globals.currentSkitNumber].getNextLine();
            }
            Globals.dolores.happiness += happinessIncrease;
                break;
        }
    }
    public void clickNextLine(){
        switch (Globals.roomNumber){
            case 2:
            if (Globals.michael.dialogue[Globals.currentSkitNumber].hasNextLine())
            {
                patientUIDialogue.text = Globals.michael.dialogue[Globals.currentSkitNumber].getNextLine();

            }
            if (!Globals.michael.dialogue[Globals.currentSkitNumber].hasNextLine() && Globals.michael.dialogue[Globals.currentSkitNumber].needPlayerInputNow){
                Globals.michael.dialogue[Globals.currentSkitNumber].needPlayerInputNow = false;
                //set button text to words
                if(Globals.michael.dialogue[Globals.currentSkitNumber].playerResponses.Count == 3){
                    turnOnThreeButtons();
                    stupidButton.text = Globals.michael.dialogue[Globals.currentSkitNumber].playerResponses[0];
                    stupidButtonBigBrother.text = Globals.michael.dialogue[Globals.currentSkitNumber].playerResponses[1];
                    stupidButtonLilBrother.text = Globals.michael.dialogue[Globals.currentSkitNumber].playerResponses[2];
                }
                if(Globals.michael.dialogue[Globals.currentSkitNumber].playerResponses.Count == 2){
                    turnOnTwoButtons();
                    stupidButton.text = Globals.michael.dialogue[Globals.currentSkitNumber].playerResponses[0];
                    stupidButtonBigBrother.text = Globals.michael.dialogue[Globals.currentSkitNumber].playerResponses[1];
                }
            } 
            else if (Globals.michael.dialogue[Globals.currentSkitNumber].playerInputRequired && Globals.buttonSelected < 4){
                if (Globals.michael.dialogue[Globals.currentSkitNumber].hasNextBranchingLine(Globals.buttonSelected)){
                    patientUIDialogue.text = Globals.michael.dialogue[Globals.currentSkitNumber].getBranchingLine(Globals.buttonSelected);
                }
            }
            if(Globals.michael.dialogue[Globals.currentSkitNumber].skitIsOver){
                //skit is over, clean up the UI!
                Globals.buttonSelected = 99;
                turnOnButtons();
            }
                break;
            case 3:
            if (Globals.mabel.dialogue[Globals.currentSkitNumber].hasNextLine())
            {
                patientUIDialogue.text = Globals.mabel.dialogue[Globals.currentSkitNumber].getNextLine();

            }
            if (!Globals.mabel.dialogue[Globals.currentSkitNumber].hasNextLine() && Globals.mabel.dialogue[Globals.currentSkitNumber].needPlayerInputNow){
                Globals.mabel.dialogue[Globals.currentSkitNumber].needPlayerInputNow = false;
                //set button text to words
                if(Globals.mabel.dialogue[Globals.currentSkitNumber].playerResponses.Count == 3){
                    turnOnThreeButtons();
                    stupidButton.text = Globals.mabel.dialogue[Globals.currentSkitNumber].playerResponses[0];
                    stupidButtonBigBrother.text = Globals.mabel.dialogue[Globals.currentSkitNumber].playerResponses[1];
                    stupidButtonLilBrother.text = Globals.mabel.dialogue[Globals.currentSkitNumber].playerResponses[2];
                }
                if(Globals.mabel.dialogue[Globals.currentSkitNumber].playerResponses.Count == 2){
                    turnOnTwoButtons();
                    stupidButton.text = Globals.mabel.dialogue[Globals.currentSkitNumber].playerResponses[0];
                    stupidButtonBigBrother.text = Globals.mabel.dialogue[Globals.currentSkitNumber].playerResponses[1];
                }
            } 
            else if (Globals.mabel.dialogue[Globals.currentSkitNumber].playerInputRequired && Globals.buttonSelected < 4){
                if (Globals.mabel.dialogue[Globals.currentSkitNumber].hasNextBranchingLine(Globals.buttonSelected)){
                    patientUIDialogue.text = Globals.mabel.dialogue[Globals.currentSkitNumber].getBranchingLine(Globals.buttonSelected);
                }
            }
            if(Globals.mabel.dialogue[Globals.currentSkitNumber].skitIsOver){
                //skit is over, clean up the UI!
                Globals.buttonSelected = 99;
            }
            if(Globals.mabel.dialogue[Globals.currentSkitNumber].skitIsOver){
                //skit is over, clean up the UI!
                Globals.buttonSelected = 99;
                turnOnButtons();
            }
                break;
            case 4:
            if (Globals.dolores.dialogue[Globals.currentSkitNumber].hasNextLine())
            {
                patientUIDialogue.text = Globals.dolores.dialogue[Globals.currentSkitNumber].getNextLine();

            }
            if (!Globals.dolores.dialogue[Globals.currentSkitNumber].hasNextLine() && Globals.dolores.dialogue[Globals.currentSkitNumber].needPlayerInputNow){
                Globals.dolores.dialogue[Globals.currentSkitNumber].needPlayerInputNow = false;
                //set button text to words
                if(Globals.dolores.dialogue[Globals.currentSkitNumber].playerResponses.Count == 3){
                    turnOnThreeButtons();
                    stupidButton.text = Globals.dolores.dialogue[Globals.currentSkitNumber].playerResponses[0];
                    stupidButtonBigBrother.text = Globals.dolores.dialogue[Globals.currentSkitNumber].playerResponses[1];
                    stupidButtonLilBrother.text = Globals.dolores.dialogue[Globals.currentSkitNumber].playerResponses[2];
                }
                if(Globals.dolores.dialogue[Globals.currentSkitNumber].playerResponses.Count == 2){
                    turnOnTwoButtons();
                    stupidButton.text = Globals.dolores.dialogue[Globals.currentSkitNumber].playerResponses[0];
                    stupidButtonBigBrother.text = Globals.dolores.dialogue[Globals.currentSkitNumber].playerResponses[1];
                }
            } 
            else if (Globals.dolores.dialogue[Globals.currentSkitNumber].playerInputRequired && Globals.buttonSelected < 4){
                if (Globals.dolores.dialogue[Globals.currentSkitNumber].hasNextBranchingLine(Globals.buttonSelected)){
                    patientUIDialogue.text = Globals.dolores.dialogue[Globals.currentSkitNumber].getBranchingLine(Globals.buttonSelected);
                }
            }
            
            if(Globals.dolores.dialogue[Globals.currentSkitNumber].skitIsOver){
                //skit is over, clean up the UI!
                Globals.buttonSelected = 99;
                turnOnButtons();
            }
                break;
        }
    }

    public void buttonZeroClick(){
        Globals.buttonSelected = 0;
        turnOffChatButtons();
        clickNextLine();
        switch (Globals.roomNumber){
            case 2:
                Globals.michael.happiness += Globals.michael.dialogue[Globals.currentSkitNumber].playerChoiceResult[0];
                break;
            case 3:
                Globals.mabel.happiness += Globals.mabel.dialogue[Globals.currentSkitNumber].playerChoiceResult[0];
                break;
            case 4:
                Globals.dolores.happiness += Globals.dolores.dialogue[Globals.currentSkitNumber].playerChoiceResult[0];
                break;
        }
    }
    
    public void buttonOneClick(){
        Globals.buttonSelected = 1;
        turnOffChatButtons();
        clickNextLine();
        switch (Globals.roomNumber){
            case 2:
                Globals.michael.happiness += Globals.michael.dialogue[Globals.currentSkitNumber].playerChoiceResult[1];
                break;
            case 3:
                Globals.mabel.happiness += Globals.mabel.dialogue[Globals.currentSkitNumber].playerChoiceResult[1];
                break;
            case 4:
                Globals.dolores.happiness += Globals.dolores.dialogue[Globals.currentSkitNumber].playerChoiceResult[1];
                break;
        }
    }
    public void buttonTwoClick(){
        Globals.buttonSelected = 2;
        turnOffChatButtons();
        clickNextLine();
        switch (Globals.roomNumber){
            case 2:
                Globals.michael.health += Globals.michael.dialogue[Globals.currentSkitNumber].playerChoiceResult[2];
                break;
            case 3:
                Globals.mabel.health += Globals.mabel.dialogue[Globals.currentSkitNumber].playerChoiceResult[2];
                break;
            case 4:
                Globals.dolores.health += Globals.dolores.dialogue[Globals.currentSkitNumber].playerChoiceResult[2];
                break;
        }
    }

    public void turnOffButtons(){
        chatButton.SetActive(false);
        helpButton.SetActive(false);
        leaveButton.SetActive(false);
    }
    public void turnOnButtons(){
        chatButton.SetActive(true);
        helpButton.SetActive(true);
        leaveButton.SetActive(true);
    }
    public void turnOnThreeButtons(){
        button0.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);        
    }

    public void turnOnTwoButtons(){
        button0.SetActive(true);
        button1.SetActive(true);
    }
    public void turnOffChatButtons(){
        button0.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);        
    }
    int getSkitNumber(PatientClass.Patient patientIn){
            bool skitAvailable = false;
            int skitNumber = 1; //Random.Range(1, Globals.michael.dialogue.Count);
            if (patientIn.isAllSkitPlayed()){
                skitNumber = patientIn.dialogue.Count;
                skitAvailable = true;
            }
            while (!skitAvailable){
                skitNumber = Random.Range(1, patientIn.dialogue.Count);
                if (!patientIn.dialogue[skitNumber].isUsed()){
                    skitAvailable = true;
                }
                if (patientIn.patientName == "Michael Kodskey" && skitNumber == 5){
                    if (!Globals.michael.dialogue[4].isUsed()){
                        skitNumber = 4;
                    }
                }
            }
            return skitNumber;
    }
}
