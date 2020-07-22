using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobPanelGUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title = default;
    [SerializeField] TextMeshProUGUI intial1 = default;
    [SerializeField] TextMeshProUGUI growth1 = default;
    [SerializeField] TextMeshProUGUI intial2 = default;
    [SerializeField] TextMeshProUGUI growth2 = default;
    [SerializeField] TextMeshProUGUI current1 = default;
    [SerializeField] TextMeshProUGUI current2 = default;
    private RawImage yellowBackImage = default;
    private Button panelButon;

    public Button getPanelButton() {
        return panelButon;
    }
    public void initializeCard(string title, float intial1, float initial2,float growth1, float growth2,
                                float current1, float current2, RawImage yellowBackImage) {
        this.title.text = title;
        this.intial1.text = intial1.ToString();
        this.intial2.text = initial2.ToString();
        this.growth1.text = growth1.ToString() + "%";
        this.growth2.text = growth2.ToString() + "%";
        this.current1.text = current1.ToString();
        this.current2.text = current2.ToString();
        this.yellowBackImage = yellowBackImage;
        panelButon = this.GetComponent<Button>();
    }

    public void setCurrent(float current1, float current2) {
        this.current1.text = current1.ToString();
        this.current2.text = current2.ToString();
    }

    public void setGrowthRates(float growth1, float growth2) {
        this.growth1.text = growth1.ToString() + "%";
        this.growth2.text = growth2.ToString() + "%";
    }

    /*
     * If true, the yellow background(border) will be opaque
     * if false, it will be set to fully transparent
     */
    public void setIsSelected(bool status) {
        float r = yellowBackImage.color.r;
        float g = yellowBackImage.color.g;
        float b = yellowBackImage.color.b;
        Color newColor;
        if (status) {
            float a = 1f;
            newColor = new Color(r, g, b, a);
        } else {
            float a = 0f;
            newColor = new Color(r, g, b, a);
        }
        yellowBackImage.color = newColor;
    }
}
