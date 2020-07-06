using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class FreeLandTile : AbstractTile, ITile
{

    // Start is called before the first frame update
    public void playerArrived() {
         print("free arrived!");
         GUImanager.showImage(TILE_TYPE.FREE);
    }
}
