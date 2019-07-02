using System;
using System.Collections;
using System.Collections.Generic;
using Consts;
using UIFrame;
using UnityEngine;

public class UIEffectManager : MonoBehaviour {

	public void Enter(Transform uiTransform)
	{
		foreach (var effectBase in uiTransform.GetComponentsInChildren<UIEffectBase>(true))
		{
			effectBase.Enter();
		}
	}

	public void Exit(Transform uiTransform)
	{
		foreach (var effectBase in uiTransform.GetComponentsInChildren<UIEffectBase>(true))
		{
			effectBase.Exit();
		}
	}

	public void AddViewEffectEnterListener(Transform uiTransform,Action enterComplete)
	{
		foreach (var effectBase in uiTransform.GetComponentsInChildren<UIEffectBase>(true))
		{
			if (effectBase.GetUIEffectLevel() == UIEffect.VIEW_EFFECT)
			{
				effectBase.OnEnterComplete(enterComplete);
			}
		}
	}
	public void AddViewEffectExitListener(Transform uiTransform,Action exitComplete)
	{
		foreach (var effectBase in uiTransform.GetComponentsInChildren<UIEffectBase>(true))
		{
			if (effectBase.GetUIEffectLevel() == UIEffect.VIEW_EFFECT)
			{
				effectBase.OnExitComplete(exitComplete);
			}
		}
	}
}
