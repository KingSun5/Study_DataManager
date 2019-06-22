
/// <summary>
/// time:2019/6/21 16:36
/// author:Sun
/// des:数据驱动基类
///
/// github:https://github.com/KingSun5
/// csdn:https://blog.csdn.net/Mr_Sun88
/// </summary>
public abstract class DataBase
{

	/// <summary>
	/// 数据类型
	/// </summary>
	public abstract DataType InDataType { get;}

	/// <summary>
	/// 初始化
	/// </summary>
	public abstract void OnInit();
	
	/// <summary>
	/// 广播自身
	/// </summary>
	public abstract void Notify();

	/// <summary>
	/// 构造函数内注册自己
	/// </summary>
	public DataBase()
	{
		OnInit();
		DataManager.Instance.Register(InDataType,this);
	}
}
