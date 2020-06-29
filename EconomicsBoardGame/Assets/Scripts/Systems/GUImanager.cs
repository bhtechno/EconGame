using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;


public class GUImanager : MonoBehaviour
{

    private static Button[] gameButtons; // all buttons in the scene are put here
    private static Dictionary <BUTTON_TYPE, Button> buttonsDict;
    // List
    // Start is called before the first frame update

    private void Awake() {
        int buttonsCount = System.Enum.GetNames(typeof(BUTTON_TYPE)).Length;
        gameButtons = GameObject.FindObjectsOfType<Button>();
        buttonsDict = new Dictionary<BUTTON_TYPE, Button>();
        assignButtonsToDictionary();
    }
    void Start()
    {

    }

    /*
     * After saving the buttons in the array, this function will assign them to the
     * dictionary for ease of access using enums.
    */
    static void assignButtonsToDictionary() {
        for (int i = 0; i < gameButtons.Length; i++)
        {
            print("name = " + gameButtons[i].name);
            switch (gameButtons[i].name) {
			case "ButtonThrow":
				buttonsDict.Add(BUTTON_TYPE.THROW_DICE, gameButtons[i]);
				break;
			case "ButtonEndTurn":
				buttonsDict.Add(BUTTON_TYPE.END_TURN, gameButtons[i]);
				break;
			}
        }
        print("size = " + buttonsDict.Count);
    }

    /*
     * Given the button type enum, this button will be disabled and become shadowed
    */
    public static void DisableButton(BUTTON_TYPE buttontype) {
        buttonsDict[buttontype].enabled = false;
        buttonsDict[buttontype].interactable = false;
    }

     /*
     * Given the button type enum, this button will be enabled
    */
    public static void EnableButton(BUTTON_TYPE buttontype) {
        buttonsDict[buttontype].enabled = true;
        buttonsDict[buttontype].interactable = true;
    }

}
