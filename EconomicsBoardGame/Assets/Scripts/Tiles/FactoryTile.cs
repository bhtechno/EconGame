using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class FactoryTile : AbstractTile, ITile
{
    // Start is called before the first frame update

    private void Start() {
        this.tileType = TILE_TYPE.FACTORY;
        this.tileItem = ITEM.BUILDING_EQUIPMENT;
    }
    public void prompyBuyLocation() {
         GUImanager.showImage(TILE_TYPE.FACTORY, this.tileImageInfo);
    }


}
