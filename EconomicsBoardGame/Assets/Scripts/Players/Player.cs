using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class Player : MonoBehaviour
{
    // private static short playersTotal = 0;
    public short playerIndex; // SET BY MAIN MENU. for now, set here
    public PLAYER_COLORS playerColor;
    private Renderer myRenderer;
    public PlayerMovement playerMovement;
    float moneyAmount = 15000f;
    float valueAmount = 1500f;
    float income1 = 0;
    float income2 = 0;

    [SerializeField] List<AbstractTile> OwnedLands;
    // Start is called before the first frame update
    private AbstractTile currentTile;
    [SerializeField] JOB_SELECTION initialJob = default;
    [SerializeField] JobPanel.JobInformation jobInformationStruct = default;
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
     * This function receives the initial job struct formed after the player
     * selected their initial business, and sets it too the current player.
     * it should be then updates as the game progresses.
     */
    public void setJobInfoSruct(JobPanel.JobInformation jobInfo) {
        jobInformationStruct = jobInfo;
        this.initialJob = jobInfo.jobTypeEnum;
    }

    public List<AbstractTile> getOwnedLands() {
        return OwnedLands;
    }

    public float getMoneyBalance() {
        return moneyAmount;
    }

    public float getValueBalance() {
        return valueAmount;
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
        this.valueAmount += amount;
    }
    public void giveIncome() {
        this.moneyAmount += income1;
        this.valueAmount += income2;
    }
    /*
     * This function will recalculate the income based on the latest
     * updates to any income source the player owns.
     * it should be called after any change to an income source
     */
    public void calculateIncome() {
        income1 = jobInformationStruct.current1;
        income2 = jobInformationStruct.current2;
    }

}
