using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UIManagerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    
    #region Singlton

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T) FindObjectOfType(typeof(T));
            }

            return instance;
        }
    }

    #endregion
    
    [SerializeField]
    protected List<UICustomPanel> panels;
    protected int curPanelIndex = -1;

    protected bool isFade = false;

    protected Coroutine fadeInCoroutine;

    protected Coroutine fadeOutCoroutine;

    private CanvasGroup _canvasGroup;
    protected CanvasGroup CGroup
    {
        get
        {
            if (!_canvasGroup)
                _canvasGroup = GetComponent<CanvasGroup>();
            return _canvasGroup;
        }
    }

    void Awake()
    {
        CGroup.alpha = 0;
    }
    
    /// <summary>
    /// 引数で指定したUIを表示させる
    /// 現在表示されているUIがある場合はフェードアウト後に表示される
    /// </summary>
    /// <param name="index">UIインデックス</param>
    public void ShowUI(int index)
    {
        if (index >= panels.Count || index < 0)
            return;
        
        FadeInPanel(index);
    }

    /// <summary>
    /// 現在表示されているUIをフェードアウトさせる
    /// </summary>
    public void HideUI()
    {
        FadeOutPanel();
    }
    
    private void FadeInPanel(int panelIndex)
    {
        if (isFade)
            return;

        if (curPanelIndex != -1)
        {
            fadeInCoroutine = StartCoroutine(FadeOut(panels[curPanelIndex],panels[panelIndex]));
            curPanelIndex = panelIndex;
        }
        else
        {
            curPanelIndex = panelIndex;
            fadeInCoroutine = StartCoroutine(FadeIn(panels[curPanelIndex]));
        }
    }
    
    private void FadeOutPanel()
    {
        if (isFade)
            return;

        if (curPanelIndex == -1)
            return;
        
        fadeOutCoroutine = StartCoroutine(FadeOut(panels[curPanelIndex]));
    }

    /// <summary>
    /// パネルをフェードインさせる
    /// </summary>
    /// <param name="customPanel">フェードインさせるパネル</param>
    /// <returns></returns>
    private IEnumerator FadeIn(UICustomPanel customPanel)
    {
        isFade = true;
        CGroup.alpha = 0;
       customPanel.gameObject.SetActive(true);
       while (true)
        {
            CGroup.alpha += (1 * Time.deltaTime) / customPanel.fadeInDuration;
            if (CGroup.alpha >= 1)
            {
                CGroup.alpha = 1;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        if (customPanel.fadeOutAuto)
        {
            yield return new WaitForSeconds(customPanel.waitTime);
            StartCoroutine(FadeOut(customPanel));
        }
        else
        {
            isFade = false;
        }
    }
    
    /// <summary>
    /// パネルをフェードアウトさせる
    /// 第二引数を受け取った場合は第一引数のパネルをフェードアウトさせた後に第二引数のパネルをフェードインさせる
    /// </summary>
    /// <param name="customPanel">フェードアウトさせるパネル</param>
    /// <param name="nextCustomPanel">次にフェードインさせるパネル</param>
    /// <returns></returns>
    private IEnumerator FadeOut(UICustomPanel customPanel,UICustomPanel nextCustomPanel = null)
    {
        isFade = true;
        CGroup.alpha = 1;
        while (true)
        {
            CGroup.alpha -= (1 * Time.deltaTime) / customPanel.fadeOutDuration;
            if (CGroup.alpha <= 0)
            {
                CGroup.alpha = 0;
                customPanel.gameObject.SetActive(false);
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        if (nextCustomPanel != null)
        {
            StartCoroutine(FadeIn(nextCustomPanel));
        }
        else
        {
            isFade = false;
            curPanelIndex = -1;
        }
    }

    
}
