/****************************************************
    文件：AudioSvc.cs
	作者：Project P Group
    邮箱: 389371356@qq.com
*****************************************************/

using System;
using UnityEngine;

public class TimerSvc :MonoBehaviour{
    public static TimerSvc Instance = null;

    private PETimer pt;

    public void InitSvc() {
        Instance = this;
        pt = new PETimer();

        //设置日志输出
        pt.SetLog((string info) => {
            Debug.Log(info);
        });

        Debug.Log("Init TimerSvc...");
    }

    public void Update() {
        pt.Update();
    }

    public int AddTimeTask(Action<int> callback, double delay, PETimeUnit timeUnit = PETimeUnit.Millisecond, int count = 1) {
        return pt.AddTimeTask(callback, delay, timeUnit, count);
    }

    public double GetNowTime() {
        return pt.GetMillisecondsTime();
    }

    public void DeleteTask(int id)
    {
        pt.DeleteTimeTask(id);
    }
}