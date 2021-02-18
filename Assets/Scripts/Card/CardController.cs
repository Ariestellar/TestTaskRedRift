using System;
using UnityEngine.UI;

public class CardController 
{
    private CardsGenerator _cardsGenerator;
    private CardStirrer _cardStirrer;
    private Action<ICardParameter> _changingCardValues;
    private int _indexCard;
    private bool OnCompleted = true;

    internal Action<ICardParameter> ChangingCardValues { get => _changingCardValues; set => _changingCardValues = value; }

    public CardController(Button buttonAction, CardsGenerator cardsGenerator, CardStirrer cardStirrer)
    {
        _cardStirrer = cardStirrer;
        _cardsGenerator = cardsGenerator;
        buttonAction.onClick.AddListener(RandomEventGeneration);
    }    

    private void RandomEventGeneration()
    {
        if (_indexCard == _cardsGenerator.ListCards.Count)
        {
            _indexCard = 0;
        }

        if (OnCompleted)
        {
            _cardStirrer.SlideCardForward(_indexCard + 1);
            ICardParameter cardParameter = null;
            int randomParameter = UnityEngine.Random.Range(0, 3);
            switch (randomParameter)
            {
                case 0:
                    cardParameter = _cardsGenerator.ListCards[_indexCard].Attack;
                    break;
                case 1:
                    cardParameter = _cardsGenerator.ListCards[_indexCard].HealthPoints;
                    break;
                case 2:
                    cardParameter = _cardsGenerator.ListCards[_indexCard].ManaPoints;
                    break;
            }
            cardParameter.SetValue(UnityEngine.Random.Range(-2, 9));
            ChangingCardValues?.Invoke(cardParameter);
            _indexCard += 1;
        }

        OnCompleted = _cardStirrer.OnCompleted;
    }
}
