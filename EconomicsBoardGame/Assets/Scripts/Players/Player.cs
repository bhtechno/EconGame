using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class Player : MonoBehaviour
{
    public short playerIndex; // SET BY MAIN MENU. for now, set here
    public PLAYER_COLORS playerColor;
    string initialBussiness;
    public PlayerMovement playerMovement;
    float moneyAmount = 5000f;
    float valueAmount = 500f;
    AbstractTile[] OwnedLands; // change later to list, since it's changeable

    // Start is called before the first frame update
    private AbstractTile currentTile;

    private void Awake() {
        // playerIndex = 0; // change later through main menu


    }

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public AbstractTile GetCurrentTile() {
        return currentTile;
    }
    public void setCurrentTile(AbstractTile currentTile) {
        this.currentTile = currentTile;
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
