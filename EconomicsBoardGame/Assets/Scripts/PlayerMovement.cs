using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    GeneralManager generalManager;
    public float jumpHeight = 0.5f;
    public float moveSpeed = 0.5f;
    protected AbstractTile[] boardTiles;

    // Start is called before the first frame update

    private void Awake() {
    }
    void Start()
    {
        generalManager = GameObject.FindObjectOfType<GeneralManager>();
        boardTiles = generalManager.boardTiles;
    }

    // Update is called once per frame
    void Update()
    {
        // if (arrived) set new target



    }

    /*
     * Function will move from the give location to the target, and jump in the middle
     * It returns the distance between the current location and the target location.
    */
    private float OneTileMoveAndDistance(Vector3 frstTilePosition, Vector3 scndTilePosition) {

        Vector3 currentPosition = transform.position;
        // scndTilePosition = new Vector3(2.4f, -0.5f, -4.3f);
        Vector3 jumpPosition = ((frstTilePosition + scndTilePosition) / 2) + Vector3.up * jumpHeight;

        if(Vector3.Distance(currentPosition, scndTilePosition) >
            Vector3.Distance(currentPosition, frstTilePosition)) {
                // we are in the first ark
                if (Vector3.Distance(currentPosition, jumpPosition) < 0.05f) {
                    // switch to next tile
                    twoPointsMovement(jumpPosition, scndTilePosition);
                } else { // move towards jump position
                    twoPointsMovement(frstTilePosition, jumpPosition);
                }
        } else {
                    twoPointsMovement(jumpPosition, scndTilePosition);
        }
        return Vector3.Distance(transform.position, scndTilePosition);
        // divide the move to two parts, first, middle up between two positions
        // then towards the target.
    }

    private void twoPointsMovement(Vector3 currentPosition, Vector3 targetPosition) {
        Vector3 velocity = Vector3.one;
        this.transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, 0.25f);
    }


    public bool TraverseUpToTile(byte playerIndex, short currentTileIndex, short targetTileIndex) {
        Vector3 currentPosition = boardTiles[currentTileIndex].PlayersLocations[playerIndex];
        Vector3 TargetPosition = boardTiles[targetTileIndex].PlayersLocations[playerIndex];


        return false;
    }




}
