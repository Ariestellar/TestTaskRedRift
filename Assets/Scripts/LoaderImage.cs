using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LoaderImage
{
    private Action _downloadCompletedSuccessfully;

    public Action DownloadCompletedSuccessfully { get => _downloadCompletedSuccessfully; set => _downloadCompletedSuccessfully = value; }

    public IEnumerator Load(string resourcePath, string loadingPath)
    {
        UnityWebRequest www = UnityWebRequest.Get(resourcePath);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Ошибка загрузки");
        }
        else
        {
            byte[] results = www.downloadHandler.data;
            File.WriteAllBytes(loadingPath, results);
            _downloadCompletedSuccessfully?.Invoke();
        }
    }    
}
