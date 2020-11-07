using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonGenerationData.asset", menuName = "DungeonGenerationData/Dungeon Data")]


public class DungeonGenData : ScriptableObject
{
    public int numberOfCrawlers;
    public int iterationMin;
    public int iterationMax;
}
