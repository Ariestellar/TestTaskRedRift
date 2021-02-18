using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderGame : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private GameData _gameData;

    private LoaderImage _loaderImage;
    private bool _isEndDownload;
    private int _numberUploadedImages;

    private void Start()
    {
        _loaderImage = new LoaderImage();

        _loaderImage.DownloadCompletedSuccessfully += CountNumberUploadedImages;

        for (int i = 0; i < _gameData.NumberCardsInHand; i++)
        {
            StartCoroutine(_loaderImage.Load(GetRandomUrlImage(), "Assets/Resources/CardImage" + i + ".jpg"));
        }

        LoadGameSession();
    }

    private void LoadGameSession()
    {
        StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    { 
        AsyncOperation async = SceneManager.LoadSceneAsync("GameSession");

        while (!async.isDone && !_isEndDownload)
        {
            _bar.value = async.progress;
            yield return null;
        }
    }

    private string GetRandomUrlImage()
    {
        return "https://picsum.photos/seed/" + Random.Range(0, 300) + "/200/300";
    }

    private void CountNumberUploadedImages()
    {
        _numberUploadedImages += 1;
        if (_numberUploadedImages == _gameData.NumberCardsInHand)
        {
            _isEndDownload = true;
        }
    }
}
