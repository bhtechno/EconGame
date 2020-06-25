using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTile : MonoBehaviour
{
    protected Player owner;
    // Where on the tile each player will be placed (global position)
    public Vector3 [] PlayersLocations;

    // Offsets from the middle of the tile for each player
    protected Vector3[] PlayerslocationsOffsets;

    [SerializeField]
    protected float cost = 3000f;
    [SerializeField]
    protected float rentMoney = 500f;
    [SerializeField]

    Vector3 location;
    void Awake() {

        // assign tthe offsets to each player
        PlayerslocationsOffsets = new Vector3[4];
        PlayerslocationsOffsets[0] = new Vector3(-0.5f, 0.7f, 0.5f);
        PlayerslocationsOffsets[1] = new Vector3(0.4f, 0.7f, 0.5f);
        PlayerslocationsOffsets[2] = new Vector3(0.4f, 0.7f, -0.25f);
        PlayerslocationsOffsets[3] = new Vector3(-0.5f, 0.7f, -0.25f);

        // add the global position of the tile to the offsets
        PlayersLocations = new Vector3[4];
        PlayersLocations[0] = transform.position + Vector3.up * PlayerslocationsOffsets[0].y
            + Vector3.left * PlayerslocationsOffsets[0].x + Vector3.forward * PlayerslocationsOffsets[0].z;

        PlayersLocations[1] = transform.position + Vector3.up * PlayerslocationsOffsets[1].y
            + Vector3.left * PlayerslocationsOffsets[1].x + Vector3.forward * PlayerslocationsOffsets[1].z;

        PlayersLocations[2] = transform.position + Vector3.up * PlayerslocationsOffsets[2].y
            + Vector3.left * PlayerslocationsOffsets[2].x + Vector3.forward * PlayerslocationsOffsets[2].z;

        PlayersLocations[3] = transform.position + Vector3.up * PlayerslocationsOffsets[3].y
            + Vector3.left * PlayerslocationsOffsets[3].x + Vector3.forward * PlayerslocationsOffsets[3].z;

        // location = transform.position + Vector3.up * 0.5f + Vector3.right * 0.25f;
    }

    public bool payRent(Player visitor) {
        if (visitor.MoneyDepositIsPositive(rentMoney)) {
            owner.MoneyChange(rentMoney);
            visitor.MoneyChange(-rentMoney);
            return true;
        }
        return false;
    }

    // private Image info;
}
