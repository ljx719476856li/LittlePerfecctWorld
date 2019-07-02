/****************************************************
    文件：TransformsTools.cs
	作者：Phsycop
    邮箱: 389371356@qq.com
    日期：#CreateTime# 
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace  PhsycoFrameWork
{
	public class PhsycoTools : MonoBehaviour 
	{
		private PETimer pt;
		private PhsycoTools _instance;

		public PhsycoTools Instance
		{
			get { return _instance; }
			set { _instance = value; }
		}
		private void Awake()
		{
			pt = new PETimer();

			//设置日志输出
			pt.SetLog((string info) => {
				Debug.Log(info);
			});
			_instance = this;
			Debug.Log("Init TimerSvc...");
		}

		private void Update()
		{
			pt.Update();
		}

		#region 设置Transform

		public static void AddChild(Transform parent,Transform child)
		{
			child.SetParent(parent);
		}
		public static void SetLocalPosX(Transform transform, float x)
		{
			var localposition = transform.localPosition;
			localposition.x = x;
			transform.localPosition = localposition;
		}
		public static void SetLocalPosY(Transform transform, float y)
		{
			var localposition = transform.localPosition;
			localposition.y = y;
			transform.localPosition = localposition;
		}
		public static void SetLocalPosXY(Transform transform, float x,float y)
		{
			var localposition = transform.localPosition;
			localposition.y = y;
			localposition.x = x;
			transform.localPosition = localposition;
		}
		public static void SetLocalPosYZ(Transform transform, float y,float z)
		{
			var localposition = transform.localPosition;
			localposition.y = y;
			localposition.z = z;
			transform.localPosition = localposition;
		}
		public static void SetLocalPosXZ(Transform transform, float x,float z)
		{
			var localposition = transform.localPosition;
			localposition.x = x;
			localposition.z = z;
			transform.localPosition = localposition;
		}
		public static void SetLocalPosZ(Transform transform, float z)
		{
			var localposition = transform.localPosition;
			localposition.z = z;
			transform.localPosition = localposition;
		}
		public static void SetLocalPos(Transform transform,Vector3 position)
		{
			transform.localPosition = position;
		}

		public static void ResetTransform(Transform transform)
		{
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			
		}

		#endregion	
		
		#region 设置物体active属性

		public static void SetActive (Transform transform,bool isactive = true)
		{
			transform.gameObject.SetActive(isactive);
		}

		public static void SetActive(GameObject go, bool isactive = true)
		{
			go.SetActive(isactive);
		}

		#endregion
		
		#region 随机函数
		public static bool RandomFun(int percent)
		{
			return Random.Range(0, 100) <= percent;
		}

		public static object GetRandomFrom<T>(params T[] values)
		{
			return values[Random.Range(0, values.Length)];
		}
		#endregion
		#region 编辑器操作
		public static string GetNowTime()
		{
			return DateTime.Now.ToString("yyyy-MM-dd_HH") + "时";
		}

		public static void SetCopy(string str)
		{
			GUIUtility.systemCopyBuffer = str;
		}

		public static void OpenFoder(string path)
		{
			Application.OpenURL(path);
		}
		#endregion

		#region 计时器
		public int AddTimeTask(Action<int> callback, double delay, PETimeUnit timeUnit = PETimeUnit.Millisecond, int count = 1) {
			return pt.AddTimeTask(callback, delay, timeUnit, count);
		}		
		#endregion
	}
}
