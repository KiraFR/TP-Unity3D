using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    public List<TrainUnit> Wagons = new List<TrainUnit>();

    // Start is called before the first frame update
    void Start()
    {
        float distanceBetweenUnits = 0;
        
        //Set distance between all units
        for (int i = Wagons.Count -2 ; i >= 0; i--)
        {
            distanceBetweenUnits += Vector3.Distance(Wagons[i].transform.position, Wagons[i + 1].transform.position);

            Wagons[i].positionInFrontOfLastWagon = distanceBetweenUnits;
            Wagons[i].UpdatePositionAtStart();

            Debug.Log("Distance bewteen " + Wagons[i] + " and " + Wagons[i + 1] + " = " + distanceBetweenUnits);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
