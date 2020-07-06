using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class ValueBusinessTile : MonoBehaviour, ITile
{

    private VALUE_BUSINESS_TYPE valueBusinessType;
    // Start is called before the first frame update


    public void setValueBussinessType(VALUE_BUSINESS_TYPE valueBusinessType) {
        this.valueBusinessType = valueBusinessType;
    }
    public void playerArrived() {
    }

}
