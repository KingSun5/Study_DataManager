using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
	/// <summary>
	/// 页面1
	/// </summary>
	public Transform OnePanel;
	/// <summary>
	/// 页面2
	/// </summary>
	public Transform TwoPanel;
	/// <summary>
	/// 金币显示
	/// </summary>
	public Text TxtCoin;
	/// <summary>
	/// 页面跳转
	/// </summary>
	public Button BtnGo;
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
	/// 背包数据
	/// </summary>
	private UserInfo _userInfo;

	private void Start()
	{
		//初始化一下背包数据
		new UserInfo();
		
		//获取背包数据
		_userInfo = DataManager.Instance.Get(DataType.UserInfo) as UserInfo;
		
		//初始化金币显示
		TxtCoin.text = _userInfo.CoinTotal.ToString();
		
		//绑定方法，数据变动后刷新
		DataManager.Instance.AddDataWatch(DataType.UserInfo,OnRefresh);
		
		BtnGo.onClick.AddListener(OnClickGo);
		BtnAdd.onClick.AddListener(OnClickAdd);
		BtnReduce.onClick.AddListener(OnClickReduce);
		BtnReturn.onClick.AddListener(OnClickReturn);
	}

	/// <summary>
	/// 跳转页面
	/// </summary>
	private void OnClickGo()
	{
		OnePanel.gameObject.SetActive(false);
		TwoPanel.gameObject.SetActive(true);
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
		OnePanel.gameObject.SetActive(true);
		TwoPanel.gameObject.SetActive(false);
	}

	/// <summary>
	/// 数据变动后的刷新方法
	/// </summary>
	/// <param name="param"></param>
	private void OnRefresh(params object[] param)
	{
		//获取广播的数据
		var user = param[0] as UserInfo;

		//更新数据显示
		TxtCoin.text = user.CoinTotal.ToString();
	}

}
