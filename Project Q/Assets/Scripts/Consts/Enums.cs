/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/
using UnityEngine;
namespace Consts
{
    /// <summary>
    /// UI层级
    /// </summary>
    public enum UILayer
    {
        BASIC_UI,
        OVERLAY_UI,
        TOP_UI
    }
    /// <summary>
    /// UI运行状态
    /// </summary>
    public enum UIState
    {
        NORMAL,
        INIT,
        SHOW,
        HIDE,
    }
    /// <summary>
    /// 一个UIID对应着一个预制体
    /// </summary>
    public enum UIID
    {
        None,
        MainMenu,
        StartGame
    }

    public enum UIEffect
    {
        VIEW_EFFECT,
        OTHERS_EFFECT,
    }
}