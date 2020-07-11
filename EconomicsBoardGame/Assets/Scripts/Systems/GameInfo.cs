using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Project_Enums;
public class GameInfo : MonoBehaviour
{

    public static short playersNo = 4;
    private int readyPlayers = 0;

    private Dictionary<PLAYER_COLORS, bool> selectedColorsDict;
    public static PLAYER_COLORS[] playersColors;

    public GameObject[] playerPanels = new GameObject[4];

    public GameObject notReadyText;

    // Start is called before the first frame update
    void Start()
    {
        initiateColorsDictionary();
        playersColors = new PLAYER_COLORS[4];
    }

    private void initiateColorsDictionary() {
        selectedColorsDict = new Dictionary<PLAYER_COLORS, bool>();
        selectedColorsDict.Add(PLAYER_COLORS.BLUE, false);
        selectedColorsDict.Add(PLAYER_COLORS.GREEN, false);
        selectedColorsDict.Add(PLAYER_COLORS.RED, false);
        selectedColorsDict.Add(PLAYER_COLORS.YELLOW, false);
    }

    public void selectColor(PLAYER_COLORS color, short index) {
        selectedColorsDict[color] = true;
        playersColors[index] = color;
        readyPlayers++;
        quickDebug();
    }

    public void setPlayersNo(int selectedIndex) {
        playersNo = (short)(selectedIndex + 1);
        // set the panels active
        for (int i = 0; i < playersNo; i++)
        {
            playerPanels[i].SetActive(true);
        }
        removePlayersAndColors(selectedIndex + 1);

    }
    public bool ColorIsAlreadyChosen(PLAYER_COLORS color) {
        // print(selectedColorsDict[color]);
        return selectedColorsDict[color];
    }

    private void removePlayersAndColors(int startIndex) {
        for (int i = startIndex; i < 4; i++)
        {
            playerPanels[i].SetActive(false);
            removeColor(playersColors[i], (short)i);
        }
         for (int i = startIndex; i < 4; i++)
        {
            PlayerColorSelector selector = playerPanels[i].GetComponent<PlayerColorSelector>();
            selector.removeAlltextures();
            selector.setCurrentColor(PLAYER_COLORS.NONE);
        }
        quickDebug();

    }

    private void quickDebug () {
        string total = "";
        for (int i = 0; i < playersColors.Length; i++)
        {
            total += " " + playersColors[i];
        }
        total += "\n + total ready:" + readyPlayers + "\n total players: " + playersNo;
        print(total);
    }
    public void proceedToGame() {
        if (readyPlayers == playersNo) {
            SceneManager.LoadScene(1);
        } else {
            StartCoroutine(EnableObjectForSeconds(notReadyText, 3));
        }
    }
    public void removeColor(PLAYER_COLORS color, short index) {
        print("removing " + color);
        // since PLAYER_COLOR.NONE is not in the dictionary, if the sent color
        // is it, we bail out immediately, knowing it was already Empty
        if (selectedColorsDict.ContainsKey(color) &&  selectedColorsDict[color] == true)
            readyPlayers--;
        playersColors[index] = PLAYER_COLORS.NONE;
        selectedColorsDict[color] = false;
        quickDebug();
    }

    IEnumerator EnableObjectForSeconds(GameObject objectToWait, float seconds) {
        objectToWait.SetActive(true);
        yield return new WaitForSeconds(seconds);
        objectToWait.SetActive(false);
    }


}
