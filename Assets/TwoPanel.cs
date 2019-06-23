using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoPanel : MonoBehaviour {
	
	/// <summary>
	/// 页面1
	/// </summary>
	public Transform Panel1;
	/// <summary>
	/// 页面2
	/// </summary>
	public Transform Panel2;
	/// <summary>
	/// 金币增加
	/// </summary>
	public Button BtnAdd;
	/// <summary>
	/// 金币减少
	/// </summary>
	public Button BtnReduce;
	/// <summary>
	/// 返回
	/// </summary>
	public Button BtnReturn;
	/// <summary>
	/// 触发图
	/// </summary>
	public Image ImgChange;
	/// <summary>
	/// 背包数据
	/// </summary>
	private UserInfo _userInfo;

	// Use this for initialization
	void Start () {
		//获取背包数据
		_userInfo = DataManager.Instance.Get(DataType.UserInfo) as UserInfo;
		
		BtnAdd.onClick.AddListener(OnClickAdd);
		BtnReduce.onClick.AddListener(OnClickReduce);
		BtnReturn.onClick.AddListener(OnClickReturn);
		
		//绑定方法，数据变动后刷新
		DataManager.Instance.AddDataWatch(DataType.UserInfo,OnRefresh);
	}
	
	/// <summary>
	/// 添加金币
	/// </summary>
	private void OnClickAdd()
	{
		_userInfo.CoinTotal += 100;
		
		//每次变动广播一下数据
		_userInfo.Notify();
	}
	
	/// <summary>
	/// 减少金币
	/// </summary>
	private void OnClickReduce()
	{
		_userInfo.CoinTotal -= 200;
		
		//每次变动广播一下数据
		_userInfo.Notify();
	}
	
	/// <summary>
	/// 返回页面
	/// </summary>
	private void OnClickReturn()
	{
		Panel1.gameObject.SetActive(true);
		Panel2.gameObject.SetActive(false);
	}
	
	/// <summary>
	/// 数据变动后的刷新方法
	/// </summary>
	/// <param name="param"></param>
	private void OnRefresh(params object[] param)
	{
		//获取广播的数据
		var user = param[0] as UserInfo;
		if (user.CoinTotal>=500)
		{
			Debug.Log("2222");
			ImgChange.color = Color.black;
		}
	}
}
