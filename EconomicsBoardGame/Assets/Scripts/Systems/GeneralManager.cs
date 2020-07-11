using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class GeneralManager : MonoBehaviour
{

    public GameObject board;
    public AbstractTile[] boardTiles;
    private Player currentPlayer; // current player. Both this and the movement need to be updated each turn.
    private short currentPlayerIndex = 0;

    public GameObject playersParent;
    private GameObject playerPrefab;
    // what tile each player currently resides.
    // player1: [0], player2: [1], etc.
    // AbstractTile[] playersLocations;
    [SerializeField] Player[] players;
    private void Awake() {
        loadPrefabsFromResources();
        // get the board tiles
        boardTiles = board.transform.GetComponentsInChildren<AbstractTile>();
        IComparer compareFunction = new PlayerCompare();
        // players = GameObject.FindObjectsOfType<Player>();
        // Array.Sort(players, compareFunction);
        for (int i = 0; i < GameInfo.playersNo; i++)
            Instantiate(playerPrefab, playersParent.transform);

        players = playersParent.GetComponentsInChildren<Player>();
        print("Players. Length = " + players.Length + "Gameinfo players.No:" + GameInfo.playersNo);
        print("\nGameInfo playercolors arr length" + GameInfo.playersColors.Length);
        print("boardTiles[0].playerLocations length" + boardTiles[0].PlayersLocations.Length);
        // find players and select first one

    }

    private void loadPrefabsFromResources() {
        playerPrefab = Resources.Load("Prefabs/PlayerPrefab") as GameObject;
    }

    void Start()
    {
         for (short i = 0; i < GameInfo.playersNo; i++)
        {
            players[i].playerIndex = i;
            players[i].playerColor = GameInfo.playersColors[i];
            players[i].transform.position = boardTiles[0].PlayersLocations[i];
        }

        currentPlayer = players[0];
        DiceManager.resetDices();
        // Register the function player arrived in the eventSystem, for playerArrived.
        CustomEventSystem.RegisterListener(EVENT_TYPE.PLAYER_ARRIVED, OnPlayerArrived);
        startTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (DiceManager.DiceTotalReady()) {
            short totalMoves = DiceManager.GetDiceTotal();
            DiceManager.ResetDiceReadyStatus();
            currentPlayer.playerMovement.setMovementValues(totalMoves);
            currentPlayer.playerMovement.enabled = true;
        }
    }

    /*
     * Function will be called after a player arrives to his destination.
     * Set this player's PlayerMovement to disabled, and as described in the usage section
     * of that script.
    */
    private void OnPlayerArrived(EventInfo eventInfo) {
        AbstractTile currentTile = currentPlayer.GetCurrentTile();
        // convert tile to interface, to use each tile's type's specific functions
        ITile currentTileInterface = currentTile as ITile;

        currentPlayer.playerMovement.enabled = false;
        if (currentTile.GetTILE_STATUS() != TILE_STATUS.OWNED_LAND) {
            // prompt player to pay
             if (currentTile.GetTILE_TYPE() != TILE_TYPE.EMPTY) {
                currentTileInterface.playerArrived();
                GUImanager.EnableButton(BUTTON_TYPE.BUY);
            }

        } else {

            // GUImanager.promptTileBuy(currentPlayer.GetCurrentTile().getTileCard());

            // prompt player to buy
        }


        GUImanager.EnableButton(BUTTON_TYPE.END_TURN);
    }

    /*
     * called by manager
    */
    public void startTurn() {
        // allow the current player to throw a dice, or do any possible action at this time
        // ex. trade, mortgage, charity, etc.
        // STATUS: WAITING FOR DICE THROW
        GUImanager.enableGlowofPlayer(currentPlayerIndex);
        GUImanager.DisableButton(BUTTON_TYPE.END_TURN);
        GUImanager.EnableButton(BUTTON_TYPE.THROW_DICE);
        // after Dice throw:
        // STATUS: AFTER DICE THROW
        // here, disable dice throw, unless double
        // events should be fired. Buy land, pull card, etc.
        // also, all options before the hrow should be open.
        // enable the button to end the turn


        //     // currentPlayer.setCurrentTile()
        //     // currentPlayerMovement.setMovementValues()


    }

    /*
    * called by a button for player
    */
    public void endTurn() {
        // current player will become next player
        // dice will be enabled
        GUImanager.disableGlowofPlayer(currentPlayerIndex);
        GUImanager.DisableButton(BUTTON_TYPE.BUY);
        currentPlayerIndex += 1;
        currentPlayerIndex %= (short)players.Length;
        currentPlayer = players[currentPlayerIndex];
        DiceManager.resetDices();
        GUImanager.EnableButton(BUTTON_TYPE.THROW_DICE);
        GUImanager.removeImage(); // temprory
        startTurn();
        // Also, throw button should be enabled, and made interacable
    }

    public void buyCurrentTile() {
        if (currentPlayer.GetCurrentTile().buyLocation(currentPlayer)) {
            GUImanager.DisableButton(BUTTON_TYPE.BUY);
        }

    }

    public Player[] getPlayerArray() {
        return players;
    }


}


/*
 * Used to sort the players based on their order under the parent
*/
public class PlayerCompare : IComparer
{
   public int Compare(object p1, object p2) {
        // GameObject frstP = (GameObject)p1;
        // GameObject scndP = (GameObject)p2;
        return ((Player)(p1)).transform.GetSiblingIndex().CompareTo(((Player)p2).transform.GetSiblingIndex());
    }
}