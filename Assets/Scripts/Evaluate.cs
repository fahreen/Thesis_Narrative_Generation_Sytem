using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Evaluate
{
    void Eval();
}


public class Eval_absenteeIsOlderGeneration : Evaluate
{
    public void Eval()
    {
        if(GameWorldGenerator.GetInstance().Absentee.roleAssignedTo.Age >= 35)
        {

            GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status = true;
        }
        else
        {
            GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status = false;
        }
    }
}

public class Eval_absenteeIsYoungerGeneration : Evaluate
{
public void Eval()
    {
        if (GameWorldGenerator.GetInstance().Absentee.roleAssignedTo.Age < 35)
        {

            GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status = true;
        }
        else
        {
            GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status = false;
        }

    }
}


public class Eval_absenteeIsMale : Evaluate
{
    public void Eval()
    {
        if (GameWorldGenerator.GetInstance().Absentee.roleAssignedTo.gender == 'M')
        {

            GameWorldGenerator.GetInstance().absenteeIsMale.status = true;
        }
        else
        {
            GameWorldGenerator.GetInstance().absenteeIsMale.status = false;
        }

    }
}

/*
 
public class Eval_RiverNearBY : Evaluate
{
    public void Eval()
    {
        return GameWorldGenerator.GetInstance().RiverNearBY.status();

    }
}


*/





