using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class InnovativeTile : AbstractTile, ITile
{

    private INNOVATIVE_TYPE innovativeType;

    // Start is called before the first frame update
    private void Start()
    {
        this.tileType = TILE_TYPE.INNOVATIVE;
        this.tileItem = ITEM.IOT_DEVICES;
    }

    public void setInnovativeTypr(INNOVATIVE_TYPE innovativeType) {
        this.innovativeType = innovativeType;
    }
    public void prompyBuyLocation() {
         print("Innovative arrived!");
         GUImanager.showImage(TILE_TYPE.INNOVATIVE, this.tileImageInfo);
    }


}
