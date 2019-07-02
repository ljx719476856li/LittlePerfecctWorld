/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/

using System;
using System.Collections.Generic;
using Consts;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

namespace UIFrame
{
    public class UIManager : MonoBehaviour
    {
        private TimerSvc _timerSvc;
        private Dictionary<UIID, GameObject> _uiGameObjectsDic = new Dictionary<UIID, GameObject>();
        private readonly Stack<UIBase> _uiStake = new Stack<UIBase>();
        private UILayerManager _uiLayerManager;
        private UIEffectManager _uiEffectManager;
        private void Awake()
        {
            _uiLayerManager = GetComponent<UILayerManager>();
            _uiEffectManager = GetComponent<UIEffectManager>();
            if (_uiLayerManager == null)
            {
                Debug.LogError("can not find UiLayerManager");
            }
            if (_uiEffectManager == null)
            {
                Debug.LogError("can not find UiEffectManager");
            }
        }

        private void Start()
        {
            
        }

        public void Show(UIID id)
        {           
            GameObject go  = GetUIObejct(id);
            if(go==null)
            {
                Debug.LogError("can not find ID:"+id);
            }        
            UIBase uiScript = GetUIScript(go,id);
            if (uiScript == null)
            {
                return;
            }

            InitUI(uiScript);
            if (uiScript.Layer == UILayer.BASIC_UI)
            {
                uiScript.State = UIState.SHOW;
                Hide();
            }
            else
            {
                uiScript.State = UIState.SHOW;
            }

            _uiEffectManager.Enter(uiScript.transform);
            _uiStake.Push(uiScript);
        }
        
        public void Hide()
        {
            if (_uiStake.Count != 0)
            {
                _uiStake.Peek().State = UIState.HIDE;
                _uiEffectManager.Exit( _uiStake.Peek().transform);
            }

        }

        public void Back()
        {
            if (_uiStake.Count > 1)
            {
                UIBase hideUI = _uiStake.Pop();
                if (hideUI.Layer == UILayer.BASIC_UI)
                {
                    hideUI.State = UIState.HIDE;
                    _uiStake.Peek().State = UIState.SHOW;
                }
                else
                {
                    _uiStake.Pop().State = UIState.HIDE;
                }
                _uiEffectManager.Exit(hideUI.transform);
            }
            else
            {
                Debug.LogError("UIStake has one or no element");
            }
        }

        private void InitUI(UIBase uiScript)
        {
            if (uiScript.State == UIState.NORMAL)
            {
                Transform uitrans = uiScript.transform;
                uitrans.SetParent(_uiLayerManager.GetUiLayerTransform(uiScript.Layer));
                uitrans.localPosition = Vector3.zero;
                Debug.Log(uitrans.localPosition);
                uitrans.localScale = Vector3.one;
            }
        }
        private GameObject GetUIObejct(UIID id)
        {
            if (!_uiGameObjectsDic.ContainsKey(id) || _uiGameObjectsDic[id] == null)
            {
                GameObject prefab = LoadManager.Instance.Load<GameObject>(Path.UIPath, id.ToString());
                if (prefab != null)
                {

                    _uiGameObjectsDic[id] = Instantiate(prefab);
                    
                }
                else
                {
                    Debug.LogError("can not find prefab name:"+id);
                }
                
            }
            return _uiGameObjectsDic[id];
        }

        private UIBase GetUIScript(GameObject go,UIID id)
        {
            UIBase ui = go.GetComponent<UIBase>();
            if (ui == null)
            {
                 return AddUIScript(go,id);
            }
            else 
            {
                return ui;
            }
        }

        private UIBase AddUIScript(GameObject go,UIID id)
        {
            string name = ConstValue.NAMASPACE_NAME+"."+id+ConstValue.UI_SCRIPT_POSTFIX;
            Type ui = Type.GetType(name);
            if (ui != null)
            {
                 return go.AddComponent(ui) as UIBase;
            }
            else
            {
                Debug.LogError("can not find Script"+name);
                return null;
            }
        }
    }

    
}