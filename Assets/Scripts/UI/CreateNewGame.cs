using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewGame : MonoBehaviour
{
    private int _gridNumber;
    private int _playModeNumber;
    private GameController _gameController;

    private void Awake()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void ChangeGrid(int gridNumber)
    {
        _gridNumber = gridNumber;
    }
    public void ChangePlayMode(int playModeNumber)
    {
        _playModeNumber = playModeNumber;
    }
    public void SendCreateWorldData()
    {
        _gameController.CreateWorld(_gridNumber, _playModeNumber);
    }
}
