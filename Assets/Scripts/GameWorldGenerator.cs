using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 This class is responsible for creating  the game world, 
and creating all possible plot fragments availaible for the system
 
 */
public class GameWorldGenerator : MonoBehaviour
{
    //singleton class
    private static GameWorldGenerator instance;

    // get singleton class
    public static GameWorldGenerator GetInstance()
    {
        return instance;
    }

    [Header("PREFABS")]
    public Transform CharacterParent;
    public GameObject PlayerPrefab;
    public GameObject NPCPrefab;

    [Header("CHARACTERS")]
    public Character Player;
    public Character Father;
    public Character Mother;
    public Character OlderSibling1;
    public Character OlderSibling2;
    public Character YoungerSibling1;
    public Character YoungerSibling2;
    public Character Guard1;
    public Character Guard2;
    public Character Villian;

    [Header("ROLES")]
    // create roles, set them to null initially
    public Role Hero = null;
    public Role Absentee = null;
    public Role Guardian = null;
    public Role InterdictionMessenger = null;

    [Header("STORY VARIABLES")]
    // create variables
    public bool WarExists;
    public string FamilySecret;
    public Vector3 interdictLocation;

   
    [Header("PRECONDITIONS")]
    //Absentation
    public Preconditions absenteeIsOlderGeneration;
    public Preconditions absenteeIsYoungerGeneration;
    public Preconditions absenteeIsMale;
    public Preconditions RiverNearBY;
    public Preconditions MinTimePassed1;
    public Preconditions TooMuchTimePassed1;
    public Preconditions playerTriesLeaving;
    public Preconditions playerSpeaksToAbsentee;
    //Interdiction
    public Preconditions InterdictionLocationExists;
    public Preconditions InterDictionMessengerExists;
    public Preconditions AbsentationCompelted123;
    public Preconditions AbsentationCompelted456;
    public Preconditions MinTimePassed2;
    public Preconditions TooMuchTimePassed2;
    public Preconditions PlayerSpeakstoInterdictionM;
    public Preconditions HeroIsAChild;
    //Violation
    public Preconditions InterdictionCompleted13;
    public Preconditions InterdictionCompleted2;
    public Preconditions HeroGetsWeapon;
    public Preconditions HeroFindsSleepingPotion;
    public Preconditions HeroMakesSleepingTea;
    public Preconditions HeroGivesTeaToGuards;
    public Preconditions HeroLeavesHome;

    [Header("AUTHOR-LEVEL PLOT FRAGMENTS")]
    public List<PlotFragment> Absentation;
    public List<PlotFragment> Interdictipon;
    public List<PlotFragment> Violation;

    [Header("BASIC PLOT FRAGMENTS")]
    //Plots for ABSENTATION: a randomly assigned family member absents themselves(randomly chosen + based on fixed precondition)
    public PlotFragment a1, a2, a3, a4, a5, a6;

    //Plots for INTERDICTION:
    public PlotFragment b1, b2, b3;

    //Plots for VOLOLATION: 
    public PlotFragment c1, c2;


    private Vector3 insPosFather = new Vector3(20, 2.6f, 0);
    private Vector3 insPosMother = new Vector3(23, -1, 0);
    private Vector3 insPosOS1 = new Vector3(-27, 7, 0);
    private Vector3 insPosOS2 = new Vector3(45, -9, 0);
    private Vector3 insPosYS1 = new Vector3(-11, 36, 0);
    private Vector3 insPosYS2 = new Vector3(-17, -8, 0);
    private Vector3 insPosG1 = new Vector3(-28, -4, 0);
    private List<Character> FamilyCharacters = new List<Character>();
    // Family names
    private List<string> FamilyNames = new List<string> { "Featherington", "Danbury", "Basset", "Thompson", "Sharpe", "Cowper", "Brimsley", "Sheffield"};
    //female first names
    private List<string> FemaleFirstNames = new List<string> {"Daphne", "Francesca", "Portia", "Eloise", "Penelope", "Marina", "Cressida", "Kate", "Mary", "Genevieve", "Edwina", "Sienna" ,  "Hyacinth", "Prudence"};
    // male first names
    private List<string> MaleFirstNames = new List<string> {"Gregory", "Jack", "Michael", "Theo", "Benedict", "Colin", "Simon", "Anthony", "Henry", "Will", "Phillip", "Archibald", "Nigel", "Harry", "Peter", "Robert", "Thomas", "George" };
    public List<Preconditions> storyWorldValues = new List<Preconditions>();




