using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class GeneralManager : MonoBehaviour
{

    public GameObject board;
    public AbstractTile[] boardTiles;
    Player currentPlayer;

    // what tile each player currently resides.
    // player1: [0], player2: [1], etc.
    AbstractTile[] playersLocations;

    // public float
    // Start is called before the first frame update
    AbstractTile tile; // temprory

    void Start()
    {
        currentPlayer = GameObject.FindObjectOfType<Player>();
        boardTiles = board.transform.GetComponentsInChildren<AbstractTile>();

        // Register the function player arrived in the eventSystem, for playerArrived.
        CustomEventSystem.RegisterListener(EVENT_TYPE.PLAYER_ARRIVED, OnPlayerArrived);

        for (int i = 0; i < boardTiles.Length; i++)
        {
            // print(boardTiles[i].name);
        }
        currentPlayer.transform.position = boardTiles[0].PlayersLocations[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Function will be called after a player arrives to his destination.
     * Set this player's PlayerMovement to disabled, and as described in the usage section
     * of that script.
    */
    private void OnPlayerArrived(EventInfo eventInfo) {
        print("player finished moving!");
    }

    // TODO: Create a turn system

}
