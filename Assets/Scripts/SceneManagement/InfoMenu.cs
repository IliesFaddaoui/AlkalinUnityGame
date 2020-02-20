using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    public GameObject infoPanel;
    public void OpenInfoMenu()
    {
        infoPanel.SetActive(true);
    }
    public void closeInfoMenu()
    {
        infoPanel.SetActive(false);
    }
}
