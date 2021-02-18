using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AttackPoint : ICardParameter
{
    private int _value;
    private Transform _positionElement;
    private Text _textElement;
    private bool _isIncrease;

    public int GetValue()
    {
        return _value;
    }

    public void SetValue(int value)
    {
        if (value > _value)
        {
            _isIncrease = true;
        }
        else if (value < _value)
        {
            _isIncrease = false;
        }
        _value = value;
    }

    public void Init(int value)
    {
        _value = value;
    }

    public void SetView(Text textElement)
    {
        _textElement = textElement;
        _positionElement = textElement.GetComponentsInParent<Transform>()[1];
    }

    public void Update()
    {
        if (_isIncrease == true)
        {
            _positionElement.DOScale(new Vector3(2, 2, 2), 2).OnComplete(() => _positionElement.DOScale(new Vector3(1, 1, 1), 2));
        }
        else if (_isIncrease == false)
        {
            _positionElement.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 2).OnComplete(() => _positionElement.DOScale(new Vector3(1, 1, 1), 2));
        }
        _textElement.DOCounter(Convert.ToInt32(_textElement.text), _value, 5);
    }
}
