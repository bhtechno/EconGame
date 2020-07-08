using System.Collections.Generic;
// using UnityEditor.UI;

[System.Serializable]
public class CardsList {
    public List<AbstractCard> Card = new List<AbstractCard>();
}

[System.Serializable]
public abstract class AbstractCard
{
    public string cardType;
    public string cardDetails;
    public float value;
    public string playerAffected;

}
