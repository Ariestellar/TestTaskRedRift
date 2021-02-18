using System.Collections.Generic;
using UnityEngine;

public class CardsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _tempCard;
    
    private CardController _cardController;    
    private List<CardData> _listCards = new List<CardData>();

    public List<CardData> ListCards { get => _listCards; }
    public CardController CardController { set => _cardController = value; }

    public void Create(Transform cardPosition, string nameCard, Sprite logo)
    {
        GameObject newCard = Instantiate(_tempCard, cardPosition);
        CardData cardData = new CardData(nameCard, logo, 5, 5, 5);
        newCard.GetComponent<CardView>().Init(cardData, _cardController);
        _listCards.Add(cardData);
    }
}
