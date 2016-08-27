using UnityEngine;
using System.IO;
using System;
using LitJson;

public class LevelReader : MonoBehaviour
{
    /*Class LevelReader
    * Description: Loads the level data in as a json file and splits based on key.
    */

    private string jsonLevelData;
    LevelPopulator levelPopulator;
    string[] levelArray;
    private int gridXSize, gridYSize;

    private int capex;
    private int levelInletTemp, levelInletPress;
    private string objective1Text, objective2Text, objective3Text;
    private float objective1Value, objective2Value, objective3Value;
    private int costPlatMax, costGoldMax, costSilverMax, costBronzeMax, costPassMax;


    public class JSONLevelDataParseClass
    {
        public string Title;
        public string[] Grid;
        public int GridXSize, GridYSize;
    }

    void Awake()
    {
        try
        {
            jsonLevelData = File.ReadAllText(Application.dataPath + "/Resources/Levels/Level2.json");
        }
        catch (Exception e)
        {
            Debug.LogError("Error in loading json data, error is " + e.Message);
        }
        
        ParseLevelJSONToClass();
        levelPopulator = FindObjectOfType<LevelPopulator>();
        StartCoroutine(levelPopulator.PopulateLevel(levelArray, gridXSize, gridYSize));
    }

    private void ParseLevelJSONToClass()
    {
        try
        {
            JSONLevelDataParseClass levelData = JsonMapper.ToObject<JSONLevelDataParseClass>(jsonLevelData);
            levelArray = levelData.Grid;
            gridXSize = levelData.GridXSize;
            gridYSize = levelData.GridYSize;
}
        catch(Exception e)
        {
            Debug.LogError("JSON loading failed, see error " + e.Message);
        }
    }

}
        


