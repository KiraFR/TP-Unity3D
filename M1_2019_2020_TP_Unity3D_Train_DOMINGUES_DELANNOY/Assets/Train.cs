using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    public List<TrainUnit> Wagons = new List<TrainUnit>();
    public List<GameObject> Wheels = new List<GameObject>();

    public float speed = 1;

    public float maxSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {
        float distanceBetweenUnits = 0;

        //Set distance between all units
        for (int i = Wagons.Count - 2; i >= 0; i--)
        {
            distanceBetweenUnits += Vector3.Distance(Wagons[i].transform.position, Wagons[i + 1].transform.position);

            Wagons[i].positionInFrontOfLastWagon = distanceBetweenUnits;
            Wagons[i].UpdatePositionAtStart();

            Debug.Log("Distance bewteen " + Wagons[i] + " and " + Wagons[i + 1] + " = " + distanceBetweenUnits);
        }


        // cache all wheels
        foreach(TrainUnit trainUnit in Wagons)
        {
            foreach(GameObject wheel in trainUnit.Wheels)
            {
                Wheels.Add(wheel);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += Time.deltaTime *10;

            if (speed >= maxSpeed)
                speed = maxSpeed;
            
            SetWagonSpeed();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= Time.deltaTime * 10;

            if (speed <= 0)
                speed = 0;

            SetWagonSpeed();
        }

        ManageWheelSpeed();
    }

    private void ManageWheelSpeed()
    {
        foreach(GameObject wheel in Wheels)
        {

            wheel.transform.Rotate( new Vector3( speed * 100 * Time.deltaTime,0,0));
           
        }
    }

    private void SetWagonSpeed()
    {
        Debug.Log(speed);
        foreach(TrainUnit trainUnit in Wagons)
        {
            trainUnit.m_Speed = speed;
        }
    }
}
