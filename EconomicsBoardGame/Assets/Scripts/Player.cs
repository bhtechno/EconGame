using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    byte playerIndex;
    string playerColor;
    string initialBussiness;
    float moneyAmount = 5000f;
    float valueAmount = 500f;
    AbstractTile[] OwnedLands;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool MoneyDepositIsPositive (float amount) {
        return this.moneyAmount + amount > 0;
    }

    public bool ValueDepositIsPositive (float amount) {
        return this.valueAmount + amount > 0;
    }

    public void MoneyChange(float amount) {
        this.moneyAmount += amount;
    }
    public void ValueChange(float amount) {
        this.moneyAmount += amount;
    }


}
