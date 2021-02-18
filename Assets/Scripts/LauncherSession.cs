using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LauncherSession : MonoBehaviour
{
    [SerializeField] private Button _actionButton;
    [SerializeField] private CardStirrer _cardStirerrer;
    [SerializeField] private CardsGenerator _cardsGenerator;
    [SerializeField] private GameData _gameData;
    [SerializeField] private List<Sprite> _listSpriteCards;
    [SerializeField] private List<Transform> _cardsPosition;   

    private CardController _cardController;   

    private void Awake()
    {
        SpriteConverter spriteConverter = new SpriteConverter();
        _cardController = new CardController(_actionButton, _cardsGenerator, _cardStirerrer);
        _cardsGenerator.CardController = _cardController;
        for (int i = 0; i < _gameData.NumberCardsInHand; i++)
        {
            _listSpriteCards.Add(spriteConverter.GetSprite("Assets/Resources/CardImage" + i + ".jpg"));
        }
    }

    private void Start()
    {
        for (int i = 0; i < _gameData.NumberCardsInHand; i++)
        {
            _cardsGenerator.Create(_cardsPosition[i], _gameData.NameCard[i], _listSpriteCards[i]);
        }
    }  
}
