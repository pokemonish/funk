using UnityEngine;
using System.Collections;

public class Saver : MonoBehaviour
{

    private static string sawTraining = "saw_training";

    private static string getLevelName(int num = -1)
    {
        num = num < 0 ? ScenesParameters.CurrentLevel : num;
        return "level_" + ScenesParameters.Section + "_" + num;
    }
    private static string getLevelCompletedName(int num = -1)
    {
        return getLevelName(num) + "_comleted";
    }
    public static bool getLevelComplete(int num = -1)
    {
        return PlayerPrefs.GetInt(getLevelCompletedName(num), 0) == 1;
    }
    public static void setLevelComplete(int num = -1)
    {
        PlayerPrefs.SetInt(getLevelCompletedName(num), 1);
    }

    private static string getSectionName()
    {
        return "section_" + ScenesParameters.Section;
    }
    private static int getSectionLevelsComplete()
    {
        return PlayerPrefs.GetInt(getSectionName(), 0);
    }
    private static void setSectionLevelsComplete(int c)
    {
        PlayerPrefs.SetInt(getSectionName(), c);
    }

    public static void levelComplete()
    {
        if (!getLevelComplete()) {
            setSectionLevelsComplete(getSectionLevelsComplete() + 1);
        }

        setLevelComplete();
    }
    public static bool isLevelComplete(int num)
    {
        return getLevelComplete(num);
    }
    public static bool isLevelPlayable(int num)
    {
        return num == 1 || getLevelComplete(num - 1);
    }

    public static void dontShowTraining()
    {
        PlayerPrefs.SetInt(sawTraining, 1);
    }

    public static int hasShownTraining()
    {
        return PlayerPrefs.GetInt(sawTraining, 0);
    }
}
