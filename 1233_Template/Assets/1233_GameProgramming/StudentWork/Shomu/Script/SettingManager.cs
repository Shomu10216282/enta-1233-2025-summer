using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;

    public void OpenSettings()
    {
        settingUI.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        settingUI.SetActive(false);
    }
}
