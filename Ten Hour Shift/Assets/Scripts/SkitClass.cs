using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkitClass : MonoBehaviour
{
    public class Skit
    {
        public List<string> patientDialogues;
        public List<string> playerResponses;
        public List<int> stressRequirements;
        public List<int> playerChoiceResult;

        public Dictionary<int, List<string>> branchingDialogue = new Dictionary<int, List<string>>();
        private int currentDialogueIndex; //iterator for dialogue
        private int currentBranchingDialogueIndex; //iterator for branch dialogue
        public bool skitIsOver;
        public bool needPlayerInputNow; //this is true when the dialogue requires player input at this very moment.
        public bool playerInputRequired;

        public bool actionRequiredFlipped;

        public Skit(List<string> patientDialoguesIn, List<string> playerResponsesIn, List<int> stressRequirementsIn, List<int> playerChoiceResultIn, Dictionary<int, List<string>> branchingDialogueIn)
        {
            patientDialogues = patientDialoguesIn;
            playerResponses = playerResponsesIn;
            playerChoiceResult = playerChoiceResultIn;
            branchingDialogue = branchingDialogueIn;
            stressRequirements = stressRequirementsIn;
            if (playerResponses.Count > 0)
            {
                playerInputRequired = true;
            }
            else
            {
                playerInputRequired = false;
            }
            skitIsOver = false;
            needPlayerInputNow = false;
            currentDialogueIndex = 0;
            currentBranchingDialogueIndex = 0;
            actionRequiredFlipped = false;
        }

        public string getNextLine()
        {
            //returns the next line to chat bubble UI also checks if skit is over or if player responses are needed
            string currentLine = "";
            if (currentDialogueIndex < patientDialogues.Count)
            {
                currentLine = patientDialogues[currentDialogueIndex];
                currentDialogueIndex++;
            }

            return currentLine;
        }

        public bool hasNextLine()
        {
            if (currentDialogueIndex >= patientDialogues.Count)
            {
                if (playerInputRequired && !actionRequiredFlipped)
                {
                    needPlayerInputNow = true;
                    actionRequiredFlipped = true;
                }
                else if (!playerInputRequired)
                {
                    skitIsOver = true;
                }
                return false;
            }
            return true;
        }

        public string getBranchingLine(int branchNumber)
        {
            string currentLine = "";
            if (currentBranchingDialogueIndex < branchingDialogue[branchNumber].Count)
            {
                currentLine = branchingDialogue[branchNumber][currentBranchingDialogueIndex];
                currentBranchingDialogueIndex++;
            }
            hasNextBranchingLine(branchNumber);
            return currentLine;
        }

        public bool hasNextBranchingLine(int branchNumber)
        {
            if (currentBranchingDialogueIndex >= branchingDialogue[branchNumber].Count)
            {
                skitIsOver = true;
                return false;
            }
            return true;
        }

        public bool isUsed()
        {
            return skitIsOver;
        }
        public void reset()
        {
            skitIsOver = false;
            needPlayerInputNow = false;
            currentDialogueIndex = 0;
            currentBranchingDialogueIndex = 0;
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
