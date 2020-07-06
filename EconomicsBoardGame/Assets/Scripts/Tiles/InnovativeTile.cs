using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class InnovativeTile : AbstractTile, ITile
{

    private INNOVATIVE_TYPE innovativeType;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setInnovativeTypr(INNOVATIVE_TYPE innovativeType) {
        this.innovativeType = innovativeType;
    }
    public void playerArrived() {
         print("Innovative arrived!");
         GUImanager.showImage(TILE_TYPE.INNOVATIVE);
    }


}
