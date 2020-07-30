using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class Player : MonoBehaviour
{
    public short playerIndex; // SET BY MAIN MENU.
    public PLAYER_COLORS playerColor;
    private Renderer myRenderer;
    public PlayerMovement playerMovement;
    [SerializeField] float moneyAmount = 15000f;
    [SerializeField] float valueAmount = 1500f;
    float income1 = 0;
    float income2 = 0;
    [SerializeField] List<AbstractTile> OwnedLands;
    // Start is called before the first frame update
    private AbstractTile currentTile;
    [SerializeField] JOB_SELECTION initialJob = default;
    [SerializeField] JobPanel.JobInformation jobInformationStruct = default;
    private Dictionary<ITEM, int> playerInventory;
    [SerializeField] private WinProject playerProject;

    private void Awake() {
        playerInventory = new Dictionary<ITEM, int>();
        playerProject = new WinProject();
        OwnedLands = new List<AbstractTile>();
        myRenderer = GetComponent<Renderer>();
    }

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        ColorManager.changeMyRendererColor(myRenderer, playerColor);
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
    * used by the tile to assign itself to this player, also checks if the player
    * won the game
    */
    public void addLandToOwned(AbstractTile boughtTile) {
        OwnedLands.Add(boughtTile);
        fillTileItem(boughtTile);
        if(playerHasWon())
            print("Player won:" + (playerIndex + 1));
    }

    private void fillTileItem(AbstractTile tile) {
        if(tile.tileHasItem()) {
            ITEM item = tile.getItemType();
            int capacity = playerProject.getItemCapacity(item);
            for (int i = 0; i < capacity; i++)
            {
                addItem(item);
            }
            if (itemIsOwned(item))
                playerInventory[item] = -1;
            else
                playerInventory.Add(item, -1);
        }
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
     * Add item to the inventory, and if the item is needed for the project, also add it there
     * The check for winning also occurs here
     */
    public void addItem(ITEM item) {
        if (itemIsOwned(item)) {
            // -1 means unlimited. Capacity is already full
            if (playerInventory[item] == -1)
                return;
            else
                playerInventory[item]++;
        } else
            playerInventory.Add(item, 1);

        playerProject.addItem(item);
        print(playerProject.ToString());
        if(playerHasWon())
            print("Player won:" + (playerIndex + 1));
    }

    public bool playerHasWon() {
        return playerProject.projectIsCompleted();
    }

    private bool itemIsOwned(ITEM item) {
        return playerInventory.ContainsKey(item);
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
