using UnityEngine.UI;

interface ICardParameter
{
    void Init(int value);
    void SetView(Text textElement);
    int GetValue();
    void SetValue(int value);
    void Update();
}
