using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void OnplayButtonClicked()
    {
        SceneManager.LoadScene("PrototypeScenes");
    }
}
