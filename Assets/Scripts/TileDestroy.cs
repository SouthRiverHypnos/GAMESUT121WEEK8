using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x <= -16 || transform.position.x >= 16 || transform.position.y <= -16 || transform.position.y >= 16) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
