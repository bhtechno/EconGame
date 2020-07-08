using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class Player : MonoBehaviour
{
    public short playerIndex; // SET BY MAIN MENU. for now, set here
    public PLAYER_COLORS playerColor;
    private Renderer myRenderer;
    string initialBussiness;
    public PlayerMovement playerMovement;
    float moneyAmount = 15000f;
    float valueAmount = 1500f;
    [SerializeField] List<AbstractTile> OwnedLands;

    // Start is called before the first frame update
    private AbstractTile currentTile;

    private void Awake() {
        OwnedLands = new List<AbstractTile>();
        // playerIndex = 0; // change later through main menu
        myRenderer = GetComponent<Renderer>();
    }

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        ColorManager.changeMyRendererColor(myRenderer, playerColor);
        // this.transform.
    }

    /*
    * used by the tile to assign itself to this player
    */
    public void addLandToOwned(AbstractTile boughtTile) {
        OwnedLands.Add(boughtTile);
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
