using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class EmptyTile : AbstractTile, ITile
{
    public EMPTY_TILE_TYPE emptyTileType;
    private void Start() {
        this.cost = 0;
        this.rentMoney = 0;
        this.tileType = TILE_TYPE.EMPTY;
    }

     public void playerArrived() {
         print("empty arrived!");
         GUImanager.showImage(TILE_TYPE.EMPTY, this.tileImageInfo);
        //  GUImanager.showImage(TILE_TYPE.BUSSINESS);
    }

}
