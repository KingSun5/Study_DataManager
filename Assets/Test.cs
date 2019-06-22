
using UnityEngine;
using Object = System.Object;


public class Test : MonoBehaviour
{


	private UserInfo _userInfo;

	private void Awake()
	{
		new UserInfo();
		DataManager.Instance.AddDataWatch(DataType.UserInfo,OnRefresh);
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(100,100,100,100),"获取UserInfo"))
		{
			print("获取UserInfo");
			_userInfo = DataManager.Instance.Get(DataType.UserInfo) as UserInfo;
		}

		if (GUI.Button(new Rect(200,100,100,100),"测试UserInfo"))
		{
			print("修改前："+_userInfo.TestStr);
		}
		
		if (GUI.Button(new Rect(300,100,100,100),"广播UserInfo数据"))
		{
			_userInfo.TestStr = "我被修改了";
			_userInfo.Notify();
		}
	}


	private void OnRefresh(params Object[] param)
	{
		var user = param[0] as UserInfo;
		
		print(param[0]);
		
		print("修改后："+user.TestStr);
	}
}
