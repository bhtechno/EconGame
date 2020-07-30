using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;


public class OtherTile : AbstractTile, ITile
{
    public OTHER_TYPE otherType;
    // Start is called before the first frame update
    private void Start() {
        this.tileType = TILE_TYPE.OTHER;
    }
    public void prompyBuyLocation() {
          print("Other arrived!");
         GUImanager.showImage(TILE_TYPE.OTHER, this.tileImageInfo);
    }



}
