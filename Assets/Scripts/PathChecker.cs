using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChecker : MonoBehaviour
{
    public bool triggered = false;
    public bool chosen = false;
    GameObject tileOnWay;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            triggered = true;
            Debug.Log("IS" + collision.gameObject);

            if (chosen)
            {
                collision.gameObject.tag = "InWay";
            }
        }

    }

    public void Update()
    {
        if (chosen && triggered)
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("InWay");
            foreach (GameObject obstacle in obstacles)
                GameObject.Destroy(obstacle);
        }

        if (chosen && !triggered) {
            chosen = false;
        }
    }
}
