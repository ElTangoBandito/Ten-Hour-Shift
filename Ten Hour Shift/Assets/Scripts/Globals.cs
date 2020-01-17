using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static int currentSkitNumber = 0;
    public static int buttonSelected = 99;
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
        dolores.health = 50;
        initializeMabelDialogue();
        initializeMichaelDialogue();
        initializeDoloresDialogue();

        stress = 0;
        timeHour = 7;
        timeMinute = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void takeBreak(){
        stress -= 50;
        if (stress < 0){
            stress = 0;
        }
        progressTime();
    }

    public static void progressTime(){
        michael.health -= 4;
        dolores.health -= 7;
        mabel.health -= 4;
        michael.happiness -= 5;
        mabel.happiness -= 5;
        dolores.happiness -= 5;
        incrementTime();
    }
    public static void incrementTime()
    {
        timeMinute += 3;
        if (timeMinute == 6)
        {
            timeMinute = 0;
            timeHour += 1;
        }
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

    public static void aidPatient(){
        int aidValue = 35;
        int happiness = 5;
        if (Globals.stress >= 35){
            aidValue = 25;
        }
        if (Globals.stress >= 70){
            aidValue = 15;
            happiness = -10;
        }
        Globals.stress += 15;
        switch (Globals.roomNumber){
            case 2:
                Globals.michael.health += aidValue;
                Globals.michael.happiness += happiness;
                if(Globals.michael.health > 100){
                    Globals.michael.health = 100;
                }
                break;
            case 3:
                Globals.mabel.health += aidValue;
                Globals.mabel.happiness += happiness;
                if(Globals.mabel.health > 100){
                    Globals.mabel.health = 100;
                }
                break;
            case 4:
                Globals.dolores.health += aidValue;
                Globals.dolores.happiness += happiness;
                if(Globals.dolores.health > 100){
                    Globals.dolores.health = 100;
                }
                break;
        }
    }
    void addSkitToPatient(PatientClass.Patient patientIn)
    {
        List<string> patientDialoguesCopy = new List<string>(patientDialogues);
        List<string> playerResponsesCopy = new List<string>(playerResponses);
        List<int> stressRequirementsCopy = new List<int>(stressRequirements);
        List<int> responseResultsCopy = new List<int>(responseResults);
        Dictionary<int, List<string>> branchingDialogueCopy = new Dictionary<int, List<string>>(branchingDialogue);

        SkitClass.Skit skit = new SkitClass.Skit(patientDialoguesCopy, playerResponsesCopy, stressRequirementsCopy, responseResultsCopy, branchingDialogueCopy);
        patientIn.dialogue.Add(numberOfSkit, skit);
        numberOfSkit++;
        clearLists();
    }

    void resetNumberOfSkit()
    {
        numberOfSkit = 1;
    }
    //positive stress value means it needs to be greater than. Negative means it needs to be less than.
    void initializeMabelDialogue()
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
        responseResults.Add(15);
        branchingDialogueTwo.Add("That’s my little sweet pea. This is a picture of her when she graduated from High School.");
        branchingDialogueTwo.Add("She must be real busy, I ain’t seen her in five years.");

        playerResponses.Add("Is that you in the picture? You look very beautiful.");
        stressRequirements.Add(-35);
        responseResults.Add(30);
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
        patientDialogues.Add("Have you talked to Dolores today? She’s such a delight.");
        patientDialogues.Add("You know, I think she feels a little lonely. Sometimes I hear her crying at night.");
        patientDialogues.Add("I don’t know what I’d do if I have what she’s got.");
        patientDialogues.Add("One time, one of the new nurse forgot to give her medicine and she nearly died!");
        addSkitToPatient(mabel);

        //skit 4
        patientDialogues.Add("You got any hobbies? What else do you do for fun besides coming here everyday?");

        playerResponses.Add("I like to read");
        stressRequirements.Add(0);
        responseResults.Add(0);
        branchingDialogueOne.Add("Reading? You don’t look like someone who reads.");
        branchingDialogueOne.Add("(After a short pause, Mabel breaks into a chuckle.)");
        branchingDialogueOne.Add("I’m just kidding, there’s not much I can do in this room besides reading.");
        branchingDialogueOne.Add("I know I’m not supposed to, but sometimes I read my novel after our night curfew.");
        branchingDialogueOne.Add("Now, don’t you go telling anyone about that.");

        playerResponses.Add("I like to dance.");
        stressRequirements.Add(0);
        responseResults.Add(15);
        branchingDialogueTwo.Add("Really? You know I was a ballad dancer when I was young.");
        branchingDialogueTwo.Add("I used to perform all the time for my school. Oh, you should’ve seen me then!");
        branchingDialogueTwo.Add("The music, the audience, and the spotlight…");
        branchingDialogueTwo.Add("(Mabel’s eyes light up as she reminisces her younger days. For a moment, you caught a glimpse of a younger woman sitting in that chair.)");
        branchingDialogueTwo.Add("Well, that was all long ago when I could still feel my legs.");

        combine2Branches();
        addSkitToPatient(mabel);

        //skit 5
        patientDialogues.Add("Must be hard taking care of everyone here.");
        patientDialogues.Add("I know what that’s like, I had to raise three little munchkins all by myself.");
        patientDialogues.Add("When you’re in a house with two boys and a girl running around screaming and crying all the time you can’t even hear yourself breathe!");
        patientDialogues.Add("I get up in the morning, I clean up the house, make breakfast, and take care of a baby girl and all I get from them was ‘mama, what’s for dinner?'");
        patientDialogues.Add("You break their little hearts when you tell them no on a new toy, or when you tell your little sweet pea she can’t stay home with mama on her first day of school...");
        patientDialogues.Add("(Mabel turns to the picture of her daughter with a long, yearning gaze.)");
        patientDialogues.Add("And then... they grew up.");
        addSkitToPatient(mabel);

        //skit 6
        patientDialogues.Add("Did you know Michael had a son? Imagine him, raising a child.");
        patientDialogues.Add("He came to visit years ago, he was a real gentleman.");
        patientDialogues.Add("Oh, and very handsome too.");
        patientDialogues.Add("(Mabel chortles.)");
        patientDialogues.Add("He’s nothing like that old fool. I still can’t believe that was his son.");
        patientDialogues.Add("That was the first time and the last time I saw him.");
        addSkitToPatient(mabel);

        //skit 7
        patientDialogues.Add("I’m always asking you nurses questions. How about this time you ask me something?");
        patientDialogues.Add("Go on, I’m in the mood to talk about anything.");

        playerResponses.Add("Don’t you have anything better to do than gossip about people?");
        stressRequirements.Add(70);
        responseResults.Add(-25);
        branchingDialogueOne.Add("Excuse me?");
        branchingDialogueOne.Add("I’m going to pretend you didn’t ask me that.");
        branchingDialogueOne.Add("(Mabel turns her head away from you as if you are no longer in her room.)");

        playerResponses.Add("What’s the secret to life?");
        stressRequirements.Add(0);
        responseResults.Add(0);
        branchingDialogueTwo.Add("Secret to life? If I knew I wouldn’t be here now would I? And I sure won’t tell you for free.");
        branchingDialogueTwo.Add("(Mabel lets out a jeering snicker).");
        branchingDialogueTwo.Add("Let me see… You live your life everyday to the fullest, you pursue your dreams, and you don’t let anything or anyone stop you.");
        branchingDialogueTwo.Add("You do what makes you happy.");
        branchingDialogueTwo.Add("And you don’t marry a good for nothing man that I call my husband.");

        playerResponses.Add("What’s your husband like?");
        stressRequirements.Add(0);
        responseResults.Add(5);
        branchingDialogueThree.Add("Him? Imagine a hard working man who pays the bill.");
        branchingDialogueThree.Add("(From the spark in her eyes, you can tell she’s been waiting to talk about this for a very long time.)");
        branchingDialogueThree.Add("He helps his wife with the dishes, take care of the kids on his free time.");
        branchingDialogueThree.Add("He doesn’t drink, and he comes home everyday after work.");
        branchingDialogueThree.Add("Now that’s a man that wasn’t anything like my husband.");
        combine3Branches();
        addSkitToPatient(mabel);

        //skit 8 when all skit is used.

        patientDialogues.Add("(You had a brief chat with Mabel.)");
        addSkitToPatient(mabel);

        resetNumberOfSkit();

    }
    
    void initializeMichaelDialogue()
    {
        //skit 1
        patientDialogues.Add("Hmph... about time you showed up.");
        patientDialogues.Add("Tell me, how much are they paying you to do your job so shitty?");

        playerResponses.Add("Not enough to deal with cranky old men like you.");
        stressRequirements.Add(70);
        responseResults.Add(10);
        branchingDialogueOne.Add("Heh… well, look who grew some balls.");
        branchingDialogueOne.Add("I’m cranky alright. Having to deal with terrible nurses like you all day pisses me off.");
        branchingDialogueOne.Add("But hey, at least you’re honest. Maybe you’re not so bad.");

        playerResponses.Add("Is there anything I can get you, Mr. Kodskey?");
        stressRequirements.Add(35);
        responseResults.Add(-25);
        branchingDialogueTwo.Add("(Mr. Kodskey scoffs at you and gives you a stern look.)");
        branchingDialogueTwo.Add("Of course you can’t answer a simple question.");
        branchingDialogueTwo.Add("This place might as well hire one of them illegals down by the hardware store.");
        branchingDialogueTwo.Add("Not only would he do your job better, but he’d do it for dirt cheap too!");

        playerResponses.Add("It pays the rent, but not much else.");
        stressRequirements.Add(-35);
        responseResults.Add(0);
        branchingDialogueThree.Add("(Mr. Kodskey cackles so hard, he starts to have a coughing fit. He hits his chest with his fist a couple times to get himself to stop.)");
        branchingDialogueThree.Add("Well, that’s what you youngins get for voting in a president who raises the taxes so damn high!");
        branchingDialogueThree.Add("I say you kids deserve it. Still, it’s a shame to see you ruin the country I fought for.");
        combine3Branches();
        addSkitToPatient(michael);

        //skit 2
        patientDialogues.Add("Lemme ask you something. I know you don’t like me, that’s easy to tell.");
        patientDialogues.Add("But if you had to choose, who’d you say you hate the second most here?");

        playerResponses.Add("Mrs. Coleman.");
        stressRequirements.Add(35);
        responseResults.Add(10);
        branchingDialogueOne.Add("Hoo boy, I’m with you there! If there’s one thing I can’t stand in this world, it’s a chatty woman.");
        branchingDialogueOne.Add("That woman’s mouth moves a mile a minute. I wouldn’t mind smacking her in the gob.");
        branchingDialogueOne.Add("And don’t get me started on her family. Can’t trust ‘em, especially those young boys of hers.");
        branchingDialogueOne.Add("I swear, one of them’s gonna come in here and steal something one of these days.");

        playerResponses.Add("Ms. Valerio.");
        stressRequirements.Add(70);
        responseResults.Add(-25);
        branchingDialogueTwo.Add("(Mr. Kodskey’s lips tighten, and his eyes fixate on you in a disapproving glare.)");
        branchingDialogueTwo.Add("The sick lady? The hell is wrong with you?");
        branchingDialogueTwo.Add("Now, it’s true that she and her family probably came here in the back of some dirty truck.");
        branchingDialogueTwo.Add("But damn, if she isn’t the nicest Mexican I’ve ever met. You’d have to be a cold son of a bitch not to like her.");

        playerResponses.Add("I don’t hate anyone here, Mr. Kodskey. You included.");
        stressRequirements.Add(-35);
        responseResults.Add(0);
        branchingDialogueThree.Add("(Michael sneers and rolls his eyes slowly at you.)");
        branchingDialogueThree.Add("(He opens his mouth to say something. Then, he sighs irritably and looks out the window.)");
        combine3Branches();
        addSkitToPatient(michael);

        //skit 3
        patientDialogues.Add("(You walk into Mr. Kodskey’s room. He requested to use a bedpan.)");
        patientDialogues.Add("(You prepare it for use, and gingerly flip him on his side.)");
        patientDialogues.Add("Christ, it’s just a bedpan! What’re you handling me so tenderly for? What, are you a queer or something?");

        playerResponses.Add("Yes.");
        stressRequirements.Add(-70);
        responseResults.Add(-20);
        branchingDialogueOne.Add("Oh, is that right?");
        branchingDialogueOne.Add("Well, you better not try any of that gay shit on me. I’m not having a queer wipe my ass.");
        branchingDialogueOne.Add("I’ve killed men stronger than you with my bare hands in Korea. Just you try it!");
        branchingDialogueOne.Add("(You decide to call in another nurse to handle Mr. Kodskey’s situation.)");

        playerResponses.Add("No.");
        stressRequirements.Add(-70);
        responseResults.Add(10);
        branchingDialogueTwo.Add("(Mr. Kodskey lets out a weak laugh.)");
        branchingDialogueTwo.Add("Relax, kid. I’m just messing with ya.");
        branchingDialogueTwo.Add("I’m an old man who can’t shit by himself. A bit of conflict makes life worth living.");

        playerResponses.Add("That’s none of your business, Mr. Kodskey.");
        stressRequirements.Add(70);
        responseResults.Add(0);
        branchingDialogueThree.Add("Oh, I’m pretty sure it’s my business when you’re the one cleaning out my shitpan!");
        branchingDialogueThree.Add("I bet you just love the smell of it. Don’t you, queer? Does that get you going?");
        branchingDialogueThree.Add("(Mr. Kodskey snickers as you storm out of his room, fuming, to give him some privacy.)");
        combine3Branches();
        addSkitToPatient(michael);

        //skit 4
        patientDialogues.Add("(You walk into Mr. Kodskey's room for a routine check-up. He's sitting in recliner, holding something small and square.)");
        patientDialogues.Add("(To your surprise, his eyes are wet and puffy. As you enter the room, he wipes his eyes and puts the square in his pocket.)");
        patientDialogues.Add("Christ, kid, you scared the shit outta me! Did you even fucking knock?!");

        playerResponses.Add("I was just checking on you. Is there anything I can get you?");
        stressRequirements.Add(-35);
        responseResults.Add(5);
        branchingDialogueOne.Add("Yeah, you can get the hell outta here!");
        branchingDialogueOne.Add("(As you turn towards the door, you hear Mr. Kodskey sigh. You pause and look at him again.)");
        branchingDialogueOne.Add("Look… I’ll be alright. Thank you.");
        branchingDialogueOne.Add("(Michael mutters under his breath, fidgets uncomfortably, and stares at the window. You decide to walk towards the door, content to leave the tense situation on a polite note.)");

        playerResponses.Add("I didn't know you had any emotions other than 'anger'.");
        stressRequirements.Add(70);
        responseResults.Add(-35);
        branchingDialogueTwo.Add("Oh, I didn’t know you were a comedian! Here’s a joke for you: “Looks like this asshole can shit AND cry”?");
        branchingDialogueTwo.Add("Now run along and practice your stand-up routine… you dirty, slimy sperm bucket.");
        branchingDialogueTwo.Add("(As good as it felt to knock Mr. Kodskey down a peg, you couldn’t help but feel bad. He was obviously upset about something.)");

        playerResponses.Add("What did you just put in your pocket, Mr. Kodskey?");
        stressRequirements.Add(-70);
        responseResults.Add(0);
        branchingDialogueThree.Add("It’s none of your damn business!");
        branchingDialogueThree.Add("Look, why don’t you just get outta my room already? I don’t need you here, dipshit!");
        branchingDialogueThree.Add("(You gladly heed Mr. Kodskey’s advice and make a quick exit.)");
        combine3Branches();
        addSkitToPatient(michael);

        //skit 5
        patientDialogues.Add("(Mr. Kodskey requested for his bed reclined a bit higher. As you lift his mattress, he gives you an apologetic look.)");
        patientDialogues.Add("Look, I just wanted to say… I’m sorry about everything I said earlier today.");
        patientDialogues.Add("(He reaches into his pants, pulls out a small square, and hands it to you. It’s a black-and-white photograph of a young Asian woman, no older than 18.)");
        patientDialogues.Add("A boy gave me this photograph today and asked me if I remember her. How could I ever forget her?");
        patientDialogues.Add("My squadron arrived to a tiny, ransacked village. The Commies left her to die, bloody and half-naked at her front door.");
        patientDialogues.Add("There weren’t many survivors. Most would’ve given up, but she… she had a strong heart. I stayed there for a week, nursing her. She wanted so badly to keep going.");
        patientDialogues.Add("His grandmother passed away years ago, but he said that if it weren’t for me... if it weren’t for me...");
        patientDialogues.Add("(Mr. Kodskey breaks down into tearful sobs, his body shaking violently.)");

        playerResponses.Add("(Sit down and comfort Mr. Kodskey.)");
        stressRequirements.Add(-35);
        responseResults.Add(40);
        branchingDialogueOne.Add("(You sit beside Mr. Kodskey on his mattress and place your hand on his shoulder. After a minute or two, he takes a couple of deep breaths and his body stops trembling.)");
        branchingDialogueOne.Add("(He reaches up with his wrinkled hand and leaves it on yours for a few seconds. Then, he brushes your hand away.)");
        branchingDialogueOne.Add("Alright, that’s enough. No needing to get all soft here. Now get outta here.");
        branchingDialogueOne.Add("(Mr. Kodskey shoos you towards the door. As you glance at him briefly before leaving, you could’ve sworn that you saw him smiling.)");

        playerResponses.Add("Everyone is capable of being good and strong, Mr. Kodskey. Even you.");
        stressRequirements.Add(-35);
        responseResults.Add(10);
        branchingDialogueTwo.Add("(Mr. Kodskey takes a few seconds to calm himself down before responding.)");
        branchingDialogueTwo.Add("I’m not so sure, kid. People are pretty terrible... invading, stealing, raping, killing each other constantly.");
        branchingDialogueTwo.Add("I sure as hell ain’t no saint. But that I got to do at least one good thing before I rot in Hell, well... that’s good enough for me.");
        branchingDialogueTwo.Add("(As he finishes his sentence, you’re startled to hear him start snoring. He’s had a long day, so you get up and tiptoe quietly out of his room.)");

        playerResponses.Add("Mr. Kodskey, please stop crying. It’s really not your thing.");
        stressRequirements.Add(35);
        responseResults.Add(0);
        branchingDialogueThree.Add("(Mr. Kodskey almost immediately stops crying. He chokes back a sob and wipes his eyes dry.)");
        branchingDialogueThree.Add("You’re right, kid. Crying is for pussies.");
        branchingDialogueThree.Add("There’s only one fact that matters: in this life, only the strongest survive. You’d best not forget that.");
        branchingDialogueThree.Add("(Mr. Kodskey stares at you silently, as if trying to force his lesson into your head with his mind.)");
        branchingDialogueThree.Add("(Soon, it becomes too awkward to stay there any longer. You dismiss yourself sheepishly, and leave Mr. Kodskey to his memories.)");
        combine3Branches();
        addSkitToPatient(michael);

        //skit 6 when all skit is used.
        patientDialogues.Add("(You walk in on Mr. Kodskey as he’s watching an old World War II documentary.)");
        patientDialogues.Add("Ah… Good ‘ol Ike. Now THERE was a president I’d like to have back.");
        patientDialogues.Add("He lead our boys to victory in World War II, and threatened to nuke those Commies to kingdom come if they didn’t surrender in Korea!");
        patientDialogues.Add("They oughta make it mandatory to enlist if you wanna run this country. Military men are men of action!");
        patientDialogues.Add("Not too many men like him anymore… you kids today are too fucking soft nowadays.");
        patientDialogues.Add("You spend too much time talking about what’s wrong with the world. But who’s gonna do what’s gotta be done to make it right?");
        patientDialogues.Add("Not the lazy brats asking for handouts. Not the kids getting trophies for just showing up. And certainly not YOU, dipshit.");
        patientDialogues.Add("(Mr. Kodskey shows a modicum of wisdom every now and then, but his presentation… needs a little work.)");
        addSkitToPatient(michael);

        //skit 7
        patientDialogues.Add("(You enter Mr Kodskey’s room, and big surprise… he seems especially peeved about something.)");
        patientDialogues.Add("Seems like everyone nowadays just expects to get their way. Back in my day, if you wanted something, you had to fight for it...");
        patientDialogues.Add("What about you, pansy ass? Is there anything in life you’d fight for?");

        playerResponses.Add("My friends and family.");
        stressRequirements.Add(-35);
        responseResults.Add(5);
        branchingDialogueOne.Add("Hmm… hard to argue with that. Especially when you’re talking about your countrymen.");
        branchingDialogueOne.Add("Though, there are definitely a few family members I wouldn’t have minded putting a bullet in!");
        branchingDialogueOne.Add("(Michael cackles at his own disturbing joke. In his fit of laughter, you take the opportunity to slip out quietly.)");

        playerResponses.Add("Freedom of expression.");
        stressRequirements.Add(70);
        responseResults.Add(15);
        branchingDialogueTwo.Add("(It feels almost unnatural to see Michael smile so widely. It’s about as pleasant as orange-flavored toothpaste.)");
        branchingDialogueTwo.Add("Fighting for the right to say anything you want? Well, if that ain’t the most Goddamn American thing I’ve heard all day!");
        branchingDialogueTwo.Add("You know, kid, maybe there’s hope for you and your generation yet!");

        playerResponses.Add("Equal representation and care for everyone.");
        stressRequirements.Add(-70);
        responseResults.Add(-20);
        branchingDialogueThree.Add("Heh… Of course, I should’ve expected that hippy bullshit from someone like you.");
        branchingDialogueThree.Add("Not everyone on God’s green earth is equal, you know. There’s a reason we’re all different colors, coming from different places.");
        branchingDialogueThree.Add("People like you believe that the world should be all about kumbaya and all that crap.");
        branchingDialogueThree.Add("You’re the ones who end up getting taken advantage of. Then who’re the ones who have to bail you out?");
        branchingDialogueThree.Add("(You decide to leave Michael alone, but his words don’t discourage you. He obviously has his own opinions, and you have yours.)");
        combine3Branches();
        addSkitToPatient(michael);
        //skit 8

        patientDialogues.Add("(You had a brief chat with Michael.)");
        addSkitToPatient(michael);

        resetNumberOfSkit();
    }

    void initializeDoloresDialogue()
    {
        //skit 1
        patientDialogues.Add("You look stressed. Sit down, I’ll tell you a story from my days in Peñón Blanco.");
        patientDialogues.Add("I was hanging laundry, when I was young. As I reached out the window to hang a towel...");
        patientDialogues.Add("I slipped and fell out the window! The grass below was soft, but I hit my head on something hard and passed out.");
        patientDialogues.Add("¡Ay, mi cabeza! When I woke up, I forgot who I was. My cousin spent an hour trying to convince me I was the queen of Spain!");
        patientDialogues.Add("Oh, don’t give me that look. I’m okay now! It was nice being a royal for a short while.");
        patientDialogues.Add("(Her story puts you at ease. Getting to rest for a short while is nice, too.)");
        addSkitToPatient(dolores);

        //skit 2
        patientDialogues.Add("(Dolores has a bittersweet smile on her face. Her eyes seem somewhat glazed over.)");
        patientDialogues.Add("My hometown holds a big fiesta this time of year for San Diego. Music, food, parades through the town streets...");
        patientDialogues.Add("One year, when I was an adolescente, I was crowned ‘La flor más bella del ejido’  ̶  the most beautiful flower in the land.");
        patientDialogues.Add("But ah… of course, this flower wilted a long, long time ago.");

        playerResponses.Add("I think you’re as beautiful as ever, Ms. Valerio.");
        stressRequirements.Add(-35);
        responseResults.Add(20);
        branchingDialogueOne.Add("Ah... gracias, that warms my heart.");
        branchingDialogueOne.Add("Maybe this old flower hasn’t lost all her petals after all, eh?");
        branchingDialogueOne.Add("(That comment probably just made her day. She seems to be in much higher spirits!)");

        playerResponses.Add("Is there anything I can get for you, Ms. Valerio?");
        stressRequirements.Add(-35);
        responseResults.Add(0);
        branchingDialogueTwo.Add("Oh, no. I’ll be okay. I like to think about the past every now and then.");
        branchingDialogueTwo.Add("But gracias, don’t be a stranger! I like our little visits.");

        playerResponses.Add("Well… you’ve certainly had better days, I’ll admit.");
        stressRequirements.Add(35);
        responseResults.Add(-20);
        branchingDialogueThree.Add("Mmm... I suppose you’re right. Can you imagine if I tried out for that competition today?");
        branchingDialogueThree.Add("(Ms. Valerio gave a sad, soft chuckle as you leave. You wonder if what you said was something she needed to hear.)");
        combine3Branches();
        addSkitToPatient(dolores);

        //skit 3
        patientDialogues.Add("(As you enter the room, Ms. Valerio is recovering from a particularly harsh coughing fit.)");
        patientDialogues.Add("Oh, thank goodness… Nurse, I think it’s time for me to have my medicine.");
        patientDialogues.Add("Do you happen to have it with you?");

        playerResponses.Add("Yes.");
        stressRequirements.Add(-35);
        responseResults.Add(20);
        branchingDialogueOne.Add("(You prepare the IV bag by attaching it to the infusion pump, then connecting the tube to the needle in Ms. Valerio’s arm.)");
        branchingDialogueOne.Add("(She breathes out a relieved sigh. Her eyes flutter shut slowly as she drifts to sleep).");
        branchingDialogueOne.Add("That feels... much better... Thank you, my child...");

        playerResponses.Add("No.");
        stressRequirements.Add(35);
        responseResults.Add(-20);
        branchingDialogueTwo.Add("No hay problema… I’m sure you were getting to it very soon.");
        branchingDialogueTwo.Add("But please, whenever you can… My body is aching.");
        branchingDialogueTwo.Add("(She didn’t look so good. She needs her medication, pronto.)");

        combine2Branches();
        addSkitToPatient(dolores);

        //skit 4
        patientDialogues.Add("(You check on Ms. Valerio, who’s watching a TV show. Two women shout at each other in Spanish, then one suddenly slaps the other in the face.)");
        patientDialogues.Add("Ahh, I see you’re interested in my telenovela! Dime, child, do you know any Español?");

        playerResponses.Add("Sí, un poco!");
        stressRequirements.Add(35);
        responseResults.Add(10);
        branchingDialogueOne.Add("(Ms. Valerio’s face brightens up, and she cheerfully starts speaking to you in Spanish.)");
        branchingDialogueOne.Add("(Whether it’s her dialect, or the speed at which she’s speaking, you find yourself struggling to keep up with the conversation.)");
        branchingDialogueOne.Add("(You’re a bit confused when you leave her room, but she seems thrilled to have found someone to speak Spanish to. Better brush up on it next time!)");

        playerResponses.Add("No...");
        stressRequirements.Add(-35);
        responseResults.Add(10);
        branchingDialogueTwo.Add("Well, that’s not true. You just said a word in Spanish right there!");
        branchingDialogueTwo.Add("(Ms. Valerio giggles at her own joke. You can’t help but to smile and laugh with her.)");

        playerResponses.Add("Not much, but I’ve always wanted to learn more!");
        stressRequirements.Add(35);
        responseResults.Add(10);
        branchingDialogueThree.Add("Oh! Well, if you ever want free lessons, you know where to go.");
        branchingDialogueThree.Add("And if I were you, I’d take them soon. These lessons won’t be around much longer, if you catch my drift.");
        branchingDialogueThree.Add("(As Ms. Valerio laughs at her own dark joke, you laugh nervously and edge yourself closer to the door.)");
        combine3Branches();
        addSkitToPatient(dolores);

        //skit 5
        patientDialogues.Add("(You come into Ms. Valerio’s room to check her vitals. She’s slowly, but happily munching down a bag of brown candy.)");
        patientDialogues.Add("¡Ay, mijo! Such an amazing boy! My son brought me my favorite candies today. I’m so fortunate!");
        patientDialogues.Add("Here, try one! You’ll like it!");
        patientDialogues.Add("(You find it hard to reject the kind woman’s offer. Your face scrunches as the sweet and sour flavor spreads across your tongue.)");
        patientDialogues.Add("(Ms. Valerio laughs and offers you another piece. You politely decline.)");
        patientDialogues.Add("It’s okay, sweetie. It’s not for everyone, but I appreciate you trying it!");
        patientDialogues.Add("(Trying new things every day isn’t always a bad thing. But you won’t be trying tamarind again anytime soon.)");
        addSkitToPatient(dolores);

        //skit 6
        patientDialogues.Add("(As you come to check up on Ms. Valerio, you notice that she looks forlorn and lost in thought.)");
        patientDialogues.Add("(You must have had a worried look on your face, because she shakes her head suddenly and smiles wistfully.)");
        patientDialogues.Add("Oh, I’ll be okay. It’s just… it’s hard not to feel sad sometimes. Or scared.");
        patientDialogues.Add("Who knows when it’s coming? Today, tomorrow? And what comes next? I used to be so sure, but now...  no lo sé.");

        playerResponses.Add("I’m here for you, no matter what happens. Do you want to talk about it?");
        stressRequirements.Add(35);
        responseResults.Add(0);
        branchingDialogueOne.Add("No, sweetie… you’ve already got enough on your plate, you don’t need to carry my burdens too.");
        branchingDialogueOne.Add("But gracias, I appreciate your support. You’re one of my favorite nurses here for a reason.");
        branchingDialogueOne.Add("(You wish there was more you could do to help, but it looks like she needs some time to be alone.)");

        playerResponses.Add("I know how you feel. But it could be worse, right?");
        stressRequirements.Add(-35);
        responseResults.Add(-20);
        branchingDialogueTwo.Add("Well, I... I guess you have a point, but I don’t see how it could be much worse.");
        branchingDialogueTwo.Add("You mean, like I could have a more aggressive cancer? Hooray… I get to die slower now, I suppose.");
        branchingDialogueTwo.Add("Look, I know that you’re trying to help in your own way. But I just need to be alone right now.");
        branchingDialogueTwo.Add("(You decide to respect her wishes, and make your way towards the door.)");

        playerResponses.Add("Hey, at least you finally lost those extra few pounds!");
        stressRequirements.Add(35);
        responseResults.Add(-35);
        branchingDialogueThree.Add("(There is a gut-wrenching mixture of shock and disgust on Ms. Valerio’s face that you surely weren’t expecting.)");
        branchingDialogueThree.Add("I... um, wow. There’s a lot to unpack with that comment. I think I need to be left alone.");
        branchingDialogueThree.Add("... What’re you standing there for?! ¡Vete!");
        branchingDialogueThree.Add("(You’ve never seen her so angry since she moved in.Maybe it would be best to cut your losses and leave...)");
        combine3Branches();
        addSkitToPatient(dolores);

        //skit 7 when all skit is used
        patientDialogues.Add("(You had a brief chat with Dolores.)");
        addSkitToPatient(dolores);

        resetNumberOfSkit();
    }
}
