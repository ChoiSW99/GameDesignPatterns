using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    void Start()
    {
        _sessionStartTime = DateTime.Now;
        Debug.Log("Game Start : " + _sessionStartTime);
    }

    void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDiff = _sessionEndTime.Subtract(_sessionStartTime);

        Debug.Log("Game Record : " + timeDiff);
    }

    void OnGUI()
    {
        if ((GUILayout.Button("Next Scene")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
