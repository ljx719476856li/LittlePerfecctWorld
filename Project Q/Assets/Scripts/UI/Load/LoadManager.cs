/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/

using System;
using UnityEngine;
namespace UIFrame
{
    public class LoadManager : MonoBehaviour
    {
        private void Awake()
        {
            _instance = this;
        }

        private static LoadManager _instance;

        public static LoadManager Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public T Load<T>(string path,string name)where T:class
        { 
            return Resources.Load(path + name) as T;
        }
    }
}