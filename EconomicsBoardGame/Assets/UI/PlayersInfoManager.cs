using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayersInfoManager : MonoBehaviour
{
    public GeneralManager generalManager;
    [SerializeField] Player[] players;

    [SerializeField] public GameObject playerInfoButtonPrefab = default;
    [SerializeField] public GameObject playerOwnedLandsSlotsPrefab = default;
    [SerializeField] private GameObject fullInfoPanel = default;
    [SerializeField] private GameObject playersInfoButtonsParent = default;
    [SerializeField] private GameObject playersOwnedLandsSlotsParent = default;
    [SerializeField] private GameObject moneyGameObject = default;
    [SerializeField] private GameObject ValueGameObject = default;

    private static Button[] playersInfoButtons;
    private static RawImage[] PlayersGlowImage;

    // Start is called before the first frame update
    void Start()
    {
        players = generalManager.getPlayerArray();
        InitiatePlayersInfoButtons();
        assignButtonsOnClickFunction();
        destroyOwnedLandsSlots();
    }

    /*
     * Will assign an index coresponding to each player's button. It will also fill
     * the playersInfoButtons array, assign each button with a name of the player's index
     * which is to be used later for onCLick assignment.
     */
    public void InitiatePlayersInfoButtons() {
        // instaniate as many buttons as players
        for (int i = 0; i < players.Length; i++)
            Instantiate(playerInfoButtonPrefab, playersInfoButtonsParent.transform);

        // get the created buttons as gameobjects, and put in the temprory array
        GameObject[] playersButtonsObject;
        playersButtonsObject = new GameObject[players.Length];
        for (int i = 0; i < playersInfoButtonsParent.transform.childCount; i++)
            playersButtonsObject[i] = playersInfoButtonsParent.transform.GetChild(i).gameObject;


        assignPlayerNumberstoButtons(playersButtonsObject);
        // get the button component of each "Button object" and assign it to the array
        // this will be used later to assign OnClick functions
        // also make its name the index of the corresponding player
        playersInfoButtons = new Button[playersButtonsObject.Length];
        for (int i = 0; i < playersInfoButtons.Length; i++) {
            playersInfoButtons[i] = playersButtonsObject[i].GetComponent<Button>();
            playersInfoButtons[i].name = i.ToString();
        }
        PlayersGlowImage = new RawImage[playersButtonsObject.Length];
        // Get the rawImageGloe component of each player's Button
        for (int i = 0; i < playersButtonsObject.Length; i++)
        {
            PlayersGlowImage[i] = playersButtonsObject[i].GetComponentInChildren<RawImage>();
        }

    }

    private void initiatePlayerTileSlots() {
        // create the actiual slots


    }

    private void assignButtonsOnClickFunction() {

        foreach (Button buttton in playersInfoButtons)
        {
            buttton.onClick.AddListener(() => {
                showPlayersInfo(Int16.Parse(buttton.name) );
            });
        }
    }

    /*
     * Given an array of the ButtonObjects, function will find the Text child, and
     * the text component, and then assign it an index
     */
    private void assignPlayerNumberstoButtons(GameObject[] parentButtontoText) {
        TextMeshProUGUI current = default;
        for (int i = 0; i < parentButtontoText.Length; i++)
        {
            current = parentButtontoText[i].GetComponentInChildren<TextMeshProUGUI>();
            current.text = (i + 1).ToString();
        }
    }

    public static void disableGlowofPlayer(short index) {
        PlayersGlowImage[index].enabled = false;
    }
    public static void enableGlowofPlayer(short index) {
        PlayersGlowImage[index].enabled = true;
    }


    private void fillPlayersOwnedLandSlots(short playerIndex) {
         // istantiate as many slots as the player has lands
         List<AbstractTile> playerTiles = players[playerIndex].getOwnedLands();
         print("tile no = " + playerTiles.Count);
         for (int i = 0; i < playerTiles.Count; i++) {
            if(Instantiate(playerOwnedLandsSlotsPrefab, playersOwnedLandsSlotsParent.transform) == null)
                print("NULL!");

         }

        // get the full slot prefab as a gameobject
        GameObject[] playersLandsSlots;
        playersLandsSlots = new GameObject[playerTiles.Count];
        for (int i = 0; i < playersOwnedLandsSlotsParent.transform.childCount; i++)
            playersLandsSlots[i] = playersOwnedLandsSlotsParent.transform.GetChild(i).gameObject;

        // Get the TextMeshPro component of each player's Button
        TextMeshProUGUI[] slotsTexts = new TextMeshProUGUI[playerTiles.Count];
        for (int i = 0; i < playerTiles.Count; i++)
        {
            slotsTexts[i] = playersLandsSlots[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        // Fill each text component with the names of the slots
        for (int i = 0; i < playerTiles.Count; i++)
        {
            slotsTexts[i].text = playerTiles[i].getTileName();
        }
    }

    private void updatePlayerMoney(short index) {
        moneyGameObject.GetComponent<TextMeshProUGUI>().text = players[index].getMoneyBalance().ToString();
        ValueGameObject.GetComponent<TextMeshProUGUI>().text = players[index].getValueBalance().ToString();
    }

    private void destroyOwnedLandsSlots() {
        for (int i = 0; i < playersOwnedLandsSlotsParent.transform.childCount; i++)
        {
            GameObject.Destroy( playersOwnedLandsSlotsParent.transform.GetChild(i).gameObject);
        }
    }


    public void showPlayersInfo(short index) {
        if (fullInfoPanel.activeSelf) {
            destroyOwnedLandsSlots();
            fullInfoPanel.SetActive(false);
        } else {
            fullInfoPanel.SetActive(true);
            updatePlayerMoney(index);
            fillPlayersOwnedLandSlots(index);
        }
        // print("hello " + index);
    }
}
