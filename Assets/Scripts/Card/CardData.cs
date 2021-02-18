using UnityEngine;

public class CardData
{
    private int _id;

    private string _name;
    private Sprite _logo;

    private AttackPoint _attack;
    private HealthPoint _healthPoints;
    private ManaPoints _manaPoints;

    public Sprite Logo { get => _logo; }
    public string Name { get => _name; }
    internal AttackPoint Attack { get => _attack; set => _attack = value; }
    internal HealthPoint HealthPoints { get => _healthPoints; set => _healthPoints = value; }
    internal ManaPoints ManaPoints { get => _manaPoints; set => _manaPoints = value; }

    public CardData(string name, Sprite logo, int attak, int HP, int MP)
    {
        _name = name;
        _logo = logo;
        _attack = new AttackPoint();
        _attack.Init(attak);
        _healthPoints = new HealthPoint();
        _healthPoints.Init(HP);
        _manaPoints = new ManaPoints();
        _manaPoints.Init(MP);
    }
}
