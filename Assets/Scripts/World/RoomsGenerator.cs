using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomsGenerator : MonoBehaviour
{
    public int maxCount = 10;
    [TextArea]
    public string
        startRoomsPath,
        battleRoomsPath,
        specialRoomsPath,
        bossRoomsPath;

    private Room[]
        startRoomsPrefabs,
        battleRoomsPrefabs,
        specialRoomsPrefabs,
        bossRoomsPrefabs;
    private int currentRoomNumber = 0;
    private Room currentRoom;

    public static RoomsGenerator I;

    void Awake()
    {
        I = this;

        startRoomsPrefabs = Resources.LoadAll<Room>(startRoomsPath);
        battleRoomsPrefabs = Resources.LoadAll<Room>(battleRoomsPath);
        specialRoomsPrefabs = Resources.LoadAll<Room>(specialRoomsPath);
        bossRoomsPrefabs = Resources.LoadAll<Room>(bossRoomsPath);

        Generate();
    }

    void Generate()
    {
        currentRoom = Instantiate(GetRandomRoom(startRoomsPrefabs), Vector2.zero, Quaternion.identity, transform);
    }

    public Room GenerateNextRoom()
    {
        currentRoomNumber++;
        if (currentRoomNumber < maxCount)
        {
            currentRoom = GenerateRoom(GetRandomRoom(battleRoomsPrefabs));
        }
        else
        {
            currentRoom = GenerateRoom(GetRandomRoom(bossRoomsPrefabs));
        }
        
        return currentRoom;
    }

    Room GenerateRoom(Room prefab)
    {
        return Instantiate(prefab, (Vector2)currentRoom.transform.position + new Vector2(0, currentRoom.height / 2 + prefab.height / 2), Quaternion.identity, transform);
    }

    Room GetRandomRoom(Room[] rooms) => rooms[Random.Range(0, rooms.Length)]; 
}
