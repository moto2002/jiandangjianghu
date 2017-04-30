using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdParty
{
	public class MyColor
	{
		public static List<Color> outline_colors = new List<Color>
		{
			MyColor.white,
			MyColor.outline_blue,
			MyColor.outline_green,
			MyColor.outline_purple,
			MyColor.outline_orange,
			MyColor.outline_golden
		};

		public static List<Color> lineup_colors = new List<Color>
		{
			MyColor.white,
			MyColor.lineup_di,
			MyColor.lineup_shui,
			MyColor.lineup_huo,
			MyColor.lineup_feng
		};

		public static List<Color> lineup_darkbg_colors = new List<Color>
		{
			MyColor.white,
			CommonTools.ConvertStringToColor("#fce700ff"),
			CommonTools.ConvertStringToColor("#0bd7fdff"),
			CommonTools.ConvertStringToColor("#ff2323ff"),
			CommonTools.ConvertStringToColor("#58c715ff")
		};

		public static Color white
		{
			get
			{
				return new Color(0.768627465f, 0.831372559f, 0.819607854f);
			}
		}

		public static Color green
		{
			get
			{
				return Color.green;
			}
		}

		public static Color blue
		{
			get
			{
				return new Color(0.03137255f, 0.384313732f, 0.768627465f);
			}
		}

		public static Color sky_blue
		{
			get
			{
				return new Color(0.670588255f, 0.9490196f, 1f);
			}
		}

		public static Color purple
		{
			get
			{
				return new Color(0.78039217f, 0f, 0.9490196f);
			}
		}

		public static Color orange
		{
			get
			{
				return new Color(1f, 0.6313726f, 0f);
			}
		}

		public static Color red
		{
			get
			{
				return new Color(1f, 0.137254909f, 0.137254909f);
			}
		}

		public static Color black
		{
			get
			{
				return Color.black;
			}
		}

		public static Color gray
		{
			get
			{
				return Color.gray;
			}
		}

		public static Color yellow
		{
			get
			{
				return new Color(0.929411769f, 0.9882353f, 0f);
			}
		}

		public static Color dark_red
		{
			get
			{
				return new Color(0.6f, 0f, 0f);
			}
		}

		public static Color dark_golden
		{
			get
			{
				return new Color(0.6431373f, 0.482352942f, 0.007843138f);
			}
		}

		public static Color setting_color
		{
			get
			{
				return new Color(0.6431373f, 0.482352942f, 0.007843138f);
			}
		}

		public static Color light_green
		{
			get
			{
				return new Color(0.160784319f, 0.5647059f, 0.003921569f);
			}
		}

		public static Color brown
		{
			get
			{
				return new Color(0.431372553f, 0.2901961f, 0.149019614f);
			}
		}

		public static Color outline_color_0
		{
			get
			{
				return new Color(0.203921571f, 0.470588237f, 0.0392156877f);
			}
		}

		public static Color outline_color_1
		{
			get
			{
				return new Color(0.745098054f, 0.1254902f, 0.117647059f);
			}
		}

		public static Color outline_blue
		{
			get
			{
				return new Color(0.9607843f, 0.945098042f, 0.8f);
			}
		}

		public static Color outline_green
		{
			get
			{
				return new Color(0.9607843f, 0.945098042f, 0.8f);
			}
		}

		public static Color outline_purple
		{
			get
			{
				return new Color(0.9607843f, 0.945098042f, 0.8f);
			}
		}

		public static Color outline_orange
		{
			get
			{
				return new Color(0.9607843f, 0.945098042f, 0.8f);
			}
		}

		public static Color outline_golden
		{
			get
			{
				return new Color(0.596078455f, 0.196078435f, 0.003921569f);
			}
		}

		public static Color toggle_green
		{
			get
			{
				return new Color(0.545098066f, 1f, 0f);
			}
		}

		public static Color toggle_gray
		{
			get
			{
				return new Color(0.733333349f, 0.733333349f, 0.733333349f);
			}
		}

		public static Color lineup_di
		{
			get
			{
				return new Color(0.996078432f, 0.9137255f, 0.03529412f);
			}
		}

		public static Color lineup_shui
		{
			get
			{
				return new Color(0f, 0.4509804f, 0.8666667f);
			}
		}

		public static Color lineup_huo
		{
			get
			{
				return new Color(0.882352948f, 0.3137255f, 0.0117647061f);
			}
		}

		public static Color lineup_feng
		{
			get
			{
				return new Color(0.007843138f, 0.5647059f, 0.20784314f);
			}
		}

		public static Color scene_npc_color
		{
			get
			{
				return CommonTools.ConvertStringToColor("#ffea09ff");
			}
		}

		public static Color scene_npc_outline_color
		{
			get
			{
				return CommonTools.ConvertStringToColor("#983201ff");
			}
		}
	}
}
