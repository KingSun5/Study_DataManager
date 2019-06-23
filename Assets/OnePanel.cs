using UnityEngine;
using UnityEngine.UI;

public class OnePanel : MonoBehaviour {
	
	/// <summary>
	/// 页面1
	/// </summary>
	public Transform Panel1;
	/// <summary>
	/// 页面2
	/// </summary>
	public Transform Panel2;
	/// <summary>
	/// 金币显示
	/// </summary>
	public Text TxtCoin;
	/// <summary>
	/// 页面跳转
	/// </summary>
	public Button BtnGo;
	/// <summary>
	/// 背包数据
	/// </summary>
	private UserInfo _userInfo;

	// Use this for initialization
	void Start () {
		
		BtnGo.onClick.AddListener(OnClickGo);

		//初始化一下背包数据
		new UserInfo();
		//获取背包数据
		_userInfo = DataManager.Instance.Get(DataType.UserInfo) as UserInfo;
		//初始化金币显示
		TxtCoin.text = _userInfo.CoinTotal.ToString();
		//绑定方法，数据变动后刷新
		DataManager.Instance.AddDataWatch(DataType.UserInfo,OnRefresh);
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
	
	/// <summary>
	/// 跳转页面
	/// </summary>
	private void OnClickGo()
	{
		Panel1.gameObject.SetActive(false);
		Panel2.gameObject.SetActive(true);
	}
}
