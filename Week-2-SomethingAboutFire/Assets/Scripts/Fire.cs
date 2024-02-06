using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fire : MonoBehaviour
{
    private GameObject[] floors;
    
    // Start is called before the first frame update
    void Start()
    {
        // Put all floors in an array
        floors = GameObject.FindGameObjectsWithTag("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //throw new NotImplementedException();
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit by a player!");

            GameManager.instance.score++;

            if (floors.Length > 0)
            {
                // Get a random number
                int randomIndex = Random.Range(0, floors.Length);
                
                // Find this floor according to this number
                GameObject newFloor = floors[randomIndex];
                
                // Put fire on this randomly generated floor
                transform.position = new Vector3(newFloor.transform.position.x, newFloor.transform.position.y + 1.7f, 0.2f);
            }
            else
            {
                Debug.Log("Cannot find a new floor on fire");
            }
            
        }
    }
}
