using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerDebugger : MonoBehaviour
{


    [SerializeField]
    private UIManager _uiManager;

    void Update()
    {
        int panelIndex = -1;
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            panelIndex = 9;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            panelIndex = 8;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            panelIndex = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            panelIndex = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            panelIndex = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            panelIndex = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            panelIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            panelIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            panelIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            panelIndex = 0;
        }

        if (panelIndex != -1)
        {
            _uiManager.ShowUI(panelIndex);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            _uiManager.HideUI();
        }
    }
    
}
