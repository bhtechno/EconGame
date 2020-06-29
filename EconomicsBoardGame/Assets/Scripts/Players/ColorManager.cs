using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;

public class ColorManager : MonoBehaviour
{
    public Material[] materialArray;
    public static Dictionary<PLAYER_COLORS, Material> materialsDict;

    // Start is called before the first frame update
    void Awake() {
        materialsDict = new Dictionary<PLAYER_COLORS, Material>();
        assignColorsToDictionary();
    }

    public static void changeMyRendererColor(Renderer renderer, PLAYER_COLORS color) {
        renderer.sharedMaterial = materialsDict[color];
    }


    void assignColorsToDictionary() {
        // materialArray[i].
        for (int i = 0; i < materialArray.Length; i++)
        {
            // print("name = " + materialArray[i].name);
            switch (materialArray[i].name) {
			case "Red":
				materialsDict.Add(PLAYER_COLORS.RED, materialArray[i]);
				break;
			case "Yellow":
				materialsDict.Add(PLAYER_COLORS.YELLOW, materialArray[i]);
				break;
            case "Blue":
				materialsDict.Add(PLAYER_COLORS.BLUE, materialArray[i]);
				break;
            case "Green":
				materialsDict.Add(PLAYER_COLORS.GREEN, materialArray[i]);
				break;
			}
        }
    }

}
