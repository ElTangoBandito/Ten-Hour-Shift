using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static int timeHour;
    public static int timeMinute;
    public static int stress;

    public static PatientClass.Patient mabel;
    public static PatientClass.Patient michael;
    public static PatientClass.Patient dolores;
    public static PatientClass.Patient Tracy;

    public List<string> patientDialogues = new List<string>();
    public List<string> playerResponses = new List<string>();
    public List<int> stressRequirements = new List<int>();
    public List<int> responseResults = new List<int>();
    public List<string> branchingDialogueOne = new List<string>();
    public List<string> branchingDialogueTwo = new List<string>();
    public List<string> branchingDialogueThree = new List<string>();
    public Dictionary<int, List<string>> branchingDialogue = new Dictionary<int, List<string>>();
    int numberOfSkit = 1;
    public static int roomNumber = 1;
    // 1 Hallway
    // 2 Michael
    // 3 Mabel
    // 4 Dolores
    // 5 Breakroom
    // 6 Visiting room

    // Start is called before the first frame update
    void Start()
    {
        //all patients and player dialogue should be initialized here
        mabel = new PatientClass.Patient("Mabel Coleman");
        michael = new PatientClass.Patient("Michael Kodskey");
        dolores = new PatientClass.Patient("Dolores Valerio");
        Tracy = new PatientClass.Patient("Tracy");
        initializeRubyDialogue();

        stress = 0;
        timeHour = 7;
        timeMinute = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }


    void clearLists()
    {
        patientDialogues.Clear();
        playerResponses.Clear();
        stressRequirements.Clear();
        responseResults.Clear();
        branchingDialogueOne.Clear();
        branchingDialogueTwo.Clear();
        branchingDialogueThree.Clear();
        branchingDialogue.Clear();
    }

    void combine3Branches()
    {
        List<string> bd1Copy = new List<string>(branchingDialogueOne);
        List<string> bd2Copy = new List<string>(branchingDialogueTwo);
        List<string> bd3Copy = new List<string>(branchingDialogueThree);
        branchingDialogue.Add(0, bd1Copy);
        branchingDialogue.Add(1, bd2Copy);
        branchingDialogue.Add(2, bd3Copy);
    }

    void combine2Branches()
    {
        List<string> bd1Copy = new List<string>(branchingDialogueOne);
        List<string> bd2Copy = new List<string>(branchingDialogueTwo);
        branchingDialogue.Add(0, bd1Copy);
        branchingDialogue.Add(1, bd2Copy);
    }

    void addSkitToPatient(PatientClass.Patient patientIn)
    {
        List<string> patientDialoguesCopy = new List<string>(patientDialogues);
        List<string> playerResponsesCopy = new List<string>(playerResponses);
        List<int> stressRequirementsCopy = new List<int>(stressRequirements);
        List<int> responseResultsCopy = new List<int>(responseResults);
        Dictionary<int, List<string>> branchingDialogueCopy = new Dictionary<int, List<string>>(branchingDialogue);

        //SkitClass.Skit skit = new SkitClass.Skit(patientDialogues, playerResponses, stressRequirements, responseResults, branchingDialogue);
        SkitClass.Skit skit = new SkitClass.Skit(patientDialoguesCopy, playerResponsesCopy, stressRequirementsCopy, responseResultsCopy, branchingDialogueCopy);
        mabel.dialogue.Add(numberOfSkit, skit);
        //print(mabel.dialogue[1].hasNextLine());
        //print(numberOfSkit);
        //print(mabel.dialogue[numberOfSkit].patientDialogues.Count);
        numberOfSkit++;
        clearLists();
    }

    void resetNumberOfSkit()
    {
        numberOfSkit = 0;
    }
    //positive stress value means it needs to be greater than. Negative means it needs to be less than.
    void initializeRubyDialogue()
    {
        //skit 1
        patientDialogues.Add("(Mabel is seen holding a framed picture in her hands. The photo depicts a smiling young woman wearing a graduation gown. Mabel looks up when she notices you.)");
        patientDialogues.Add("Oh, I didn’t see you there.");

        playerResponses.Add("Just checking up on you, everything okay?");
        stressRequirements.Add(70);
        responseResults.Add(0);
        branchingDialogueOne.Add("Yes, everything’s fine, thank you.");

        playerResponses.Add("Who’s that in the picture?");
        stressRequirements.Add(-70);
        responseResults.Add(5);
        branchingDialogueTwo.Add("That’s my little sweet pea. This is a picture of her when she graduated from High School.");
        branchingDialogueTwo.Add("She must be real busy, I ain’t seen her in five years.");

        playerResponses.Add("Is that you in the picture? You look very beautiful.");
        stressRequirements.Add(-35);
        responseResults.Add(10);
        branchingDialogueThree.Add("No, no, that’s my little sweet pea. But I guess she’s got her mama’s looks don’t she?");
        combine3Branches();
        //branchingDialogue.Add(1, branchingDialogueOne);
        //branchingDialogue.Add(2, branchingDialogueTwo);
        //branchingDialogue.Add(3, branchingDialogueThree);
        addSkitToPatient(mabel);

        //skit 2
        patientDialogues.Add("You won’t believe what happened yesterday!");
        patientDialogues.Add("Now, I asked that man politely to turn down his music at night, that damn old fool told me to shut my snoring mouth first!");

        patientDialogues.Add("Just because he’s fought in the war, it don’t mean he can be rude!");
        addSkitToPatient(mabel);

        //skit 3

        //resetNumberOfSkit();
        //List<string> patientDialoguesIn, List<string> playerResponsesIn, List<int> playerChoiceResultIn, Dictionary<int, List<string>> branchingDialogueIn
        //SkitClass.Skit = new SkitClass.Skit()
        //mabel.dialogue.Add(numberOfSkits, );
    }

}
