using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnboundLib.Cards;
using UnityEngine;

namespace LunarsCards
{
    public class CardHolder : MonoBehaviour
    {
        public List<GameObject> Cards;
        public List<GameObject> HiddenCards;

        internal void RegisterCards()
        {
            foreach (var Card in Cards)
            {
                CustomCard.RegisterUnityCard(Card, LunarsDumbCards.modInitials, Card.GetComponent<CardInfo>().cardName, true, null);
            }
            foreach (var Card in HiddenCards)
            {
                CustomCard.RegisterUnityCard(Card, LunarsDumbCards.modInitials, Card.GetComponent<CardInfo>().cardName, false, null);
                ModdingUtils.Utils.Cards.instance.AddHiddenCard(Card.GetComponent<CardInfo>());
            }
        }
    }
}