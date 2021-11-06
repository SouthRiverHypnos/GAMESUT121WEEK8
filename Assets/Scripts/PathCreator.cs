using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    public GameObject Checker1;
    public GameObject Checker2;
    public GameObject Checker3;
    public GameObject Checker4;
    public GameObject Checker5;
    public GameObject Checker6;
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Checker1.GetComponent<PathChecker>().triggered && Checker2.GetComponent<PathChecker>().triggered && Checker3.GetComponent<PathChecker>().triggered) {
            if (!Checker1.GetComponent<PathChecker>().chosen && !Checker2.GetComponent<PathChecker>().chosen && !Checker3.GetComponent<PathChecker>().chosen) {
                int rnd = Random.Range(1, 4);
                if (rnd == 1) {
                    Checker1.GetComponent<PathChecker>().chosen = true;
                }
                if (rnd == 2)
                {
                    Checker2.GetComponent<PathChecker>().chosen = true;
                }
                if (rnd == 3)
                {
                    Checker3.GetComponent<PathChecker>().chosen = true;
                }
            }
        }

        if (Checker4.GetComponent<PathChecker>().triggered && Checker5.GetComponent<PathChecker>().triggered && Checker6.GetComponent<PathChecker>().triggered)
        {
            if (!Checker4.GetComponent<PathChecker>().chosen && !Checker5.GetComponent<PathChecker>().chosen && !Checker6.GetComponent<PathChecker>().chosen) {
                int rnd = Random.Range(1, 4);
                if (rnd == 1)
                {
                    Checker4.GetComponent<PathChecker>().chosen = true;
                }
                if (rnd == 2)
                {
                    Checker5.GetComponent<PathChecker>().chosen = true;
                }
                if (rnd == 3)
                {
                    Checker6.GetComponent<PathChecker>().chosen = true;
                }
            }
        }
    }
}
