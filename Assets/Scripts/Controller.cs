using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

 //   [SerializeField]
  //  private List<Preconditions> EventsToMonitor;


    // coroutines to pace story


    IEnumerator MinTImePassed1Delay()
    {
        yield return new WaitForSeconds(10f);
        GameWorldGenerator.GetInstance().MinTimePassed1.status = true;    }

    IEnumerator TooMuchTimePassed1Delay()
    {
        yield return new WaitForSeconds(20f);
        GameWorldGenerator.GetInstance().TooMuchTimePassed1.status = true;
    }

    IEnumerator MinTImePassed2Delay()
    {
        yield return new WaitForSeconds(10f);
        GameWorldGenerator.GetInstance().MinTimePassed1.status = true;
    }

    IEnumerator TooMuchTimePassed2Delay()
    {
        yield return new WaitForSeconds(20f);
        GameWorldGenerator.GetInstance().TooMuchTimePassed1.status = true;
    }









    void Start()
    {


        StartCoroutine(MinTImePassed1Delay());
        StartCoroutine(TooMuchTimePassed1Delay());

        //  EventsToMonitor = new List<Preconditions>();
        //   EventsToMonitor.AddRange(GameWorldGenerator.GetInstance().storyWorldValues);


    }


    private void Update()
    {
        
    }


}
