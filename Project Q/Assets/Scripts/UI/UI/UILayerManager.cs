/*======================
作者:Phsycop
时间:2019年6月30日
======================*/

using System;
using System.Collections.Generic;
using Consts;
using UnityEngine;
namespace UIFrame
{
    public class UILayerManager : MonoBehaviour 	
    {
        private readonly Dictionary<UILayer,Transform> _layerDictionary = new Dictionary<UILayer, Transform>();
        private void Awake()
        {
            Transform temp = null;
            foreach (UILayer item in Enum.GetValues(typeof(UILayer)))
            {
                temp = transform.Find(item.ToString());
                if (temp == null)
                {
                    Debug.LogError("can not find Layer"+item + "GameObject");
                    continue;
                }
                else
                {
                    _layerDictionary[item] = temp;
                }
            }
        }

        public Transform GetUiLayerTransform(UILayer uiLayer)
        {
            Transform transform;
            if (_layerDictionary.TryGetValue(uiLayer, out transform))
            {
                return transform;
            }
            else
            {
                Debug.LogError("can not get "+uiLayer);
                return null;
            }
        }
        private void Start()
        {
            
        }
    }
}