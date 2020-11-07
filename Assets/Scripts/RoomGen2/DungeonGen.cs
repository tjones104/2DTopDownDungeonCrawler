using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGen : MonoBehaviour
{
    public DungeonGenData dungeonGenData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenData);
        SpawnRooms(dungeonRooms);
    }
    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Start", 0, 0);
        foreach(Vector2Int roomLocation in rooms)
        {

             RoomController.instance.LoadRoom(RoomController.instance.GetRandomRoomName(), roomLocation.x, roomLocation.y);
        }
    }
}
