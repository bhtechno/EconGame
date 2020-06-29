using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

    public static int[] diceValues; // 2 values.Updated with the results of dice throws
    private static DiceScript[] diceInstances; // The diceobjects
    private static byte diceSetCount = 0; // how many dices values are set up to now.
    [SerializeField] static int total = 0; // temprory variable. used to view the total of throws
    private void Awake() {
        diceValues = new int[2];
        diceInstances = GetComponentsInChildren<DiceScript>();
    }

    /*
     *if both dices values are available, then we are ready to give the value
    */
    public static bool DiceTotalReady() {
        return diceSetCount == diceInstances.Length;
    }
    /*
    * used by the dice value zone reader to set the value of one dice
    */
    public static void setDice(byte value) {
        if (diceSetCount > diceValues.Length) {
            total = diceValues[0] + diceValues[1];
            return;
        }
        diceValues[diceSetCount] = value;
        diceSetCount++;
        total = diceValues[0] + diceValues[1];
    }

    public static void ResetDiceReadyStatus() {
        diceSetCount = 0;
    }


    /*
     * used to get the total of the two die
    */
    public static short GetDiceTotal() {
        int diceTotal = 0;
        for (int i = 0; i < diceValues.Length; i++)
        {
            diceTotal += diceValues[i];
        }
        return (short)diceTotal;
    }


    /*
     * Resets Dice colliders, disables gravity and boxcollider, moves dice to the side
     * and resets the diceSetCount to zero
     */
    public static void resetDices() {
        for (int i = 0; i < diceInstances.Length; i++)
        {
            diceValues[i] = 0;
            diceInstances[i].ResetThisDice();
            diceInstances[i].GetComponent<Rigidbody>().useGravity = false;
            diceInstances[i].GetComponent<BoxCollider>().enabled = false;
            diceInstances[i].transform.position = new Vector3(20, 10, i);
        }
        diceSetCount = 0;
        total = 0;
    }

    /*
     * Enables gravity, boxcollider, and calls the dices throw functions
    */
    public static void ThrowAllDice() {
        print(" called throw!");
        for (int i = 0; i < diceInstances.Length; i++)
        {
            diceInstances[i].GetComponent<Rigidbody>().useGravity = true;
            diceInstances[i].GetComponent<BoxCollider>().enabled = true;
            diceInstances[i].ThrowDice();
        }
    }

    // TODO: enables and disable the throws speed frame checks here.

    // used because buttons OnClick does not allow a static function to be clicked
    #region staticFunctionsWrappers
    public void ThrowAllDiceNotStatic() {
        ThrowAllDice();
    }

    public void resetDiceNotStatic() {
        resetDices();
    }

#endregion


}
