
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



	private void OnRefresh(params Object[] param)
	{
		var user = param[0] as UserInfo;

	}
}
