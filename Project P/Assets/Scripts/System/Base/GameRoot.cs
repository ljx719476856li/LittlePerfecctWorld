/****************************************************
    文件：GameRoot.cs
	作者：SIKI学院——Plane
    邮箱: 1785275942@qq.com
    日期：2018/12/3 5:30:21
	功能：游戏启动入口
*****************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour {
    public static GameRoot Instance = null;

    private void Awake()
    {
        Init();
        DontDestroyOnLoad(this);
    }

    private void Start() {
        Instance = this;
        DontDestroyOnLoad(this);
        Debug.Log("Game Start...");
        ClearUIRoot();
        //Init();
    }

    private void ClearUIRoot() {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++) {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Init() {
        //服务模块初始化
        ResSvc res = GetComponent<ResSvc>();
        res.InitSvc();
        AudioSvc audio = GetComponent<AudioSvc>();
        audio.InitSvc();
        TimerSvc timer = GetComponent<TimerSvc>();
        timer.InitSvc();

        //业务系统初始化
        
        //进入登录场景并加载相应UI
    }


    private PlayerData playerData = null;
    public PlayerData PlayerData {
        get {
            return playerData;
        }
    }
    
}