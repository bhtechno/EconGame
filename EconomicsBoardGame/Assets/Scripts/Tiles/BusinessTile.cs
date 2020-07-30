using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;


public class BusinessTile : AbstractTile, ITile
{
    public BUSSINESS_TYPE businessType;
    private void Start() {
        this.tileType = TILE_TYPE.BUSSINESS;
    }

    public void prompyBuyLocation() {
         print("business arrived!");
         GUImanager.showImage(TILE_TYPE.BUSSINESS, this.tileImageInfo);
    }

}
