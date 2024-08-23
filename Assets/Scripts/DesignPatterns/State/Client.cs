using StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private BikeController _bikeController;

    private void Start()
    {
        _bikeController = FindObjectOfType<BikeController>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Start"))
            _bikeController.StartBike();
        if (GUILayout.Button("Turn Left"))
            _bikeController.TurnBike(Direction.Left);
        if (GUILayout.Button("Turn Right"))
            _bikeController.TurnBike(Direction.Right);
        if (GUILayout.Button("Stop"))
            _bikeController.StopBike();
    }
}
