using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class ValueBusinessTile : AbstractTile, ITile
{

    private VALUE_BUSINESS_TYPE valueBusinessType;
    // Start is called before the first frame update
    private void Start() {
        this.tileType = TILE_TYPE.VALUE;
    }

    public void setValueBussinessType(VALUE_BUSINESS_TYPE valueBusinessType) {
        this.valueBusinessType = valueBusinessType;
    }
    public void playerArrived() {
          print("Value arrived!");
         GUImanager.showImage(TILE_TYPE.VALUE, this.tileImageInfo);
    }

}
