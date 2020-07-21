using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Project_Enums;

public class JobSelector : MonoBehaviour
{
    [SerializeField] public GeneralManager generalManager = default;
    [SerializeField] public GameObject playerInfoButtonPrefab = default;
    [SerializeField] GameObject buttonsParent = default;
    [SerializeField] JobPanel softwarePanel = default;
    [SerializeField] JobPanel graphicsPanel = default;
    [SerializeField] JobPanel importerPanel = default;
    [SerializeField] JobPanel superMarketPanel = default;
    [SerializeField] JobPanel accountinPanel = default;
    private Dictionary<JOB_SELECTION, JobPanel> panelsDict;
    private JOB_SELECTION[] jobSelectionsInternal; // used internally for graphics
    // used to store the final selections, and return them to general manager
    short readyPlayers = 0;
    GameObject[] playerButtonsObjects;
    private static RawImage[] buttonsGlowImages;

    short currentPlayer = 0;
    private void Awake() {
        initializeInternalJobsArray();
        initiateDictionary();
        instaniatePlayerButtons();
        initializeButtonsGlowImage();
    }
    // Start is called before the first frame update
    void Start()
    {
        assignPanelsOnClicktoButtons();
    }
    private void initializeInternalJobsArray() {
        jobSelectionsInternal = new JOB_SELECTION[GameInfo.playersNo];
        for (int i = 0; i < jobSelectionsInternal.Length; i++)
        {
            jobSelectionsInternal[i] = JOB_SELECTION.NONE;
        }
    }
    private void initializeButtonsGlowImage() {
        buttonsGlowImages = new RawImage[playerButtonsObjects.Length];
        // Get the rawImageGloe component of each player's Button
        for (int i = 0; i < playerButtonsObjects.Length; i++)
        {
            buttonsGlowImages[i] = playerButtonsObjects[i].GetComponentInChildren<RawImage>();
        }
    }
    private void initiateDictionary() {
        panelsDict = new Dictionary<JOB_SELECTION, JobPanel>();
        panelsDict.Add(JOB_SELECTION.SOFTWARE, softwarePanel);
        panelsDict.Add(JOB_SELECTION.ACCOUNTING, accountinPanel);
        panelsDict.Add(JOB_SELECTION.GRAPHICS, graphicsPanel);
        panelsDict.Add(JOB_SELECTION.IMPORTER, importerPanel);
        panelsDict.Add(JOB_SELECTION.SUPERMARKET, superMarketPanel);

    }
    private void instaniatePlayerButtons() {
        playerButtonsObjects = new GameObject[GameInfo.playersNo];
         for (int i = 0; i < GameInfo.playersNo; i++) {
            GameObject button = Instantiate(playerInfoButtonPrefab, buttonsParent.transform);
            playerButtonsObjects[i] = button;
            button.name = i.ToString();
            button.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            assignPlayersOnClickToButton(button, (short)i);
         }
    }

    // public void assignPlayerJob(int playerIndex, JobPanel.JobInformation jobInfo) {
    //     playersJobs[playerIndex] = jobInfo;
    // }

    private void assignPlayersOnClickToButton(GameObject buttonGameObject, short index) {
        Button button = buttonGameObject.GetComponent<Button>();
        button.onClick.AddListener(() => {
            currentPlayer = index;
            showPlayerSelections(index);
            removeAllGlows();
            enableGlowofPlayer(index);
        });

        // button.onClick.AddListener( delegate {
        //     currentPlayer = index;
        // });
        // button.onClick.AddListener(() => {
        //     showPlayerSelections(index);
        // });
        // button.onClick.AddListener(() => {
        //     removeAllGlows();
        // });
        // button.onClick.AddListener(() => {
        //     enableGlowofPlayer(index);
        // });

    }

    private void assignPanelsOnClicktoButtons() {
         foreach(KeyValuePair<JOB_SELECTION, JobPanel> entry in panelsDict)
        {
            entry.Value.getPanelButton().onClick.AddListener(() => {
                // might be a problem, since the button is private
                // and actually in JobPanelGUI
                selectPanel(entry.Value.getPanelEnumType());
            });
        }
    }

    public void selectPanel(JOB_SELECTION typeEnum) {
        if (jobSelectionsInternal[currentPlayer] ==  JOB_SELECTION.NONE) {
            // allow player to immediately select
            jobSelectionsInternal[currentPlayer] = typeEnum;
            panelsDict[typeEnum].setIsSelected(true);
            readyPlayers++;
        } else {
            // change the player's selection
            foreach(KeyValuePair<JOB_SELECTION, JobPanel> entry in panelsDict)
            {
                entry.Value.setIsSelected(false);
            }
            jobSelectionsInternal[currentPlayer] = typeEnum;
            panelsDict[typeEnum].setIsSelected(true);
        }
    }
    /*
     * remove the yellow background from all jobs, and then, if the player
     * has a selection, show it.
    */
    private void showPlayerSelections(short index) {
        foreach(KeyValuePair<JOB_SELECTION, JobPanel> entry in panelsDict)
        {
            entry.Value.setIsSelected(false);
        }
        if (jobSelectionsInternal[index] != JOB_SELECTION.NONE) {
            panelsDict[jobSelectionsInternal[index]].setIsSelected(true);
        }
    }

    public void startGame() {
        if (readyPlayers == GameInfo.playersNo) {
            JobPanel.JobInformation[] playersJobs;
            playersJobs = new JobPanel.JobInformation[GameInfo.playersNo];
            // set the business struct to each player
            for (int i = 0; i < GameInfo.playersNo; i++)
            {
                playersJobs[i] = panelsDict[jobSelectionsInternal[i]].getJobInformation();
            }
            generalManager.setPlayersJobs(playersJobs);
            generalManager.enableInitialGUIandStart();
            this.gameObject.SetActive(false);
            // proceed to game
        } else {
            // not all players selected a business
            // StartCoroutine(EnableObjectForSeconds(notReadyText, 3));
        }
    }

    private static void removeAllGlows() {
        for (int i = 0; i < GameInfo.playersNo; i++)
        {
            disableGlowofPlayer((short)i);
        }
    }

     private static void disableGlowofPlayer(short index) {
        buttonsGlowImages[index].enabled = false;
    }
    private static void enableGlowofPlayer(short index) {
        buttonsGlowImages[index].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
