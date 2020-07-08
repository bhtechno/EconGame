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
    [SerializeField] private GameObject playersInfoButtonsParent = default;

    private Button[] playersInfoButtons;

    // Start is called before the first frame update
    void Start()
    {
        players = generalManager.getPlayerArray();
        InitiatePlayersInfoButtons();
        assignButtonsOnClickFunction();
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

    public void showPlayersInfo(short index) {
        print("hello " + index);
    }


}
