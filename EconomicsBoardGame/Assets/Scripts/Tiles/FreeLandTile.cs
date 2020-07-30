using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class FreeLandTile : AbstractTile, ITile
{

    // Start is called before the first frame update
    private void Start() {
        this.tileType = TILE_TYPE.FREE;
    }
    public void prompyBuyLocation() {
         print("free arrived!");
         GUImanager.showImage(TILE_TYPE.FREE, this.tileImageInfo);
    }
}
