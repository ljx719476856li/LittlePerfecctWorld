/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/

using System;
using Consts;
using UnityEngine;
namespace UIFrame
{
    public abstract class UIBase : MonoBehaviour 	
    {
        public UILayer Layer { get; protected set; }
        public UIID ID { get; protected set; }
        private UIState _state = UIState.NORMAL;
        public UIState State
        {
            get { return _state;}
            set{HandleUIState(value);}
        }
        
        private void HandleUIState(UIState value)
        {
            switch (value)
            {
                case UIState.INIT:
                    if (value == UIState.NORMAL)
                    {
                        Init();
                    }
                    break;
                case UIState.SHOW:
                    if (value != UIState.NORMAL)
                    {
                        Show();
                    }
                    else
                    {
                        Init();
                        Show();
                    }
                    break;
                case UIState.HIDE:
                    Hide();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        protected virtual void Init()
        {
            
        }

        protected virtual void Show()
        {
        }

        protected virtual void Hide()
        {
        }

        public abstract UIID GetUIID();
    }
}