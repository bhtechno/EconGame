using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;


public class GUImanager : MonoBehaviour
{

    private static Dictionary <BUTTON_TYPE, Button> buttonsDict;

    [SerializeField] private Button throwButton = default;
    [SerializeField] private Button EndTurnButton = default;
    [SerializeField] private Button buyButton = default;


    private void Awake() {
        int buttonsCount = System.Enum.GetNames(typeof(BUTTON_TYPE)).Length;
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
    void assignButtonsToDictionary() {
        buttonsDict.Add(BUTTON_TYPE.THROW_DICE, throwButton);
        buttonsDict.Add(BUTTON_TYPE.END_TURN, EndTurnButton);
        buttonsDict.Add(BUTTON_TYPE.BUY, buyButton);
    }

    /*
     * Given the button type enum, this button will be disabled and become shadowed
    */


    public static void DisableButton(BUTTON_TYPE buttontype) {
        buttonsDict[buttontype].enabled = false;
        buttonsDict[buttontype].interactable = false;
        buttonsDict[buttontype].gameObject.SetActive(false);

    }

     /*
     * Given the button type enum, this button will be enabled
    */
    public static void EnableButton(BUTTON_TYPE buttontype) {
        buttonsDict[buttontype].enabled = true;
        buttonsDict[buttontype].interactable = true;
        buttonsDict[buttontype].gameObject.SetActive(true);
    }

    public static void promptTileBuy(AbstractCard locationCard) {
        // show the card, and below it, show buy or skip
        // after clicking on that, remove the display,
        // show the end turn thing.
    }

    public void disableAllButtons() {
        IDictionaryEnumerator buttonsDictEnumerator = buttonsDict.GetEnumerator();
        // use enumerrator to disable buttons
        while (buttonsDictEnumerator.MoveNext()) {
            Button current = buttonsDictEnumerator.Value as Button;
            current.enabled = false;
            current.interactable = false;
        }



        // for (int i = 0; i < gameButtons.Length; i++)
        // {
        //     gameButtons[i].enabled = false;
        //     gameButtons[i].interactable = false;
        // }
    }

    public static void showImage(TILE_TYPE tileType, AbstractTile.TileImageInfo cardInfo) {
        CardManager.showImage(tileType, cardInfo);
    }

    public static void removeImage() {
        CardManager.removeImage();
    }

    public static void disableGlowofPlayer(short index) {
        PlayersInfoManager.disableGlowofPlayer(index);
    }
    public static void enableGlowofPlayer(short index) {
        PlayersInfoManager.enableGlowofPlayer(index);
    }
}
