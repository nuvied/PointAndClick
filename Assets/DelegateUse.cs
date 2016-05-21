using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class DelegateUse : MonoBehaviour
{
    public int sceneIndex;

    public Action OnFinish;

    void OnMouseDown()
    {
        CameraFade.StartAlphaFade(Color.black, false, 1f, OnComplete);
    }

    void OnComplete()
    {
        SceneManager.LoadScene(sceneIndex);
    }



    


}
