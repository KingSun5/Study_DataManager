/// <summary>
/// time:2019/6/23 13:13
/// author:Sun
/// des:事件封装
///
/// github:https://github.com/KingSun5
/// csdn:https://blog.csdn.net/Mr_Sun88
/// </summary>
public class DataEvent
{
	/// <summary>
	/// 实例事件
	/// </summary>
	public  EventMgr InstanceEvent;

	/// <summary>
	/// 绑定方法
	/// </summary>
	/// <param name="eventMgr"></param>
	public void BindEvnt(EventMgr eventMgr)
	{
		InstanceEvent += eventMgr;
	}
}
