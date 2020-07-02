using System.Collections.Generic;

[System.Serializable]
public class CardsList {
    public List<Card> Card = new List<Card>();
}

[System.Serializable]
public class Card
{
    public string cardType;
    public string cardDetails;
    public float value;
    public string playerAffected;
}
