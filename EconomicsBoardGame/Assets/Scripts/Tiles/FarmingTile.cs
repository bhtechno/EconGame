﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class FarmingTile : AbstractTile, ITile
{
    // Start is called before the first frame update
    private void Start()
    {
        this.tileItem = ITEM.VEGETATION;
        this.tileType = TILE_TYPE.FARM;
    }
    public void prompyBuyLocation() {
         GUImanager.showImage(TILE_TYPE.FARM, this.tileImageInfo);
    }

}
