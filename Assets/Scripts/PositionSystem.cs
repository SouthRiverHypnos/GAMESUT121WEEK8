using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PositionSystem : MonoBehaviour
{
        public enum SeedType { RANDOM, CUSTOM }
        [Header("Random Related Stuff")]
        public SeedType seedType = SeedType.RANDOM;
        System.Random random;
        public int seed = 0;

        [Space]
        public List<MyGridCell> gridCellList = new List<MyGridCell>();
        public int pathLength = 9;
    public int rows = 4;
    public int columns = 4;

    [Range(1.0f, 100.0f)]
        public float cellSize = 1.0f;

        public GameObject[] rooms;
        public GameObject[] spawnLocation;
        private GameObject currentRoom;
        public GameObject character;
        public GameObject[] collectible;

    public GameObject text;


    void Start()
    {
        DrawGrid();
        DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        random = new System.Random((int)(DateTime.Now - epochStart).TotalSeconds);
    }

    void DrawGrid()
    {
        float startX = ((-columns / 2.0f) * cellSize) + (cellSize / 2.0f);
        float startY = ((-rows / 2.0f) * cellSize) + (cellSize / 2.0f);

        for (int i = 0; i < rows; i++)
        {
            Debug.Log($"Hey this is number #{i}");
            for (int j = 0; j < columns; j++)
            {
                gridCellList.Add(
                    new MyGridCell(
                         startX + (j * cellSize),
                         startY + (i * cellSize)
                         )
                    );
            }
        }
    }

    void SetSeed()
        {
            if (seedType == SeedType.RANDOM)
            {
                random = new System.Random();
            }
            else if (seedType == SeedType.CUSTOM)
            {
                random = new System.Random(seed);
            }
        }


    /*
        void CreatePath()
        {

            gridCellList.Clear();
            Vector3 currentPosition = startLocation.transform.position;
            gridCellList.Add(new MyGridCell(currentPosition));

            for (int i = 0; i < pathLength; i++)
            {

            
                int n = random.Next(100);

                if (n.IsBetween(0, 49))
                {
                   currentPosition = new Vector3(currentPosition.x + cellSize, currentPosition.y);
                }
                else
                {
                   currentPosition = new Vector3(currentPosition.x, currentPosition.y + cellSize);
                }

                gridCellList.Add(new MyGridCell(currentPosition));
            



            }
        }

        IEnumerator CreatePathRoutine()
        {

            gridCellList.Clear();
            Vector3 currentPosition = startLocation.transform.position;
            gridCellList.Add(new MyGridCell(currentPosition));

            for (int i = 0; i < pathLength; i++)
            {

                int n = random.Next(100);

            if (n.IsBetween(0, 49))
            {
                currentPosition = new Vector3(currentPosition.x + cellSize, currentPosition.y);
            }
            else
            {
                currentPosition = new Vector3(currentPosition.x, currentPosition.y + cellSize);
            }

            gridCellList.Add(new MyGridCell(currentPosition));
                yield return null;
            }
        }
    */


       void DrawRoom() {
        Debug.Log("Draw");
            
            for (int i = 0; i < gridCellList.Count; i++)
            {
            Debug.Log("This the begin of the loop");
            int randRoomNumber = UnityEngine.Random.Range(0, 4);
            currentRoom = rooms[randRoomNumber];
            
            Instantiate(currentRoom, gridCellList[i].location, Quaternion.identity);
            currentRoom.transform.position = gridCellList[i].location;
            Debug.Log(currentRoom.transform.position, currentRoom.gameObject);
        }


    }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetSeed();

            /*if (animatedPath)
                StartCoroutine(CreatePathRoutine());

            else
                CreatePath();
        */


            text.SetActive(false);
            DrawRoom();
            Instantiate(character, new Vector3(-12.43f, 10.87f, 0), Quaternion.identity);
            for (int i = 0; i < 5; i++)
            {
               Instantiate(collectible[i], new Vector3(UnityEngine.Random.Range(-14.5f, 14.5f), UnityEngine.Random.Range(-14.5f, 14.5f), 0), Quaternion.identity);
               
            }

        }

    }
}

