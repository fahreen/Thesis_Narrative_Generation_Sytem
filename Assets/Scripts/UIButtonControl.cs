using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class UIButtonControl : MonoBehaviour
{
    public Text Status;




    private void Start()
    {

        if(this.name == "absenteeIsOlderGeneration")
        {
            Status.text = GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status.ToString();

        }
    }


    

    //Absentation ===========================================================================================
    public void OnAbsenteeIsOlderGeneration()
    {
        // Debug.Log(GameWorldGenerator.absenteeIsOlderGeneration.status);

        if (GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status)
        {
            GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status = false;
            Status.color = Color.red;
        }
        else
        {
            GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status = true;
            Status.color = Color.green;
        }
        
        Status.text = GameWorldGenerator.GetInstance().absenteeIsOlderGeneration.status.ToString();

    }


    public void OnAbsenteeIsYoungerGeneration()
    {
        // Debug.Log(GameWorldGenerator.absenteeIsOlderGeneration.status);

        if (GameWorldGenerator.GetInstance().absenteeIsYoungerGeneration.status)
        {
            GameWorldGenerator.GetInstance().absenteeIsYoungerGeneration.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().absenteeIsYoungerGeneration.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().absenteeIsYoungerGeneration.status.ToString();


    }

    public void OnAbsenteeIsMale()
    {
        // Debug.Log(GameWorldGenerator.absenteeIsOlderGeneration.status);

        if (GameWorldGenerator.GetInstance().absenteeIsMale.status)
        {
            GameWorldGenerator.GetInstance().absenteeIsMale.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().absenteeIsMale.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().absenteeIsMale.status.ToString();


    }

    public void OnRiverNearBY()
    {
        // Debug.Log(GameWorldGenerator.absenteeIsOlderGeneration.status);

        if (GameWorldGenerator.GetInstance().RiverNearBY.status)
        {
            GameWorldGenerator.GetInstance().RiverNearBY.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().RiverNearBY.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().RiverNearBY.status.ToString();


    }


    public void OnMinTimePassed1()
    {
        // Debug.Log(GameWorldGenerator.absenteeIsOlderGeneration.status);

        if (GameWorldGenerator.GetInstance().MinTimePassed1.status)
        {
            GameWorldGenerator.GetInstance().MinTimePassed1.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().MinTimePassed1.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().MinTimePassed1.status.ToString();


    }


    public void OnTooMuchTimePassed1()
    {

        if (GameWorldGenerator.GetInstance().TooMuchTimePassed1.status)
        {
            GameWorldGenerator.GetInstance().TooMuchTimePassed1.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().TooMuchTimePassed1.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().TooMuchTimePassed1.status.ToString();


    }



    public void OnplayerTriesLeaving()
    {
        if (GameWorldGenerator.GetInstance().playerTriesLeaving.status)
        {
            GameWorldGenerator.GetInstance().playerTriesLeaving.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().playerTriesLeaving.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().playerTriesLeaving.status.ToString();


    }


    public void OnPlayerSpeaksToAbsentee()
    {
        if (GameWorldGenerator.GetInstance().playerSpeaksToAbsentee.status)
        {
            GameWorldGenerator.GetInstance().playerSpeaksToAbsentee.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().playerSpeaksToAbsentee.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().playerSpeaksToAbsentee.status.ToString();


    }



    //Interdiction ===========================================================================================


    public void OnInterdictionLocationExists()
    {
        if (GameWorldGenerator.GetInstance().InterdictionLocationExists.status)
        {
            GameWorldGenerator.GetInstance().InterdictionLocationExists.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().InterdictionLocationExists.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().InterdictionLocationExists.status.ToString();
    }


    public void OnInterDictionMessengerExists()
    {
        if (GameWorldGenerator.GetInstance().InterDictionMessengerExists.status)
        {
            GameWorldGenerator.GetInstance().InterDictionMessengerExists.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().InterDictionMessengerExists.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().InterDictionMessengerExists.status.ToString();
    }


    public void OnAbsentationCompelted123()
    {
        if (GameWorldGenerator.GetInstance().AbsentationCompelted123.status)
        {
            GameWorldGenerator.GetInstance().AbsentationCompelted123.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().AbsentationCompelted123.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().AbsentationCompelted123.status.ToString();
    }


    public void OnAbsentationCompelted456()
    {
        if (GameWorldGenerator.GetInstance().AbsentationCompelted456.status)
        {
            GameWorldGenerator.GetInstance().AbsentationCompelted456.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().AbsentationCompelted456.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().AbsentationCompelted456.status.ToString();
    }

    public void OnMinTimePassed2()
    {
        if (GameWorldGenerator.GetInstance().MinTimePassed2.status)
        {
            GameWorldGenerator.GetInstance().MinTimePassed2.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().MinTimePassed2.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().MinTimePassed2.status.ToString();
    }

    public void OnTooMuchTimePassed2()
    {
        if (GameWorldGenerator.GetInstance().TooMuchTimePassed2.status)
        {
            GameWorldGenerator.GetInstance().TooMuchTimePassed2.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().TooMuchTimePassed2.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().TooMuchTimePassed2.status.ToString();
    }



    public void OnPlayerSpeakstoInterdictionM()
    {
        if (GameWorldGenerator.GetInstance().PlayerSpeakstoInterdictionM.status)
        {
            GameWorldGenerator.GetInstance().PlayerSpeakstoInterdictionM.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().PlayerSpeakstoInterdictionM.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().PlayerSpeakstoInterdictionM.status.ToString();
    }



    public void OnHeroIsAChild()
    {
        if (GameWorldGenerator.GetInstance().HeroIsAChild.status)
        {
            GameWorldGenerator.GetInstance().HeroIsAChild.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().HeroIsAChild.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().HeroIsAChild.status.ToString();
    }



    public void OnInterdictionCompleted13()
    {
        if (GameWorldGenerator.GetInstance().InterdictionCompleted13.status)
        {
            GameWorldGenerator.GetInstance().InterdictionCompleted13.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().InterdictionCompleted13.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().InterdictionCompleted13.status.ToString();
    }


    public void OnInterdictionCompleted2()
    {
        if (GameWorldGenerator.GetInstance().InterdictionCompleted2.status)
        {
            GameWorldGenerator.GetInstance().InterdictionCompleted2.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().InterdictionCompleted2.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().InterdictionCompleted2.status.ToString();
    }


    public void OnHeroGetsWeapon()
    {
        if (GameWorldGenerator.GetInstance().HeroGetsWeapon.status)
        {
            GameWorldGenerator.GetInstance().HeroGetsWeapon.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().HeroGetsWeapon.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().HeroGetsWeapon.status.ToString();
    }

    public void OnHeroFindsSleepingPotion()
    {
        if (GameWorldGenerator.GetInstance().HeroFindsSleepingPotion.status)
        {
            GameWorldGenerator.GetInstance().HeroFindsSleepingPotion.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().HeroFindsSleepingPotion.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().HeroFindsSleepingPotion.status.ToString();
    }


    public void OnHeroMakesSleepingTea()
    {
        if (GameWorldGenerator.GetInstance().HeroMakesSleepingTea.status)
        {
            GameWorldGenerator.GetInstance().HeroMakesSleepingTea.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().HeroMakesSleepingTea.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().HeroMakesSleepingTea.status.ToString();
    }


    public void OnHeroGivesTeaToGuards()
    {
        if (GameWorldGenerator.GetInstance().HeroGivesTeaToGuards.status)
        {
            GameWorldGenerator.GetInstance().HeroGivesTeaToGuards.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().HeroGivesTeaToGuards.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().HeroGivesTeaToGuards.status.ToString();
    }

    public void OnHeroLeavesHome()
    {
        if (GameWorldGenerator.GetInstance().HeroLeavesHome.status)
        {
            GameWorldGenerator.GetInstance().HeroLeavesHome.status = false;
        }
        else
        {
            GameWorldGenerator.GetInstance().HeroLeavesHome.status = true;
        }

        Status.text = GameWorldGenerator.GetInstance().HeroLeavesHome.status.ToString();
    }







}
