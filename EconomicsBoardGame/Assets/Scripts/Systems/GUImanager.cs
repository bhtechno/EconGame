using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;


public class GUImanager : MonoBehaviour
{

    private static Button[] gameButtons; // all buttons in the scene are put here
    private static Dictionary <BUTTON_TYPE, Button> buttonsDict;

    private static RawImage image;

    private void Awake() {
        int buttonsCount = System.Enum.GetNames(typeof(BUTTON_TYPE)).Length;
        gameButtons = GameObject.FindObjectsOfType<Button>();
        buttonsDict = new Dictionary<BUTTON_TYPE, Button>();
        assignButtonsToDictionary();
    }
    void Start()
    {
        image = GameObject.FindObjectOfType<RawImage>();
        if (image == null) {
            print("image is null");
        }
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

    public static void promptTileBuy(AbstractCard locationCard) {
        // show the card, and below it, show buy or skip
        // after clicking on that, remove the display,
        // show the end turn thing.
    }

    public void disableAllButtons() {
        for (int i = 0; i < gameButtons.Length; i++)
        {
            gameButtons[i].enabled = false;
            gameButtons[i].interactable = false;
        }
    }

    public static void showImage(TILE_TYPE tileType) {
        image.texture = CardManager.getTileTexture(tileType);
        image.enabled = true;
    }

    public static void removeImage() {
        image.enabled = false;
    }

}
