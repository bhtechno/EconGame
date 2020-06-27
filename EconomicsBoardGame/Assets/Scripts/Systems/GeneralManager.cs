using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class GeneralManager : MonoBehaviour
{

    public GameObject board;
    public AbstractTile[] boardTiles;
    private Player currentPlayer; // current player. Both this and the movement need to be updated each turn.
    private short currentPlayerIndex = 0;
    PlayerMovement currentPlayerMovement; // current player's movement component
    // static Dictionary <EVENT_TYPE, List<EventListener>> eventListeners;
    // Enum.GetNames(typeof(MyEnum)).Length;

    // butto


    // what tile each player currently resides.
    // player1: [0], player2: [1], etc.
    AbstractTile[] playersLocations;

    // public float
    // Start is called before the first frame update
    AbstractTile tile; // temprory
    
    [SerializeField]
    Player[] players;
    private void Awake() {
        // get the board tiles
        boardTiles = board.transform.GetComponentsInChildren<AbstractTile>();
    }

    void Start()
    {
        // find players and select first one
        players = GameObject.FindObjectsOfType<Player>();
        currentPlayer = players[0];
        // currentPlayer.playerIndex = 0;
        currentPlayerMovement = currentPlayer.GetComponent<PlayerMovement>();

        // Register the function player arrived in the eventSystem, for playerArrived.
        CustomEventSystem.RegisterListener(EVENT_TYPE.PLAYER_ARRIVED, OnPlayerArrived);
        currentPlayer.transform.position = boardTiles[0].PlayersLocations[0];


        startTurn();
    }

    // Update is called once per frame
    void Update()
    {
        // if (DiceManager.DiceTotalReady())
        //     print(DiceManager.GetDiceTotal());

    }

    /*
     * Function will be called after a player arrives to his destination.
     * Set this player's PlayerMovement to disabled, and as described in the usage section
     * of that script.
    */
    private void OnPlayerArrived(EventInfo eventInfo) {
        print("player finished moving!");
        currentPlayerMovement.enabled = false;
    }

    /*
     * called by manager
    */
    public void startTurn() {
        // allow the current player to throw a dice, or do any possible action at this time
        // ex. trade, mortgage, charity, etc.
        // STATUS: WAITING FOR DICE THROW


        // after Dice throw:
        // STATUS: AFTER DICE THROW
        // here, disable dice throw, unless double
        // events should be fired. Buy land, pull card, etc.
        // also, all options before the hrow should be open.
        // enable the button to end the turn
        short diceValue = 0;
        if (DiceManager.DiceTotalReady()) {
            diceValue = DiceManager.GetDiceTotal();
            // currentPlayer.setCurrentTile()
            // currentPlayerMovement.setMovementValues()
        }


    }


    /*
    * called by a button for player
    */
    public void endTurn() {
        // current player will become next player
        // dice will be enabled
        currentPlayerIndex += 1;
        currentPlayerIndex %= (short)players.Length;
        currentPlayer = players[currentPlayerIndex];
        DiceManager.resetDices();
    }

    // TODO: Create a turn system

}
