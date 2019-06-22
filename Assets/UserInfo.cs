
using UnityEngine;

public class UserInfo : DataBase
{

	public string TestStr = "我就是我UserInfo";
	private DataType _inDataType;


	public override DataType InDataType
	{
		get { return DataType.UserInfo; }
	}

	public override void OnInit()
	{
		Debug.Log("It is Ok");
	}

	public override void Notify()
	{
		EventManager.Instance.Invoke((int)InDataType,this);
	}
}
