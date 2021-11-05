using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSystem : MonoBehaviour
{
        public enum SeedType { RANDOM, CUSTOM }
        [Header("Random Related Stuff")]
        public SeedType seedType = SeedType.RANDOM;
        System.Random random;
        public int seed = 0;

        [Space]
        public bool animatedPath;
        public List<MyGridCell> gridCellList = new List<MyGridCell>();
        public int pathLength = 9;
        [Range(1.0f, 100.0f)]
        public float cellSize = 1.0f;

        public GameObject[] rooms;
        public Transform startLocation;
        private GameObject currentRoom;

        // Start is called before the first frame update
        void Start()
        {

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

        void DrawRoom() {
        Debug.Log("Draw");
            
            for (int i = 0; i < gridCellList.Count; i++)
            {
            Debug.Log("This the begin of the loop");
            int randRoomNumber = Random.Range(0, 4);
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

                if (animatedPath)
                    StartCoroutine(CreatePathRoutine());

                else
                    CreatePath();
            
            DrawRoom();

        }

    }
}
