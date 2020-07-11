using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;

public class PlayerColorSelector : MonoBehaviour
{

    public GameInfo gameInfoManager;
    [SerializeField] private int playerIndex = 1;
    public Texture chosenColorTexture;
    private Dictionary<PLAYER_COLORS, RawImage> playerColorsImages;
    private Button[] buttons;

    private PLAYER_COLORS currenColor;
    void Start()
    {
        // playersColorsImages = new Dictionary<PLAYER_COLORS, RawImage>[4];
        playerColorsImages = new Dictionary<PLAYER_COLORS, RawImage>();
        buttons = this.GetComponentsInChildren<Button>();
        assignListenersToButtonsANDrawImages();
    }

    private void assignListenersToButtonsANDrawImages() {
        for (int i = 0; i < buttons.Length; i++)
        {
            switch(buttons[i].name) {
                case "Red" :
                playerColorsImages[PLAYER_COLORS.RED] = buttons[i].GetComponent<RawImage>();
                buttons[i].onClick.AddListener(() => registerPlayerColor(playerIndex, PLAYER_COLORS.RED));
                break;
                case "Yellow":
                playerColorsImages[PLAYER_COLORS.YELLOW] = buttons[i].GetComponent<RawImage>();
                buttons[i].onClick.AddListener(() => registerPlayerColor(playerIndex, PLAYER_COLORS.YELLOW));
                break;
                case "Blue":
                playerColorsImages[PLAYER_COLORS.BLUE] = buttons[i].GetComponent<RawImage>();
                buttons[i].onClick.AddListener(() => registerPlayerColor(playerIndex, PLAYER_COLORS.BLUE));
                break;
                case "Green":
                playerColorsImages[PLAYER_COLORS.GREEN] = buttons[i].GetComponent<RawImage>();
                buttons[i].onClick.AddListener(() => registerPlayerColor(playerIndex, PLAYER_COLORS.GREEN));
                break;
            }
        }
    }
    public void setCurrentColor(PLAYER_COLORS color) {
        currenColor = color;
    }
    public void registerPlayerColor(int index, PLAYER_COLORS playerColor) {
        // playerStruct.index = (short)index;
        if (!gameInfoManager.ColorIsAlreadyChosen(playerColor)) {
            if (currenColor != PLAYER_COLORS.NONE)
                gameInfoManager.removeColor(currenColor, (short)playerIndex);

            gameInfoManager.selectColor(playerColor, (short)playerIndex);
            setTexture(playerColorsImages[playerColor]);
            currenColor = playerColor;
        } else if(playerColor == currenColor) {
            gameInfoManager.removeColor(currenColor, (short)playerIndex);
            currenColor = PLAYER_COLORS.NONE;
            removeAlltextures();
        }
    }
    public void removeAlltextures() {
        foreach (var pair in playerColorsImages) {
            pair.Value.texture = null;
        }
    }
    private void setTexture(RawImage image) {
        removeAlltextures();
        image.texture = chosenColorTexture;
    }

}
