/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/

using Consts;
using UnityEngine;
namespace UIFrame
{
    public abstract class TopUI : UIBase 	
    {

        protected override void Init()
        {
            Layer = UILayer.TOP_UI;
        }
        protected override void Show()
        {
            base.Show();
        }
        protected override void Hide()
        {
            base.Hide();
        }
        
        protected virtual void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

    }
}