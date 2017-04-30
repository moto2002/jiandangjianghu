using System;

public class UIPanelConfigure
{
	public UIPanelConfigure()
	{
		MonoSingletion<UIPanelManager>.Instance.AddPanel("MainPanel", new MainPanel());
		MonoSingletion<UIPanelManager>.Instance.AddPanel("FirstPanel", new FirstPanel());
		MonoSingletion<UIPanelManager>.Instance.AddPanel("SecondPanel", new SecondPanel());
		MonoSingletion<UIPanelManager>.Instance.AddPanel("ThirdPanel", new ThirdPanel());
		MonoSingletion<UIPanelManager>.Instance.GetPanel("MainPanel").Open();
	}
}
