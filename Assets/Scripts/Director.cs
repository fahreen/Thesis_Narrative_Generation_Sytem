using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{

    //holds all available plot fragments available to the system
    //public List<PlotFragment> PlotFragmentList;
    public Dictionary<int, List<PlotFragment>> PlotFragmentList;




    //Plot fragments which the system is actively pursuing
    //but some preconditions are missing.
    //This contains all the plot fragments for which Fixed preconditions have been met
    public List<PlotFragment> ActivePlotFragmentList;

    //Plot fragments with  no missing preconditions
    //but have not yet been presented to the player
    //This contains all the plot fragments for which Mutable preconditions have been met
    public List<PlotFragment> TriggerPlotFragmentList;

    //consists of missing booleans from <ActivePlotFragmentList> and <TriggerList>
    //these represent goals for the system accomplish
    public List<Preconditions> GoalsList;


    public int currentLevel;

    public bool storyComplete;


    int x = 0;

    public GameWorldGenerator worldGenerator;

   // GameWorldGenerator GWscript;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;

        // Initialize all lists
        this.PlotFragmentList = new Dictionary<int, List<PlotFragment>>();
        this.ActivePlotFragmentList = new List<PlotFragment>();
        this.TriggerPlotFragmentList = new List<PlotFragment>();

        //GWscript = this.worldGenerator.GetComponent<GameWorldGenerator>();

        ////Load author-level plot fragments into the system.
        ///In this casse, these are the functions  defined in V.P. morphology
        //List<Preconditions> x = GWscript.Absentation;


        this.PlotFragmentList.Add(1, GameWorldGenerator.GetInstance().Absentation);
        this.PlotFragmentList.Add(2, GameWorldGenerator.GetInstance().Interdictipon);
        this.PlotFragmentList.Add(3, GameWorldGenerator.GetInstance().Violation);

        LoadStory();




        storyComplete = false;

    }


    // This function sets some core components of the world randomly.  THese are fixed preconditions, and cannot be changed through player action
    void LoadStory()
    {
        // set river value
        float f = Random.Range(0f, 1f);
        Debug.Log(f);
        if(f>= 0.05)
        {
            GameWorldGenerator.GetInstance().RiverNearBY.status = true;
        }
        else
        {
            GameWorldGenerator.GetInstance().RiverNearBY.status = false;
        }

        //GameWorldGenerator.absenteeIsOlderGeneration.status = true;
        //GWscript.RiverNearBY.status = true;

        // set story world values 
        //load characters?
    }

    // Update is called once per frame
    void Update()
    {
        //check if any plot fragment for the current author level has been completed
        bool complete = false;

        if (!storyComplete)
        {
            for (int i = 0; i < this.PlotFragmentList[currentLevel].Count; i++)
            {
                if (this.PlotFragmentList[currentLevel][i].complete)
                {
                    complete = true;

                    break;
                }

            }




            //If current level is absentation OR The current Level is not complete
            if (!complete) //|| complete
            {
               
                //Sort through all plot fragments under current author level fragment 
                // Add a plot fragment to the <ActivePlotFragmentList> if the fixed preconditions are satisfied
                //================================================================================================
                for (int i = 0; i < this.PlotFragmentList[currentLevel].Count; i++)//a1, a2, a3,....
                {
                    bool FixedConditionsAreMet = true;
                    PlotFragment CurrentPlotFragment = this.PlotFragmentList[currentLevel][i];

                    //For each plot fragment under the current author fragment
                    for (int j = 0; j < CurrentPlotFragment.FixedPreconditions.Count; j++)
                    {

                        //check if all fixed preconditions are met
                        if (!CurrentPlotFragment.FixedPreconditions[j].status)
                        {
                            FixedConditionsAreMet = false;
                            break;
                        }
                    }
                    //if all fixed preconditions are met, add the current plot fragment to the <ActivePlotFragmentList>
                    if (FixedConditionsAreMet)
                    {
                        if (!this.ActivePlotFragmentList.Contains(CurrentPlotFragment))
                        {
                            this.ActivePlotFragmentList.Add(CurrentPlotFragment);
                        }

                        for (int k = 0; k < CurrentPlotFragment.MutablePreconditions.Count; k++)
                        {
                            Preconditions x = CurrentPlotFragment.MutablePreconditions[k];
                            if (!this.GoalsList.Contains(x))
                            {
                                this.GoalsList.Add(x);
                            }

                        }

                    }

                }
                //================================================================================================


                //Sort through all plot fragments in the <ActivePlotFragmentList>
                // Add a plot fragment to the <TriggerList> if all the mutable conditions are satisfied
                //================================================================================================
                for (int i = 0; i < this.ActivePlotFragmentList.Count; i++)
                {
                    bool MutableConditionsAreMet = true;
                    PlotFragment CurrentPlotFragment = this.ActivePlotFragmentList[i];
                    for (int j = 0; j < CurrentPlotFragment.MutablePreconditions.Count; j++)
                    {
                        //if any mutable condition of the plot  fragment is false
                        if (!CurrentPlotFragment.MutablePreconditions[j].status)
                        {
                            MutableConditionsAreMet = false;
                            break;
                        }
                    }
                    if (MutableConditionsAreMet)
                    {
                        if (!this.TriggerPlotFragmentList.Contains(CurrentPlotFragment))
                        {
                            this.TriggerPlotFragmentList.Add(CurrentPlotFragment);
                        }
                    }
                }
                //================================================================================================



                //Sort through all plot fragments in the <TriggerList>
                //if atleast one trigger condition is satisfied, add the plotfragment to a temporary List
                // If temorary list is > 1, Randomly choose a plot fragment from the temorarylist to execute
                // set complete to true for this author level fragment 
                // Run the Action function for the plot fragment
                //================================================================================================

                List<PlotFragment> TemporaryTriggerList = new List<PlotFragment>();
                for (int i = 0; i < this.TriggerPlotFragmentList.Count; i++)
                {
                    bool TriggerConditionsAreMet = false;
                    PlotFragment CurrentPlotFragment = this.TriggerPlotFragmentList[i];
                    for (int j = 0; j < CurrentPlotFragment.Triggerconditions.Count; j++)
                    {
                        //if ATLEAST One trigger Condition is true
                        if (CurrentPlotFragment.Triggerconditions[j].status)
                        {
                            TriggerConditionsAreMet = true;
                            break;
                        }
                    }
                    if (TriggerConditionsAreMet)
                    {
                        TemporaryTriggerList.Add(CurrentPlotFragment);
                    }
                }

                if (TemporaryTriggerList.Count > 0)
                {
                    int PlotFragmentIndex = Random.Range(0, TemporaryTriggerList.Count - 1);
                    
                    int currentPlotfragmentIndex = PlotFragmentList[currentLevel].IndexOf(TemporaryTriggerList[PlotFragmentIndex]);

                    //set to complete
                    this.PlotFragmentList[currentLevel][currentPlotfragmentIndex].complete = true;

                    this.PlotFragmentList[currentLevel][currentPlotfragmentIndex].action.Execute();
                    // this.currentLevel++;
                }

                //================================================================================================




            }
            else
            {
               
                // reset all the lists
                this.ActivePlotFragmentList = new List<PlotFragment>();
                this.TriggerPlotFragmentList = new List<PlotFragment>();
                this.GoalsList = new List<Preconditions>();
                // set complete to false again, by increasing current level
                this.currentLevel++;
                if (currentLevel > this.PlotFragmentList.Count)
                {
                    this.storyComplete = true;
                    Debug.Log("STORY COMPLETE");
                }
            }


        }






        //Check all plot fragments in the <ActivePlotFragmentList> and  <TriggerPlotFragmentList> lists to determine if:

        //the plot fragment is needed anymore ---> if any of the preconditions are on the goals list, then still relevant, else remove
        //if there are any missing precondition ---> 





        /*The Director has two main jobs concerning plot fragments and story goals
1) responsible for creating goals from missing preconditions.
2) evaluates all current goals to determine if they have been fulfilled or require
active plans to fulfill them.
*/




        //Check all plot fragments in the Active and Trigger plot fragment lists to determine if:
        //the plot fragment is needed anymore
        //if there are any missing preconditions.

        /*The Director determines the relevance of a plot fragment by comparing its end conditions with the Goals list.
        If any end conditions match a goal on this list, then the particular plot fragment is still relevant. Otherwise, the fragment is no longer necessary
        */



    }
}
