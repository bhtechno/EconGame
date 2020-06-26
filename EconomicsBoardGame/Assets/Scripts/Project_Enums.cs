using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project_Enums
{
    public enum EVENT_TYPE { PLAYER_ARRIVED, DICE_FINISHED};
    public enum GameStatus { WAITING_THROW, AFTER_THROW} ;
    public enum TileStatus {UNOWNED_LAND, OWNED_LAND};
}
