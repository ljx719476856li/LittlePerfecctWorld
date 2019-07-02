using System;
using System.Collections;
using Consts;
using UnityEngine;

namespace UIFrame
{
	public abstract class UIEffectBase : MonoBehaviour
	{
		protected Action _onEnterComplete;
		protected Action _onExitComplete;
		public abstract void Enter();
		public abstract void Exit();

		public virtual void OnEnterComplete(Action enterAction)
		{
			_onEnterComplete = enterAction;
		}
		public virtual void OnExitComplete(Action exitAction)
		{
			_onEnterComplete = exitAction;
		}

		public abstract UIEffect GetUIEffectLevel();
	}
}

