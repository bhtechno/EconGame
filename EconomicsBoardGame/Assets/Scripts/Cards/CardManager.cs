using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Project_Enums;


public class CardManager : MonoBehaviour
{
    public CardsList cards = new CardsList();
    private static Dictionary <TILE_TYPE, Texture> tilesCardsBackgrounds;
    private static RawImage image;
    public RawImage nonStaticImage;

    private static TextMeshProUGUI tileNameStatic;
    private static TextMeshProUGUI tileCostStatic;
    private static TextMeshProUGUI tileRentStatic;
    private static TextMeshProUGUI tileTypeTextStatic;

    [SerializeField] TextMeshProUGUI tileName = default;
    [SerializeField] TextMeshProUGUI tileCost = default;
    [SerializeField] TextMeshProUGUI tileRent = default;
    [SerializeField] TextMeshProUGUI tileTypeText = default;

    void Start()
    {
        AssignStaticVars();
        loadJsonCards();
        loadtilesCardsToDictionary();
    }

    void loadtilesCardsToDictionary() {
    tilesCardsBackgrounds = new Dictionary<TILE_TYPE, Texture>();
    // public enum TILE_TYPE {FREE, BUSSINESS, RESIDENCE, INNOVATIVE, VALUE, FARM, OTHER};

        tilesCardsBackgrounds.Add(TILE_TYPE.FREE, Resources.Load<Texture>("FreeInfo"));
        tilesCardsBackgrounds.Add(TILE_TYPE.BUSSINESS,Resources.Load<Texture>("BusinessInfo"));
        tilesCardsBackgrounds.Add(TILE_TYPE.RESIDENCE, Resources.Load<Texture>("ResidencyInfo"));
        tilesCardsBackgrounds.Add(TILE_TYPE.INNOVATIVE, Resources.Load<Texture>("InnovativeInfo"));
        tilesCardsBackgrounds.Add(TILE_TYPE.VALUE,Resources.Load<Texture>("ValueInfo"));
        tilesCardsBackgrounds.Add(TILE_TYPE.FARM,Resources.Load<Texture>("FarmInfo"));
        tilesCardsBackgrounds.Add(TILE_TYPE.OTHER,Resources.Load<Texture>("OtherInfo"));
        if (tilesCardsBackgrounds.Count == 0 || tilesCardsBackgrounds[TILE_TYPE.FREE] == null) {
            print("ISSUE WITH LOADING!!");
        }

    }
    private void AssignStaticVars() {
        image = nonStaticImage;
        tileNameStatic = tileName;
        tileCostStatic = tileCost;
        tileRentStatic = tileRent;
        tileTypeTextStatic = tileTypeText;
    }

    public static Texture getTileTexture(TILE_TYPE tileType) {
        return tilesCardsBackgrounds[tileType];
    }

    public static void showImage(TILE_TYPE tileType, AbstractTile.TileImageInfo cardInfo) {
        setCardInfo(tileType, cardInfo);
        image.gameObject.SetActive(true);
        image.texture = getTileTexture(tileType);
    }

    static void setCardInfo(TILE_TYPE tileType, AbstractTile.TileImageInfo cardInfo) {
        tileNameStatic.text = cardInfo.getName();
        tileCostStatic.text = cardInfo.getCost().ToString();
        tileRentStatic.text = cardInfo.getRent().ToString();
        switch (tileType) {
			case TILE_TYPE.BUSSINESS:
				tileTypeTextStatic.text = "BUSSINESS";
				break;
			case TILE_TYPE.EMPTY:
				tileTypeTextStatic.text = "EMPTY";
				break;
			case TILE_TYPE.FACTORY:
				tileTypeTextStatic.text = "FACTORY";
				break;
			case TILE_TYPE.FARM:
				tileTypeTextStatic.text = "FARM";
				break;
			case TILE_TYPE.FREE:
				tileTypeTextStatic.text = "FREE";
				break;
			case TILE_TYPE.INNOVATIVE:
				tileTypeTextStatic.text = "INNOVATIVE";
				break;
            case TILE_TYPE.OTHER:
                tileTypeTextStatic.text = "SPECIAL";
                break;
            case TILE_TYPE.RESIDENCE:
                tileTypeTextStatic.text = "RESIDENCE";
                break;
            case TILE_TYPE.VALUE:
                tileTypeTextStatic.text = "VALUE BUSSINESS";
                break;
		}

    }

    public static void removeImage() {
        image.gameObject.SetActive(false);
        // image.enabled = false;
    }

    void loadJsonCards() {
        TextAsset jsonFileAsset = Resources.Load("CardsData") as TextAsset;
        if (jsonFileAsset != null) {
            cards = JsonUtility.FromJson<CardsList>(jsonFileAsset.text);
            foreach (AbstractCard card in cards.Card)
            {
                print(card.cardDetails);
                print(card.cardType);
                print(card.playerAffected);
                print(card.value);
            }
        } else {
            print("Asset is null!");
        }
    }

}
