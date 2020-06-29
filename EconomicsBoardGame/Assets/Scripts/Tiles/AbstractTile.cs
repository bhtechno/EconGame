using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public abstract class AbstractTile : MonoBehaviour
{
    protected Player owner;

    private TILE_STATUS tileStatus;
    // Where on the tile each player will be placed (global position)
    public Vector3 [] PlayersLocations;

    // Offsets from the middle of the tile for each player
    protected Vector3[] PlayerslocationsOffsets;

    [SerializeField]
    protected float cost = 3000f;
    [SerializeField]
    protected float rentMoney = 500f;
    [SerializeField]

    const short playersNo = 4;
    Vector3 location;
    void Awake() {
        tileStatus = TILE_STATUS.UNOWNED_LAND;
        // assign the offsets to each player
        PlayerslocationsOffsets = new Vector3[4];
        PlayerslocationsOffsets[0] = new Vector3(-0.75f, 0.45f, 0.75f);
        PlayerslocationsOffsets[1] = new Vector3(0.75f, 0.45f, -0.75f);
        PlayerslocationsOffsets[2] = new Vector3(0.75f, 0.45f, 0.75f);
        PlayerslocationsOffsets[3] = new Vector3(-0.75f, 0.45f, -0.75f);

        // add the global position of the tile to the offsets
        PlayersLocations = new Vector3[4];
        for (int i = 0; i < playersNo; i++)
        {
            PlayersLocations[i] = transform.position + Vector3.up * PlayerslocationsOffsets[i].y
            + Vector3.right * PlayerslocationsOffsets[i].x + Vector3.forward * PlayerslocationsOffsets[i].z;
        }
    }

    public bool buyLocation(Player buyer) {
        if (!buyer.MoneyDepositIsPositive(-cost) || owner != null) {
            return false;
        }
        buyer.MoneyChange(-cost);
        this.owner = buyer;
        this.tileStatus = TILE_STATUS.OWNED_LAND;
        return true;
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
