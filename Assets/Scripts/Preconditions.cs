using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Preconditions 
{
   public string ID;
    public bool status;

   public Preconditions( string id, bool s)
    {
       this.ID = id;
        this.status = s;
    }

    public Evaluate evaluate;
}
