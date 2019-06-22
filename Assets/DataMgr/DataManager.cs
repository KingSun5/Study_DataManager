


using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据类型
/// </summary>
public enum DataType
{
	UserInfo = 1001,
	EnemyInfo = 1002,
}

/// <summary>
/// 数据管理成员接口
/// </summary>
public interface IDataMgr
{

	Dictionary<DataType, DataBase> EventListerDict { get; set; }//存储注册的信息
	
	void AddDataWatch(DataType dataType,EventMgr eventMgr);//绑定更新方法
	
	void Register(DataType dataType, DataBase dataBase);//注册数据信息

	DataBase Get(DataType dataType);//获取数据

}

/// <summary>
/// time:2019/6/21 16：37
/// author:Sun
/// des:数据驱动管理
///
/// github:https://github.com/KingSun5
/// csdn:https://blog.csdn.net/Mr_Sun88
/// </summary>
public class DataManager:IDataMgr
{

	private static DataManager _instance;

	public static DataManager Instance
	{
		get
		{
			if (_instance==null)
			{
				_instance = new DataManager();
			}
			return _instance;
		}
	}

	public Dictionary<DataType, DataBase> EventListerDict { get; set; }
	
	/// <summary>
	/// 绑定数据类监听
	/// </summary>
	/// <param name="dataType"></param>
	/// <param name="eventMgr"></param>
	public void AddDataWatch(DataType dataType, EventMgr eventMgr)
	{
		EventManager.Instance.Register((int)dataType,eventMgr);
	}

	/// <summary>
	/// 注册数据类
	/// </summary>
	/// <param name="dataType"></param>
	/// <param name="dataBase"></param>
	public void Register(DataType dataType, DataBase dataBase)
	{
		if (EventListerDict==null)
		{
			EventListerDict = new Dictionary<DataType, DataBase>();
		}

		if (EventListerDict.ContainsKey(dataType))
		{
			Debug.LogError("Key:"+dataType+"已经被注册！");
			return;
		}
		EventListerDict.Add(dataType,dataBase);	
	}

	/// <summary>
	/// 获取数据类
	/// </summary>
	/// <param name="dataType"></param>
	/// <returns></returns>
	public DataBase Get(DataType dataType)
	{
		if (EventListerDict.ContainsKey(dataType))
		{
			return EventListerDict[dataType];
		}
		Debug.LogError("Key:"+dataType+"不存在,获取失败！");
		return null;
	}
}


