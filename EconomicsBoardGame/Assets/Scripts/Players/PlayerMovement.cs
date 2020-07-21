using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class PlayerMovement : MonoBehaviour
{
/*
 * Usage: Enable the component, then set the current tile index, and the target tile Index.
 * It will alert subscribers when arrived. Disable the component now.
 */

    GeneralManager generalManager;
    public float jumpHeight = 0.5f;
    public float singleMoveTime = 0.5f;
    [SerializeField] private short playerIndex = -1;
    public float arrivalDistanceSensitivity = 0.05f;
    [SerializeField] private AbstractTile[] boardTiles;
    private Player playerComponent;
    [SerializeField] private short currentTileIndex = 0 ;
    [SerializeField] private short targetTileIndex = 0;
    private short nextTileIndex = 1;
    [SerializeField] private bool giveIncome = true;

    private Vector3 velocity = Vector3.zero; // used by smoothDampen exclusively

    // Start is called before the first frame update

    void Start()
    {
        generalManager = GameObject.FindObjectOfType<GeneralManager>();
        playerComponent = GetComponent<Player>();
        boardTiles = generalManager.boardTiles;
        playerIndex = playerComponent.playerIndex;
        this.enabled = false;
    }
    void Update()
    {
        if (currentTileIndex != targetTileIndex) {

            //  targetTileIndex %= (short)boardTiles.Length;
            //  currentTileIndex %= (short)boardTiles.Length; // loop around the board

            if (TraverseUpToTile(currentTileIndex, (short)(nextTileIndex))) {
                currentTileIndex++;
                currentTileIndex %= (short)boardTiles.Length; // loop around the board
                nextTileIndex = (short)((short)(currentTileIndex + 1) % (short)boardTiles.Length);
            }
        } else {
            arrivalProcedure();
            // tell the caller that we Have arrived. Set the player's tile location.
        }
    }

    public short getTileIndex() {
        return currentTileIndex;
    }

    /*
     * Used to set the tile locations to start a player movement
    */
    public void setMovementValues(short diceValue) {
        // this.currentTileIndex = (short)(currentTileIndex % (short)boardTiles.Length); // loop around the board
        // this.targetTileIndex = (short)(targetTileIndex % (short)boardTiles.Length); // loop around the board
        this.targetTileIndex = (short)((this.currentTileIndex + diceValue) % boardTiles.Length);
    }

    /*
     * Called when the destination tile is reached.
    */
    private void arrivalProcedure() {
        playerComponent.setCurrentTile(boardTiles[currentTileIndex]);
        CustomEventSystem.fireEvent(EVENT_TYPE.PLAYER_ARRIVED);
         // send alert event
    }
    /*
     * Function will move from the give location to the target,
     * It returns true if arrived, and false while still moving
    */
    private bool twoPointsMovement(Vector3 currentPosition, Vector3 targetPosition) {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, singleMoveTime);
        return arrivedToLocation(transform.position, targetPosition);
    }

    /*
     * Function will move from the give location to the target, and jump in the middle
     * It returns true if arrived, and false while still moving
    */
    private bool OneTileMove(Vector3 frstTilePosition, Vector3 scndTilePosition) {

        Vector3 currentPosition = transform.position;
        // scndTilePosition = new Vector3(2.4f, -0.5f, -4.3f);
        Vector3 jumpPosition = ((frstTilePosition + scndTilePosition) / 2) + Vector3.up * jumpHeight;

        if(Vector3.Distance(currentPosition, scndTilePosition) >
            Vector3.Distance(currentPosition, frstTilePosition)) {
                // we are in the first ark
                if (arrivedToLocation(currentPosition, jumpPosition)) {
                    // switch to next tile
                    twoPointsMovement(jumpPosition, scndTilePosition);
                } else { // move towards jump position
                    twoPointsMovement(frstTilePosition, jumpPosition);
                }
        } else {
                    twoPointsMovement(jumpPosition, scndTilePosition);
        }
        return arrivedToLocation(transform.position, scndTilePosition);
        // divide the move to two parts, first, middle up between two positions
        // then towards the target.
    }

    /*
     * Function transforms tile index to a position, and then calls
     * the function to move the player from current to the next one
    */
    private bool TraverseUpToTile(short currentTileIndex, short targetTileIndex) {

        Vector3 currentPosition = boardTiles[currentTileIndex].PlayersLocations[playerIndex];
        Vector3 TargetPosition = boardTiles[targetTileIndex].PlayersLocations[playerIndex];
        if(OneTileMove(currentPosition, TargetPosition)) {
            if (giveIncome) {
                if ((currentTileIndex == boardTiles.Length - 1)
                    && (targetTileIndex == 0) ) {
                CustomEventSystem.fireEvent(EVENT_TYPE.GIVE_INCOME,
                     new EventInfo(playerIndex));
                }
            }
            return true;
        } else {
            return false;
        }
    }
    /*
     * Returns number of moves in between the two given indices
    */
    private short IndicesBetweenTiles (short firstIndex, short secondIndex, short boardLength) {
        if (secondIndex > firstIndex)
            return (short)(secondIndex - firstIndex);
        else {
            // loop around the start
            short temp = (short)(boardLength - firstIndex + secondIndex);
            return temp;
        }
    }

    /*
     * If the distance between the two locations is less than the sensitivity, we
     * count it as arrived.
    */
    private bool arrivedToLocation(Vector3 location1, Vector3 location2) {
        return Vector3.Distance(location1, location2) < arrivalDistanceSensitivity;
    }
}
