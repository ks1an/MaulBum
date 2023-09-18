using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayMode : MonoBehaviour
{
    [SerializeField] private CreateNewGame _createNewGame;
    public void InputMenu(int value)
    {
        _createNewGame.ChangePlayMode(value);
    }
}
