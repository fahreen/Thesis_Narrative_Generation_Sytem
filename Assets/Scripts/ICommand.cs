using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    void Execute();
}

public class CommandExample: ICommand
{

    int _printInt;

    //constructor
    public  CommandExample(int x)
    {
        _printInt = x;

    }

    public void Execute()
    {
        Debug.Log(_printInt);
    }
}