using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;


public class GUImanager : MonoBehaviour
{

    Button[] gameButtons;
    // Start is called before the first frame update
    void Start()
    {
        int buttonsCount = System.Enum.GetNames(typeof(BUTTON_TYPE)).Length;
        // gameButtons = new Button[buttonsCount];
    }

}
