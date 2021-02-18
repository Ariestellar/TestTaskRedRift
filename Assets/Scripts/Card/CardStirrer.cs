using UnityEngine;
using DG.Tweening;

public class CardStirrer : MonoBehaviour
{
    [Range(1,10)][SerializeField] private int numberSecondsForWhichCardIsDrawn;
    private Transform[] _positionCards;
    private bool _onCompleted;

    public bool OnCompleted { get => _onCompleted;}

    private void Awake()
    {
        _positionCards = GetComponentsInChildren<Transform>();
    }

    public void SlideCardForward(int indexCard)
    {
        _onCompleted = false;
        int tempIndexCard = _positionCards[indexCard].GetSiblingIndex();
        Vector3 tempPosition = _positionCards[indexCard].localPosition;
        Vector3 tempRotation = _positionCards[indexCard].rotation.eulerAngles;

        _positionCards[indexCard].SetAsLastSibling();
        _positionCards[indexCard].DOLocalMove(new Vector3(0, 0, 0), numberSecondsForWhichCardIsDrawn/2);
        _positionCards[indexCard].DORotate(new Vector3(0, 0, 0), numberSecondsForWhichCardIsDrawn/2).OnComplete(() => ReturnCardToPlace(indexCard, tempIndexCard, tempPosition, tempRotation));        
    }

    private void ReturnCardToPlace(int indexCard, int tempSiblingIndexCard, Vector3 tempPosition, Vector3 tempRotation)
    {
        _positionCards[indexCard].DOLocalMove(tempPosition, numberSecondsForWhichCardIsDrawn / 2);
        _positionCards[indexCard].DORotate(tempRotation, numberSecondsForWhichCardIsDrawn / 2).OnComplete(()=> EndAnimation(indexCard, tempSiblingIndexCard));
        
    }

    private void EndAnimation(int indexCard, int tempSiblingIndexCard)
    {
        _onCompleted = true;
        _positionCards[indexCard].SetSiblingIndex(tempSiblingIndexCard);
    }
}
