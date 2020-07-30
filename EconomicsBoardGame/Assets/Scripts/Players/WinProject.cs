using System.Collections;
using System.Collections.Generic;
using static Project_Enums;
public class WinProject
{
    public Dictionary<ITEM, int> itemsCapacity;
    private Dictionary<ITEM, int> itemsCollected;
    private PROJECT_TYPE pROJECT_TYPE = default;

    // constructor
    public WinProject(PROJECT_TYPE type = PROJECT_TYPE.DEFAULT) {
        itemsCapacity = new Dictionary<ITEM, int>();
        itemsCollected = new Dictionary<ITEM, int>();
        initializeDicts();
    }


    /*
     * Initializes the dictionaries responsoble for holding the amount required of each
     * item to win the game, and the amount colleted so far.
     */
    private void initializeDicts() {
        switch (pROJECT_TYPE) {
            case PROJECT_TYPE.DEFAULT:
                initializeItem(ITEM.BUILDING_EQUIPMENT, 2);
                initializeItem(ITEM.CGI_EXPERTISE, 2);
                initializeItem(ITEM.IOT_DEVICES, 2);
                initializeItem(ITEM.VEGETATION, 2);
                break;
        }
    }

    /*
     * Add item to the capacity list with capacity selected, and add it
     * to to the collected list initialized to 0
     */
    private void initializeItem(ITEM item, short capacity) {
            itemsCapacity.Add(item, capacity);
            itemsCollected.Add(item, 0);
    }

    public void addItem(ITEM item) {
        // if available and capacity is not reached
        if ((itemsCollected.ContainsKey(item)) && (itemsCollected[item] < itemsCapacity[item])) {
            itemsCollected[item]++;
        }
    }

    /*
     * If the return value is true, the player wins, which is when the capacity is equal to the collected
     */
    public bool projectIsCompleted() {
        // if the collected values equal to the capacity, then the project is finished
        foreach(KeyValuePair<ITEM, int> entry in itemsCapacity)
        {
            if (entry.Value != itemsCollected[entry.Key])
                return false;
        }
        return true;
    }

    public int getItemCapacity(ITEM item) {
        if (itemsCapacity.ContainsKey(item))
            return itemsCapacity[item];
        return 0;
    }

    public override string ToString() {
        string all = "";
        foreach(KeyValuePair<ITEM, int> entry in itemsCapacity)
        {
            all += entry.Key + ": " + entry.Value + "\n";
            all += "Collected: " + itemsCollected[entry.Key] + "\n\n";
        }
        return all;
    }
}
