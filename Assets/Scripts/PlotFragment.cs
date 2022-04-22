using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class PlotFragment 
{

    public string Name;
    public List<Preconditions> FixedPreconditions;
    public List<Preconditions> MutablePreconditions;
    public List<Preconditions> Triggerconditions;
   
    public int level;
    public bool complete;



    // the event to execute once this plot fragment is triggered
    public Action action;

    // code to execute to help player acheive the trigger
    // public Action hint;

    public PlotFragment()
    {




      // FixedPreconditions 
       FixedPreconditions = new List<Preconditions>();
       MutablePreconditions = new List<Preconditions>();
      Triggerconditions = new List<Preconditions>();
    }

}
