﻿using UnityEngine;
using System.Collections;

public class LevelPopulator : MonoBehaviour {

    public GameObject SpawnPoint, TreeBlock, RockBlock, Creature, CreatureMovePoint;
    private GameObject spawnPointClone, treeBlockClone, rockBlockClone, CreatureClone, CreatureMovePointClone;
    private float xPos, yPos;
    private Vector2 objectPosition;
    public Transform spawnParent;
    public GameObject levelGrid;
    private Renderer levelGridRend;
    GameControlLoop gameControlLoop;
    private float levelPopDelay = 0.00001F;
    GameUI gameUI;

    void Start()
    {
        gameControlLoop = FindObjectOfType<GameControlLoop>();
        gameUI = FindObjectOfType<GameUI>();
        gameUI.gameText.HarvestReqText.text = CarryOverInfo.FoodRequired.ToString();
    }
    public IEnumerator PopulateLevel(string[] levelText, int gridXSize, int gridYSize)
    {
        levelGrid.transform.localScale = new Vector3(gridXSize, gridYSize, 1F);
        for (int i = 0; i < levelText.Length; i++)
        {
            char[] levelTextChar = levelText[i].ToCharArray();
            for (int j = 0; j < levelTextChar.Length; j++)
            {
                xPos = j - (gridXSize / 2 - 0.5F);
                yPos = (gridYSize / 2 - 0.5F) - i;
                objectPosition = new Vector2(xPos, yPos);
                switch (levelTextChar[j])
                {
                    case ('S'):
                        spawnPointClone = Instantiate(SpawnPoint, objectPosition, Quaternion.identity) as GameObject;
                        spawnPointClone.name = "SpawnPoint";
                        spawnPointClone.transform.SetParent(spawnParent);
                        gameControlLoop.PlayerSpawnPoint = spawnPointClone.transform;
                        yield return new WaitForSeconds(levelPopDelay);
                        break;
                    case ('T'):
                        treeBlockClone = Instantiate(TreeBlock, objectPosition, Quaternion.identity) as GameObject;
                        treeBlockClone.name = "TreeBlock";
                        treeBlockClone.transform.SetParent(spawnParent);
                        yield return new WaitForSeconds(levelPopDelay);
                        break;
                    case ('R'):
                        rockBlockClone = Instantiate(RockBlock, objectPosition, Quaternion.identity) as GameObject;
                        rockBlockClone.name = "Rockblock";
                        rockBlockClone.transform.SetParent(spawnParent);
                        yield return new WaitForSeconds(levelPopDelay);
                        break;
                    case ('C'):
                        CreatureClone = Instantiate(Creature, objectPosition, Quaternion.identity) as GameObject;
                        CreatureClone.name = "Creature";
                        CreatureClone.transform.SetParent(spawnParent);
                        yield return new WaitForSeconds(levelPopDelay);
                        break;
                    case ('M'):
                        CreatureMovePointClone = Instantiate(CreatureMovePoint, objectPosition, Quaternion.identity) as GameObject;
                        CreatureMovePoint.name = "CreatureMovementPoint";
                        CreatureMovePointClone.transform.SetParent(spawnParent);
                        yield return new WaitForSeconds(levelPopDelay);
                        break;
                    default:
                        //Debug.Log(levelTextChar[j]);
                        break;
                }
            }
        }
        gameControlLoop.GameStarted = true;
    }
}
