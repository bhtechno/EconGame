using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Project_Enums;
public class GameInfo : MonoBehaviour
{
    public static short playersNo = 2;
    public static PLAYER_COLORS[] playersColors;

    // Start is called before the first frame update
    void Start()
    {
        playersColors = new PLAYER_COLORS[playersNo];
        playersColors[0] = PLAYER_COLORS.BLUE;
        playersColors[1] = PLAYER_COLORS.GREEN;
        SceneManager.LoadScene(1);
    }
}
