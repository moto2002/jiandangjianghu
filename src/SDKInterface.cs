using System;

public abstract class SDKInterface
{
	public delegate void LoginSucHandler(LoginResult data);

	public delegate void LogoutHandler();

	private static SDKInterface _instance;

	public SDKInterface.LoginSucHandler OnLoginSuc;

	public SDKInterface.LogoutHandler OnLogout;

	public static SDKInterface Instance
	{
		get
		{
			if (SDKInterface._instance == null)
			{
				SDKInterface._instance = new SDKInterfaceAndroid();
			}
			return SDKInterface._instance;
		}
	}

	public abstract void Init();

	public abstract void Login();

	public abstract void LoginCustom(string customData);

	public abstract void SwitchLogin();

	public abstract bool Logout();

	public abstract bool ShowAccountCenter();

	public abstract void SubmitGameData(ExtraGameData data);

	public abstract bool SDKExit();

	public abstract void Pay(PayParams data);

	public abstract bool IsSupportExit();

	public abstract bool IsSupportAccountCenter();

	public abstract bool IsSupportLogout();

	public abstract string GetMacAddr();

	public abstract string GetIpAddr();

	public PayParams reqOrder(PayParams data)
	{
		data.orderID = "345435634534";
		data.extension = "test111";
		return data;
	}
}
