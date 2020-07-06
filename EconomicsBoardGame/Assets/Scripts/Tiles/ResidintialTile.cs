using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class ResidintialTile : AbstractTile, ITile
{
    public void playerArrived() {
         print("residential arrived!");
         GUImanager.showImage(TILE_TYPE.RESIDENCE);
    }

}
