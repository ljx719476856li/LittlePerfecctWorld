/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/

using Consts;
using UnityEngine;
namespace UIFrame
{
    public abstract class OverlayUI : UIBase 	
    {
        public void Start ()		
        {
        }

        protected override void Init()
        {
            Layer = UILayer.OVERLAY_UI;
        }
        protected override void Show()
        {
            base.Show();
        }
        protected override void Hide()
        {
            base.Hide();
        }
        
    }
}  