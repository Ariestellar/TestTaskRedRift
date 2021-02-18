using System;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _name;
    [SerializeField] private Text _attak;
    [SerializeField] private Text _hp;
    [SerializeField] private Text _mp;
    private CardData _cardData;       

    public void Init(CardData cardData, CardController cardController)
    {
        _cardData = cardData;
        _image.sprite = _cardData.Logo;
        _name.text = _cardData.Name;
        cardData.Attack.SetView(_attak);
        cardData.HealthPoints.SetView(_hp);
        cardData.ManaPoints.SetView(_mp);        
        cardController.ChangingCardValues += UpdateView;        
    }

    private void UpdateView(ICardParameter cardParameter)
    {
        cardParameter.Update();
    }
}
