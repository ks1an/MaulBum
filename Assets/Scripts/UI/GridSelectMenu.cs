using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSelectMenu : MonoBehaviour
{
    [SerializeField] private CreateNewGame _createNewGame;
    public void InputMenu(int value)
    {
        _createNewGame.ChangeGrid(value);
    }
}
