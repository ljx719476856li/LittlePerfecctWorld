/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/

using Consts;
using UnityEngine;
namespace UIFrame
{
    public abstract class BasicUI : UIBase 	
    {
        public void Start ()		
        {
            
        }

        protected override void Init()
        {
            Layer = UILayer.BASIC_UI;
        }
        protected override void Show()
        {
            base.Show();
            gameObject.SetActive(true);
        }
        protected override void Hide()
        {
            gameObject.SetActive(false);
            base.Hide();
        }
        
    }
}