using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

    public static int[] diceValues; // 2 values.Updated with the results of dice throws
    private DiceScript[] diceInstances; // The diceobjects
    private byte diceSetCount = 0; // how many dices values are set up to now.

    int total = 0; // temprory variable. used to view the total of throws
    private void Awake() {
        diceValues = new int[2];
        diceInstances = GetComponentsInChildren<DiceScript>();
    }

    /*
     *if both dices values are available, then we are ready to give the value
    */
    public bool DiceTotalReady() {
        return diceSetCount == diceInstances.Length;
    }
    /*
    * used by the dice value zone reader to set the value of one dice
    */
    public void setDice(byte value) {
        diceValues[diceSetCount] = value;
        diceSetCount++;
        total = diceValues[0] + diceValues[1];
    }


    /*
     * used to get the total of the two die
    */
    public int GetDiceTotal() {
        int diceTotal = 0;
        for (int i = 0; i < diceValues.Length; i++)
        {
            diceTotal += diceValues[i];
        }
        return diceTotal;
    }


    /*
     * Resets Dice colliders, disables gravity and boxcollider, moves dice to the side
     * and resets the diceSetCount to zero
     */
    public void resetDices() {
        for (int i = 0; i < diceInstances.Length; i++)
        {
            diceValues[i] = 0;
            diceInstances[i].ResetThisDice();
            diceInstances[i].GetComponent<Rigidbody>().useGravity = false;
            diceInstances[i].GetComponent<BoxCollider>().enabled = false;
            diceInstances[i].transform.position = new Vector3(10, 0, i);
        }
        diceSetCount = 0;
        total = 0;
    }

    /*
     * Enables gravity, boxcollider, and calls the dices throw functions
    */
    public void ThrowAllDice() {
        print(" called throw!");
        for (int i = 0; i < diceInstances.Length; i++)
        {
            diceInstances[i].GetComponent<Rigidbody>().useGravity = true;
            diceInstances[i].GetComponent<BoxCollider>().enabled = true;
            diceInstances[i].ThrowDice();
        }
    }

    // TODO: enables and disable the throws speed frame checks here.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



}
