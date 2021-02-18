using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    [SerializeField] private int _numberCardsInHand;
    [SerializeField] private string[] _nameCard = new string[] { "Буйный Вол Баян", "Пандарен Сам Один", "Выверн", "Гигантский Червь", "Пилладжер" };

    public int NumberCardsInHand { get => _numberCardsInHand;}
    public string[] NameCard { get => _nameCard; }
}
