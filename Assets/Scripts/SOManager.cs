using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SOManager : MonoBehaviour
{
    private static SOManager instance;
    private static int playerSkill1;
    private static int playerSkill2;

    public static SOManager GetInstance()
    {
        if (instance == null)
        {
            instance = new SOManager();
        }

        return instance;
    }

    public void Save(PlayerSkills skillsObj)
    {
        playerSkill1 = (int)skillsObj.skill1;
        playerSkill2 = (int)skillsObj.skill2;
    }

    public static int GetSkill1()
    {
        return playerSkill1;
    }

    public static int GetSkill2()
    {
        return playerSkill2;
    }
}
