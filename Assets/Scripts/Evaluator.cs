using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluator : MonoBehaviour
{
    private void Start()
    {
        // initially evaulate what stories are availaible, after character instantiation
        InitialEvaulation();
    }



    public void InitialEvaulation()
    {
        GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.evaluate.Eval();
       
    }


    // Update is called once per frame
    void Update()
    {



      
    }







}






/*
      // absentee Preconditions
    

   */   