    void Awake()
    {
        // set singleton 
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue Manager!");
        }
        instance = this;


        LoadCharacters();
        LoadPreconditions();
        LoadPlotFragments();

    }



private void LoadCharacters()
    {

        Debug.Log("Loading Story...");
        /*
        storyWorldValues.Add(absenteeIsOlderGeneration);
        storyWorldValues.Add(absenteeIsYoungerGeneration);
        storyWorldValues.Add(absenteeIsMale);
        storyWorldValues.Add(RiverNearBY);

        storyWorldValues.Add(MinTimePassed1);
        storyWorldValues.Add(TooMuchTimePassed1);
        storyWorldValues.Add(playerTriesLeaving);
        storyWorldValues.Add(playerSpeaksToAbsentee);

        storyWorldValues.Add(InterdictionLocationExists);
        storyWorldValues.Add(InterDictionMessengerExists);
        storyWorldValues.Add(AbsentationCompelted123);
        storyWorldValues.Add(AbsentationCompelted456);

        storyWorldValues.Add(MinTimePassed2);
        storyWorldValues.Add(TooMuchTimePassed2);
        storyWorldValues.Add(PlayerSpeakstoInterdictionM);
        storyWorldValues.Add(HeroIsAChild);

        storyWorldValues.Add(InterdictionCompleted13);
        storyWorldValues.Add(InterdictionCompleted2);
        storyWorldValues.Add(HeroGetsWeapon);

        storyWorldValues.Add(HeroFindsSleepingPotion);
        storyWorldValues.Add(HeroMakesSleepingTea);
        storyWorldValues.Add(HeroGivesTeaToGuards);
        storyWorldValues.Add(HeroLeavesHome);
        */

        // decide player attributes randomly
        Player = new Character();
        Player.Age = Random.Range(12, 30);
        Player.characterName = "Lord Danbury";
        Player.relationToHero = "is hero";
        Player.prefab = this.PlayerPrefab;


        int x = Random.Range(0, this.FamilyNames.Count - 1);
        string FamName = this.FamilyNames[x];


        // instantiate the Family

        //====FATHER========================================================//

        Father = new Character();
        Father.relationToHero = "Father";
        Father.gender = 'M';
        Father.Age = Random.Range(50, 75);
        // set name 
        x = Random.Range(0, this.MaleFirstNames.Count - 1);
        Father.characterName = this.MaleFirstNames[x] + " " + FamName;
        this.MaleFirstNames.RemoveAt(x);
        this.FamilyCharacters.Add(this.Father);


        //Instantiate character, and set default dialogue
        Father.prefab = Instantiate(NPCPrefab, insPosFather, Quaternion.identity, CharacterParent);
        Father.prefab.name = Father.relationToHero;
        Father.prefab.GetComponent<DialogueTrigger>().dialogue.name = Father.characterName;
        Father.prefab.GetComponent<DialogueTrigger>().dialogue.relation = Father.relationToHero;
        Father.prefab.GetComponent<DialogueTrigger>().dialogue.defaultDialogue();

        //====MOTHER========================================================//
        Mother = new Character();
        Mother.relationToHero = "Mother";
        Mother.gender = 'F';
        Mother.Age = Father.Age - 2;
        // set name 
        x = Random.Range(0, this.FemaleFirstNames.Count - 1);
        Mother.characterName = this.FemaleFirstNames[x] + " " + FamName;
        this.FemaleFirstNames.RemoveAt(x);
        //Mother.prefab = this.MotherPrefab;
        this.FamilyCharacters.Add(Mother);

        //Instantiate character, and set default dialogue
        Mother.prefab = Instantiate(NPCPrefab, insPosMother, Quaternion.identity, CharacterParent);
        Mother.prefab.name = Mother.relationToHero;
        Mother.prefab.GetComponent<DialogueTrigger>().dialogue.name = Mother.characterName;
        Mother.prefab.GetComponent<DialogueTrigger>().dialogue.relation = Mother.relationToHero;
        Mother.prefab.GetComponent<DialogueTrigger>().dialogue.defaultDialogue();








        //====OLDER SIBLING 1 =======================================================//
        OlderSibling1 = new Character();
        // set age
        OlderSibling1.Age = Player.Age + Random.Range(1, 5);
        //OlderSibling1.prefab = this.OSibling1Prefab;
        this.FamilyCharacters.Add(OlderSibling1);
        // Set attributes according to gender
        float y = Random.Range(0f, 1f);

        if(y>= 0.5)
        {
            OlderSibling1.gender = 'F';
            OlderSibling1.relationToHero = "Sister";
            
            //set name
            x = Random.Range(0, this.FemaleFirstNames.Count - 1);
            OlderSibling1.characterName = this.FemaleFirstNames[x] + " " + FamName;
            this.FemaleFirstNames.RemoveAt(x);
        }
        else
        {
            OlderSibling1.gender = 'M';
            OlderSibling1.relationToHero = "Brother";

            // set name
            x = Random.Range(0, this.MaleFirstNames.Count - 1);
            OlderSibling1.characterName = this.MaleFirstNames[x] + " " + FamName;
            this.MaleFirstNames.RemoveAt(x);

        }

        //Instantiate character, and set default dialogue
        OlderSibling1.prefab = Instantiate(NPCPrefab, insPosOS1, Quaternion.identity, CharacterParent);
        OlderSibling1.prefab.name = OlderSibling1.relationToHero;
        OlderSibling1.prefab.GetComponent<DialogueTrigger>().dialogue.name = OlderSibling1.characterName;
        OlderSibling1.prefab.GetComponent<DialogueTrigger>().dialogue.relation = OlderSibling1.relationToHero;
        OlderSibling1.prefab.GetComponent<DialogueTrigger>().dialogue.defaultDialogue();





        //====OLDER SIBLING 2 =======================================================//
        OlderSibling2 = new Character();
        // set age
        OlderSibling2.Age = Player.Age + Random.Range(1, 5);

        this.FamilyCharacters.Add(OlderSibling2);
        // Set attributes according to gender
        y = Random.Range(0f, 1f);
        
        if (y >= 0.5)
        {
            OlderSibling2.gender = 'F';
            OlderSibling2.relationToHero = "Sister";

            //set name
            x = Random.Range(0, this.FemaleFirstNames.Count - 1);
            OlderSibling2.characterName = this.FemaleFirstNames[x] + " " + FamName;
            this.FemaleFirstNames.RemoveAt(x);
        }
        else
        {
            OlderSibling2.gender = 'M';
            OlderSibling2.relationToHero = "Brother";

            // set name
            x = Random.Range(0, this.MaleFirstNames.Count - 1);
            OlderSibling2.characterName = this.MaleFirstNames[x] + " " + FamName;
            this.MaleFirstNames.RemoveAt(x);

        }


        //Instantiate character, and set default dialogue
        OlderSibling2.prefab = Instantiate(NPCPrefab, insPosOS2, Quaternion.identity, CharacterParent);
        OlderSibling2.prefab.name = OlderSibling2.relationToHero;
        OlderSibling2.prefab.GetComponent<DialogueTrigger>().dialogue.name = OlderSibling2.characterName;
        OlderSibling2.prefab.GetComponent<DialogueTrigger>().dialogue.relation = OlderSibling2.relationToHero;
        OlderSibling2.prefab.GetComponent<DialogueTrigger>().dialogue.defaultDialogue();




        //====YOUNGER SIBLING 1 =======================================================//
        YoungerSibling1 = new Character();
        // set age
        YoungerSibling1.Age = Player.Age - Random.Range(1, 5);
        this.FamilyCharacters.Add(YoungerSibling1);
        // Set attributes according to gender
        y = Random.Range(0f, 1f);
       
        if (y >= 0.5)
        {
            YoungerSibling1.gender = 'F';
            YoungerSibling1.relationToHero = "Sister";

            //set name
            x = Random.Range(0, this.FemaleFirstNames.Count - 1);
            YoungerSibling1.characterName = this.FemaleFirstNames[x] + " " + FamName;
            this.FemaleFirstNames.RemoveAt(x);
        }
        else
        {
            YoungerSibling1.gender = 'M';
            YoungerSibling1.relationToHero = "Brother";

            // set name
            x = Random.Range(0, this.MaleFirstNames.Count - 1);
            YoungerSibling1.characterName = this.MaleFirstNames[x] + " " + FamName;
            this.MaleFirstNames.RemoveAt(x);

        }



        //Instantiate character, and set default dialogue
        YoungerSibling1.prefab = Instantiate(NPCPrefab, insPosYS1, Quaternion.identity, CharacterParent);
        YoungerSibling1.prefab.name = YoungerSibling1.relationToHero;
        YoungerSibling1.prefab.GetComponent<DialogueTrigger>().dialogue.name = YoungerSibling1.characterName;
        YoungerSibling1.prefab.GetComponent<DialogueTrigger>().dialogue.relation = YoungerSibling1.relationToHero;
        YoungerSibling1.prefab.GetComponent<DialogueTrigger>().dialogue.defaultDialogue();




        //====YOUNGER SIBLING 2 =======================================================//
        YoungerSibling2 = new Character();
        // set age
        YoungerSibling2.Age = Player.Age - Random.Range(1, 5);
        this.FamilyCharacters.Add(YoungerSibling2);
        // Set attributes according to gender
        y = Random.Range(0f, 1f);
        
        if (y >= 0.5)
        {
            YoungerSibling2.gender = 'F';
            YoungerSibling2.relationToHero = "Sister";

            //set name
            x = Random.Range(0, this.FemaleFirstNames.Count - 1);
            YoungerSibling2.characterName = this.FemaleFirstNames[x] + " " + FamName;
            this.FemaleFirstNames.RemoveAt(x);
        }
        else
        {
            YoungerSibling2.gender = 'M';
            YoungerSibling2.relationToHero = "Brother";

            // set name
            x = Random.Range(0, this.MaleFirstNames.Count - 1);
            YoungerSibling2.characterName = this.MaleFirstNames[x] + " " + FamName;
            this.MaleFirstNames.RemoveAt(x);

        }



        //Instantiate character, and set default dialogue
        YoungerSibling2.prefab = Instantiate(NPCPrefab, insPosYS2, Quaternion.identity, CharacterParent);
        YoungerSibling2.prefab.name = YoungerSibling2.relationToHero;
        YoungerSibling2.prefab.GetComponent<DialogueTrigger>().dialogue.name = YoungerSibling2.characterName;
        YoungerSibling2.prefab.GetComponent<DialogueTrigger>().dialogue.relation = YoungerSibling2.relationToHero;
        YoungerSibling2.prefab.GetComponent<DialogueTrigger>().dialogue.defaultDialogue();



        // Instantiate other characters
        Guard1 = new Character();
        Guard1.relationToHero = "Guard1";
        Guard1.characterName = "not important";
        Guard1.prefab = Instantiate(NPCPrefab, insPosG1, Quaternion.identity, CharacterParent);
        Guard1.prefab.name = Guard1.relationToHero;
        Guard1.prefab.GetComponent<DialogueTrigger>().dialogue.name = Guard1.characterName;
        Guard1.prefab.GetComponent<DialogueTrigger>().dialogue.relation = Guard1.relationToHero;
        Guard1.prefab.GetComponent<DialogueTrigger>().dialogue.defaultDialogue();
        Guard1.prefab.GetComponentInChildren<SpriteRenderer>().color = Color.green;




        // SET ROLES ======================================================================

        // assign hero
        this.Hero = new Role();
        Hero.roleAssignedTo = this.Player;

        this.Absentee = new Role();
        int member = Random.Range(0, this.FamilyCharacters.Count - 1);
        // randomly assign  roles
        this.Absentee.roleAssignedTo = this.FamilyCharacters[member];

        // make sure absentee is not interdiction messenger
        int member2 = Random.Range(0, this.FamilyCharacters.Count - 1);
        while(member2 == member)
        {
            member2 = Random.Range(0, this.FamilyCharacters.Count - 1);
        }
        this.InterdictionMessenger.roleAssignedTo = this.FamilyCharacters[member2];

        float z = Random.Range(0f, 1f);
        if(z >= 0.5)
        {
            this.Guardian.roleAssignedTo = Father;
        }
        else
        {
            this.Guardian.roleAssignedTo = Mother;
        }
        
    }


    private void LoadPreconditions()
    {


        //Absentation
        absenteeIsOlderGeneration = new Preconditions("absenteeIsOlderGeneration", false);
        absenteeIsOlderGeneration.evaluate = new Eval_absenteeIsOlderGeneration();
       
        
        absenteeIsYoungerGeneration = new Preconditions("absenteeIsYoungerGeneration", false);
        absenteeIsMale = new Preconditions("absenteeIsMale", false);
        RiverNearBY = new Preconditions("RiverNearBY", false);


        MinTimePassed1 = new Preconditions("MinTimePassed1", false);
        TooMuchTimePassed1 = new Preconditions("TooMuchTimePassed1", false);
        playerTriesLeaving = new Preconditions("playerTriesLeaving", false);
        playerSpeaksToAbsentee = new Preconditions("playerTriesLeaving", false);

        //Interdiction
        InterdictionLocationExists = new Preconditions("InterdictionLocationExists", false);
        InterDictionMessengerExists = new Preconditions("InterDictionMessengerExists", false);
        AbsentationCompelted123 = new Preconditions("AbsentationCompleted123", false);
        AbsentationCompelted456 = new Preconditions("AbsentationCompleted456", false);


        MinTimePassed2 = new Preconditions("MinTimePassed2", false);
        TooMuchTimePassed2 = new Preconditions("TooMuchTimePassed2", false);
        PlayerSpeakstoInterdictionM = new Preconditions("PlayerSpeakstoInterdictionM", false);
        HeroIsAChild = new Preconditions("HeroIsAChild", false);


        //Violation
        InterdictionCompleted13 = new Preconditions("InterdictionCompleted13", false);
        InterdictionCompleted2 = new Preconditions("InterdictionCompleted2", false);
        HeroGetsWeapon = new Preconditions("HeroGetsWeapon", false);

        HeroFindsSleepingPotion = new Preconditions("HeroFindsSleepingPotion", false);
        HeroMakesSleepingTea = new Preconditions("HeroMakesSleepingTea", false);
        HeroGivesTeaToGuards = new Preconditions("HeroGivesTeaToGuards", false);
        HeroLeavesHome = new Preconditions("HeroLeavesHome", false);

    }



    private void LoadPlotFragments()
    {

        //clear author level plot fragments
        this.Absentation = new List<PlotFragment>();
        this.Interdictipon = new List<PlotFragment>();
        this.Violation = new List<PlotFragment>();

        //Define the plot fragments:

        //Absentation --------------------------------------------------------------------------------------------------

        this.a1 = new PlotFragment();
        a1.Name = ("Absentee  leaves home for business");
        a1.FixedPreconditions.Add(absenteeIsOlderGeneration);
        a1.MutablePreconditions.Add(MinTimePassed1);
        a1.Triggerconditions.Add(TooMuchTimePassed1);
        a1.Triggerconditions.Add(playerTriesLeaving);
        a1.action = new A1_action();
        // a1.level = 0;
        a1.complete = false;
        this.Absentation.Add(a1);



        this.a2 = new PlotFragment();
        a2.Name = ("Absentee  leaves home to fight in war");
        a2.FixedPreconditions.Add(absenteeIsMale);
        a2.FixedPreconditions.Add(absenteeIsOlderGeneration);
        a2.MutablePreconditions.Add(MinTimePassed1);
        a2.Triggerconditions.Add(TooMuchTimePassed1);
        a2.Triggerconditions.Add(playerTriesLeaving);
        a2.action = new A2_action();
        // a2.level = 0;
        a2.complete = false;
        this.Absentation.Add(a2);


        this.a3 = new PlotFragment();
        a3.Name = ("Absentee  dies");
        a3.FixedPreconditions.Add(absenteeIsOlderGeneration);
        a3.MutablePreconditions.Add(MinTimePassed1);
        a3.Triggerconditions.Add(TooMuchTimePassed1);
        a3.Triggerconditions.Add(playerTriesLeaving);
        a3.action = new A3_action();
        // a3.level = 0;
        a3.complete = false;
        this.Absentation.Add(a3);


        this.a4 = new PlotFragment();
        a4.Name = ("Absentee  goes for a walk");
        a4.FixedPreconditions.Add(absenteeIsYoungerGeneration);
        a4.MutablePreconditions.Add(MinTimePassed1);
        a4.Triggerconditions.Add(TooMuchTimePassed1);
        a4.Triggerconditions.Add(playerTriesLeaving);
        a4.Triggerconditions.Add(playerSpeaksToAbsentee);
        a4.action = new A4_action();
        // a4.level = 0;
        a4.complete = false;
        this.Absentation.Add(a4);



        this.a5 = new PlotFragment();
        a5.Name = ("Absentee  goes out to gather berries");
        a5.FixedPreconditions.Add(absenteeIsYoungerGeneration);
        a5.MutablePreconditions.Add(MinTimePassed1);
        a5.Triggerconditions.Add(TooMuchTimePassed1);
        a5.Triggerconditions.Add(playerTriesLeaving); // must set to false after
        a5.Triggerconditions.Add(playerSpeaksToAbsentee);
        a5.action = new A5_action();
        // a5.level = 0;
        a5.complete = false;
        this.Absentation.Add(a5);


        this.a6 = new PlotFragment();
        a6.Name = ("Absentee goes fishing");
        a6.FixedPreconditions.Add(absenteeIsYoungerGeneration);
        a6.FixedPreconditions.Add(RiverNearBY);
        a6.MutablePreconditions.Add(MinTimePassed1);
        a6.Triggerconditions.Add(TooMuchTimePassed1);
        a6.Triggerconditions.Add(playerSpeaksToAbsentee);
        a6.action = new A6_action();
        // a6.level = 0;
        a6.complete = false;
        this.Absentation.Add(a6);

        //Interdiction --------------------------------------------------------------------------------------------------

        this.b1 = new PlotFragment();
        b1.Name = ("Hero is warned to not visit a location by a messenger");
        b1.FixedPreconditions.Add(InterdictionLocationExists);
        b1.FixedPreconditions.Add(InterDictionMessengerExists);
        b1.FixedPreconditions.Add(AbsentationCompelted123);
        b1.MutablePreconditions.Add(MinTimePassed2);
        b1.Triggerconditions.Add(PlayerSpeakstoInterdictionM);
        b1.Triggerconditions.Add(TooMuchTimePassed2);
        b1.action = new B1_action();
        //b1.level = 0;
        b1.complete = false;
        this.Interdictipon.Add(b1);



        this.b2 = new PlotFragment();
        b2.Name = ("Hero is instructed that they are forbidden to leave home");
        b2.FixedPreconditions.Add(HeroIsAChild);
        b2.FixedPreconditions.Add(InterdictionLocationExists);
        b2.FixedPreconditions.Add(InterDictionMessengerExists);
        b2.FixedPreconditions.Add(AbsentationCompelted123);
        b2.MutablePreconditions.Add(MinTimePassed2);
        b2.Triggerconditions.Add(playerTriesLeaving);
        b2.Triggerconditions.Add(TooMuchTimePassed2);
        b2.Triggerconditions.Add(PlayerSpeakstoInterdictionM);
        b2.action = new B2_action();
        //b2.level = 0;
        b2.complete = false;
        this.Interdictipon.Add(b2);




        this.b3 = new PlotFragment();
        b3.Name = ("Hero is instructed to look for absentee");
        b3.FixedPreconditions.Add(InterDictionMessengerExists);
        b3.FixedPreconditions.Add(AbsentationCompelted456);
        b3.MutablePreconditions.Add(MinTimePassed2);
        b3.Triggerconditions.Add(PlayerSpeakstoInterdictionM);
        b3.Triggerconditions.Add(TooMuchTimePassed2);
        b3.action = new B3_action();
        //b3.level = 0;
        b3.complete = false;
        this.Interdictipon.Add(b3);



        // Violation --------------------------------------------------------------------------------------------------

        this.c1 = new PlotFragment();
        c1.Name = ("Hero leaves to look for absentee/hero leaves for interdiction");
        c1.FixedPreconditions.Add(InterdictionCompleted13);
        c1.MutablePreconditions.Add(HeroGetsWeapon);
        c1.Triggerconditions.Add(HeroLeavesHome);
        c1.action = new C1_action();
        //c1.level = 0;
        c1.complete = false;
        this.Violation.Add(c1);



        this.c2 = new PlotFragment();
        c2.Name = ("Hero is warned to not visit a location by a messenger");
        c2.FixedPreconditions.Add(InterdictionCompleted2);
        c2.MutablePreconditions.Add(HeroFindsSleepingPotion);
        c2.MutablePreconditions.Add(HeroMakesSleepingTea);
        c2.MutablePreconditions.Add(HeroGivesTeaToGuards);
        c2.MutablePreconditions.Add(HeroGetsWeapon);
        c2.Triggerconditions.Add(HeroLeavesHome);
        c2.action = new C2_action();
        //c2.level = 0;
        c2.complete = false;
        this.Violation.Add(c2);


        // Debug.Log(Absentation.Count);
    }




}
