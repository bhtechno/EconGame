using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class ResidintialTile : AbstractTile, ITile
{
    private void Start() {
        this.tileType = TILE_TYPE.RESIDENCE;
    }
    public void playerArrived() {
         print("residential arrived!");
         GUImanager.showImage(TILE_TYPE.RESIDENCE, this.tileImageInfo);
    }

}
