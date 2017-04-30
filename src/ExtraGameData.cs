using System;

public class ExtraGameData
{
	public const int TYPE_CREATE_ROLE = 2;

	public const int TYPE_ENTER_GAME = 3;

	public const int TYPE_LEVEL_UP = 4;

	public const int TYPE_EXIT_GAME = 5;

	public int dataType
	{
		get;
		set;
	}

	public string roleID
	{
		get;
		set;
	}

	public string roleName
	{
		get;
		set;
	}

	public string roleLevel
	{
		get;
		set;
	}

	public int serverID
	{
		get;
		set;
	}

	public string serverName
	{
		get;
		set;
	}

	public int moneyNum
	{
		get;
		set;
	}

	public int vipLv
	{
		get;
		set;
	}

	public string unionName
	{
		get;
		set;
	}

	public int createTime
	{
		get;
		set;
	}
}
