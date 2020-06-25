using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{

    public GameObject board;
    public AbstractTile[] boardTiles;
    Player currentPlayer;
    enum GameStatus { WAITING_THROW, AFTER_THROW} ;
    enum TileStatus {UNOWNED_LAND, OWNED_LAND};


    // what tile each player currently resides.
    // player1: [0], player2: [1], etc.
    AbstractTile[] playersLocations;

    // public float
    // Start is called before the first frame update
    AbstractTile tile; // temprory

    void Start()
    {
        currentPlayer = GameObject.FindObjectOfType<Player>();
        // print("Name = " + currentPlayer.name);
        boardTiles = board.transform.GetComponentsInChildren<AbstractTile>();
        // tile = board.transform.GetComponentInChildren<AbstractTile>();
        // position = tile.transform.position;
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

    // TODO: Create a turn system

}
