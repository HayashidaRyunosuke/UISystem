using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomPanel : MonoBehaviour
{
    /// <summary>
    /// フェードインが終わるまでにかかる時間
    /// </summary>
    public float fadeInDuration = 0.5f;

    /// <summary>
    /// フェードアウトが終わるまでにかかる時間
    /// </summary>
    public float fadeOutDuration = 0.5f;

    /// <summary>
    /// フェードイン後に自動的にフェードアウトさせるか
    /// </summary>
    public bool fadeOutAuto = false;

    /// <summary>
    /// 自動的にフェードアウトさせるまでの待機時間
    /// </summary>
    public float waitTime = 0f;

    void Awake()
    {
        gameObject.SetActive(false);
    }
    
}
