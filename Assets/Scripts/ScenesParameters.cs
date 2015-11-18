using UnityEngine;
using System.Collections;

public static class ScenesParameters {

    private static string levelName = "level";
    public static string LevelName
    {
        get
        {
            return levelName;
        }
        set
        {
            levelName = value;
        }
    }

    private static string levelsDirectory = "Levels";
    public static string LevelsDirectory
    {
        get
        {
            return levelsDirectory;
        }
        set
        {
            levelsDirectory = value;
        }
    }

    private static int currentLevel;
    public static int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    private static int levelsNumber;
    public static int LevelsNumber
    {
        get
        {
            return levelsNumber;
        }
        set
        {
            levelsNumber = value;
        }
    }

    private static string section;
    public static string Section
    {
        get
        {
            return section;
        }
        set
        {
            section = value;
        }
    }
}
