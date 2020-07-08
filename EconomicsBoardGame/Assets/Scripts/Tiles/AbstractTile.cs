using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;

public abstract class AbstractTile : MonoBehaviour
{
    public struct TileImageInfo {
        string name;
        float cost; // {get; set;}
        float rentMoney; //  {get; set;}

        public string getName() {
            return name;
        }

        public float getCost() {
            return cost;
        }

        public float getRent() {
            return rentMoney;
        }
        public void setValues(string name, float cost, float rent) {
            this.name = name;
            this.cost = cost;
            this.rentMoney = rent;
        }
    }

    protected Player owner;
    private TILE_STATUS tileStatus;
    // Where on the tile each player will be placed (global position)
    public Vector3 [] PlayersLocations;
    // Offsets from the middle of the tile for each player
    protected Vector3[] PlayerslocationsOffsets;

    [SerializeField] string tileName = "";
    [SerializeField] protected float cost = 3000f;
    [SerializeField] protected float rentMoney = 500f;
    [SerializeField] protected TileImageInfo tileImageInfo;
    protected TILE_TYPE tileType;

    const short playersNo = 4;

    void Awake() {

        // tileImageInfo.
        tileStatus = TILE_STATUS.UNOWNED_LAND;
        // assign the offsets to each player
        PlayerslocationsOffsets = new Vector3[4];
        PlayerslocationsOffsets[0] = new Vector3(-0.75f, 0.45f, 0.75f);
        PlayerslocationsOffsets[1] = new Vector3(0.7f, 0.45f, -0.7f);
        PlayerslocationsOffsets[2] = new Vector3(0.75f, 0.45f, 0.75f);
        PlayerslocationsOffsets[3] = new Vector3(-0.7f, 0.45f, -0.7f);

        // add the global position of the tile to the offsets
        PlayersLocations = new Vector3[4];
        for (int i = 0; i < playersNo; i++)
        {
            PlayersLocations[i] = transform.position + Vector3.up * PlayerslocationsOffsets[i].y
            + Vector3.right * PlayerslocationsOffsets[i].x + Vector3.forward * PlayerslocationsOffsets[i].z;
        }

        tileImageInfo = new TileImageInfo();
        tileImageInfo.setValues(this.tileName, this.cost, this.rentMoney);
    }

    public bool IsOwned() {
        return owner != null;
    }

    public TILE_TYPE GetTILE_TYPE() {
        return tileType;
    }


    public TILE_STATUS GetTILE_STATUS() {
        return tileStatus;
    }

    public bool buyLocation(Player buyer) {
        if (!buyer.MoneyDepositIsPositive(-cost) || owner != null) {
            return false;
        }
        buyer.addLandToOwned(this);
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

}
