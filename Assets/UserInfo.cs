
using UnityEngine;

public class UserInfo : DataBase
{
	/// <summary>
	/// 背包内金币数量
	/// </summary>
	public int CoinTotal;
	
	public override DataType InDataType
	{
		get { return DataType.UserInfo; }
	}

	public override void OnInit()
	{
		CoinTotal = 100;
	}

	public override void Notify()
	{
		EventManager.Instance.Invoke((int)InDataType,this);
	}
}
