using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Action
{
    void Execute();
}



public class Initialization_actions: Action
{
     public void Execute()
    {

    }
}





public class A1_action : Action
{
    public void Execute()
    {
        Debug.Log("Absentation 1: Absentee announces to family they will be leaving home for a business deal. " + "\n" +
            "The player is transported outside the castle, where all family members say good bye");
    }
}



public class A2_action : Action
{
    public void Execute()
    {
        Debug.Log("Absentee announces to family they will be leaving home to fight in the war." + "\n" +
            "The player is transported outside the castle, where all family members say good bye");
    }
}


public class A3_action : Action
{
    public void Execute()
    {
        Debug.Log("Absentation 3: Absentee has a heart attack, the rest of the characters gather. " + "\n" +
            "The player is transported to outside the castle, where all members are gathered around a gravestone.");
    }
}


public class A4_action : Action
{
    public void Execute()
    {
        Debug.Log("Absentation 4: Absentee walks up to player and tells them they are going for a walk." + "\n" +
            "The player and absenttee are transported outside the castle, where player says gooodbye to absentee.");
    }
}



public class A5_action : Action
{
    public void Execute()
    {
        Debug.Log("Absentation 5: Absentee walks up to player and tells them they are going out to gather berries. " + "\n" +
            " The player and absenttee are transported outside the castle, where player says gooodbye to absentee.");
    }
}

public class A6_action : Action
{
    public void Execute()
    {
        Debug.Log("Absentation 6: Absentee walks up to player and tells them they are going fishing." + "\n" +
            " The player and absenttee are transported outside the castle, where player says gooodbye to absentee." + "\n" +
            "Transport absentee to river where they fish");
    }
}


public class B1_action : Action
{
    public void Execute()
    {
        Debug.Log("Interdiction 1: Interdiction messenger finds player if not already with player." + "\n" +
            "Messenger tells player they should not go to a location At this point player is unable to leave home, " + "\n" +
            "as they are locked inside area(exiting results in popup)" + "\n" +
            "Place weapon in bedroom");
    }
}

public class B2_action : Action
{
    public void Execute()
    {
        Debug.Log("Interdiction 2: In this case, the guradian also takes the role of the interdiction messenger " + "\n" +
            "Player is told by guardian character they cannot leave home." + "\n" +
            "At this point player is unable to leave home, as they are locked inside area(exiting results in popup)" + "\n" +
            "Place weapon with guards");
    }
}

public class B3_action : Action
{
    public void Execute()
    {
        Debug.Log("Interdiction 3(inverse): Interdiction messenger finds player if not already with player." + "\n" +
            "Messenger tells player to look for absentee." + "\n" +
            "At this point player is unable to leave home, as they are locked inside area(exiting results in popup)" + "\n" +
            "Place weapon in bedroom");
    }
}


public class C1_action : Action
{
    public void Execute()
    {
        Debug.Log("Violation 1: (i) give hints to player to find weapon" +
            "(ii)Once weapon is retrieved, restrictions are lifted, player may now leave home" + "\n" +
            "(iii)There is a single path that leads to the interdiction location. " + "\n" +
            "(iv)Evaluator places enemies along the way health potions are also availaible player may die if health is too low" + "\n" +
            "(v)Instantiate villian and their motive ");
    }
}

public class C2_action : Action
{
    public void Execute()
    {
        Debug.Log("Violation 2: (i) give hints to player to make guards sleep and find weapon" +
            "(ii)once weapon is retrieved, restrictions are lifted, player may now leave home" + "\n" +
            "(iii)There is a single path that leads to the interdiction location. " + "\n" +
            "(iv)Evaluator places enemies along the way health potions are also availaible, player may die if health is too low" + "\n" +
            "(v)Instantiate villian and their motive ");
    }
}




// ICommand action = new CommandExample(5);
// action.Execute();

