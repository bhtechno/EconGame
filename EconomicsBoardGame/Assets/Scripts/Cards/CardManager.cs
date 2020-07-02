using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardsList cards = new CardsList();
    void Start()
    {
        print("Started!");
        TextAsset jsonFileAsset = Resources.Load("CardsData") as TextAsset;
        if (jsonFileAsset != null) {
            cards = JsonUtility.FromJson<CardsList>(jsonFileAsset.text);
            foreach (Card card in cards.Card)
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
