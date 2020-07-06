using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;


public class BusinessTile : AbstractTile, ITile
{
    public BUSSINESS_TYPE businessType;

    public void playerArrived() {
         print("business arrived!");
         GUImanager.showImage(TILE_TYPE.BUSSINESS);
    }

}
