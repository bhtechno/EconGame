using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project_Enums;

public class JobPanel : MonoBehaviour
{
    /*
     * NOTE: ENSURE TO UPDATE BOTH GUI AND STRUCT WHEN ANY CHAGES ARE MADE
    */
    public struct JobInformation {
        public string title;
        public float initial1; // initial income of currency 1
        public float initial2; // initial income of currency 2
        public float growth1; // growth rate(%) of currency 1
        public float growth2; // growth rate(%) of currency 2
        public float current1;  // current income of currency 1
        public float current2;  // current income of currency 2
        public JOB_SELECTION jobTypeEnum;
        public void initialize(string title, float intial1, float initial2,float growth1, float growth2,
                                float current1, float current2, JOB_SELECTION jobTypeEnum) {
            this.title = title;
            this.initial1 = intial1;
            this.initial2 = initial2;
            this.growth1 = growth1;
            this.growth2 = growth2;
            this.current1 = current1;
            this.initial2 = current2;
            this.jobTypeEnum = jobTypeEnum;
        }
    }

    public bool isSelected = false;
    private RawImage yellowBackImage = default;
    [SerializeField] JobPanelGUI gUI = default;
    [SerializeField] string title = default;
    [SerializeField] JOB_SELECTION jobTypeEnum = default;
    [SerializeField] float initialCurrency1Profit = 2500;
    [SerializeField] float initialCurrency2Profit = 2500;
    [SerializeField] float Currency1GrowthRate = 1.5f;
    [SerializeField] float Currency2GrowthRate = 1.5f;
    private float currentCurreny1Profit;
    private float currentCurrency2Profit;
    private JobInformation jobStruct;
    private Button panelButton = default;
    private enum TEXT_FIELD {INITIAL1, INITIAL2, GROWTH1, GROWTH2, CURRENT1, CURRENT2};
    private void Awake() {
        currentCurreny1Profit = initialCurrency1Profit;
        currentCurrency2Profit = initialCurrency2Profit;
        yellowBackImage = this.GetComponent<RawImage>();
        gUI.initializeCard(title, initialCurrency1Profit, initialCurrency2Profit, Currency1GrowthRate,
                            Currency2GrowthRate, currentCurreny1Profit,
                            currentCurrency2Profit, yellowBackImage);
        jobStruct = new JobInformation();
        jobStruct.initialize(title, initialCurrency1Profit, initialCurrency2Profit, Currency1GrowthRate,
                            Currency2GrowthRate, currentCurreny1Profit,
                            currentCurrency2Profit, jobTypeEnum);
        panelButton = gUI.getPanelButton();
    }
    public JobInformation getJobInformation() {
        return jobStruct;
    }
    public void setIsSelected(bool status) {
        gUI.setIsSelected(status);
    }
    public Button getPanelButton() {
        return panelButton;
    }
    public JOB_SELECTION getPanelEnumType() {
        return jobTypeEnum;
    }

    /*
     * NOTE: ENSURE TO UPDATE BOTH GUI AND STRUCT WHEN ANY CHAGES ARE MADE
    */
}
