using System;
using UnityEngine;

public static class Easing
{
	public enum EaseType
	{
		easeInQuad,
		easeOutQuad,
		easeInOutQuad,
		easeInCubic,
		easeOutCubic,
		easeInOutCubic,
		easeInQuart,
		easeOutQuart,
		easeInOutQuart,
		easeInQuint,
		easeOutQuint,
		easeInOutQuint,
		easeInSine,
		easeOutSine,
		easeInOutSine,
		easeInExpo,
		easeOutExpo,
		easeInOutExpo,
		easeInCirc,
		easeOutCirc,
		easeInOutCirc,
		linear,
		spring,
		easeInBounce,
		easeOutBounce,
		easeInOutBounce,
		easeInBack,
		easeOutBack,
		easeInOutBack,
		easeInElastic,
		easeOutElastic,
		easeInOutElastic,
		punch
	}

	public static float ease(Easing.EaseType easeType, float value, float start = 0f, float end = 1f)
	{
		switch (easeType)
		{
		case Easing.EaseType.easeInQuad:
			return Easing.easeInQuad(start, end, value);
		case Easing.EaseType.easeOutQuad:
			return Easing.easeOutQuad(start, end, value);
		case Easing.EaseType.easeInOutQuad:
			return Easing.easeInOutQuad(start, end, value);
		case Easing.EaseType.easeInCubic:
			return Easing.easeInCubic(start, end, value);
		case Easing.EaseType.easeOutCubic:
			return Easing.easeOutCubic(start, end, value);
		case Easing.EaseType.easeInOutCubic:
			return Easing.easeInOutCubic(start, end, value);
		case Easing.EaseType.easeInQuart:
			return Easing.easeInQuart(start, end, value);
		case Easing.EaseType.easeOutQuart:
			return Easing.easeOutQuart(start, end, value);
		case Easing.EaseType.easeInOutQuart:
			return Easing.easeInOutQuart(start, end, value);
		case Easing.EaseType.easeInQuint:
			return Easing.easeInQuint(start, end, value);
		case Easing.EaseType.easeOutQuint:
			return Easing.easeOutQuint(start, end, value);
		case Easing.EaseType.easeInOutQuint:
			return Easing.easeInOutQuint(start, end, value);
		case Easing.EaseType.easeInSine:
			return Easing.easeInSine(start, end, value);
		case Easing.EaseType.easeOutSine:
			return Easing.easeOutSine(start, end, value);
		case Easing.EaseType.easeInOutSine:
			return Easing.easeInOutSine(start, end, value);
		case Easing.EaseType.easeInExpo:
			return Easing.easeInExpo(start, end, value);
		case Easing.EaseType.easeOutExpo:
			return Easing.easeOutExpo(start, end, value);
		case Easing.EaseType.easeInOutExpo:
			return Easing.easeInOutExpo(start, end, value);
		case Easing.EaseType.easeInCirc:
			return Easing.easeInCirc(start, end, value);
		case Easing.EaseType.easeOutCirc:
			return Easing.easeOutCirc(start, end, value);
		case Easing.EaseType.easeInOutCirc:
			return Easing.easeInOutCirc(start, end, value);
		case Easing.EaseType.linear:
			return Easing.linear(start, end, value);
		case Easing.EaseType.spring:
			return Easing.spring(start, end, value);
		case Easing.EaseType.easeInBounce:
			return Easing.easeInBounce(start, end, value);
		case Easing.EaseType.easeOutBounce:
			return Easing.easeOutBounce(start, end, value);
		case Easing.EaseType.easeInOutBounce:
			return Easing.easeInOutBounce(start, end, value);
		case Easing.EaseType.easeInBack:
			return Easing.easeInBack(start, end, value);
		case Easing.EaseType.easeOutBack:
			return Easing.easeOutBack(start, end, value);
		case Easing.EaseType.easeInOutBack:
			return Easing.easeInOutBack(start, end, value);
		case Easing.EaseType.easeInElastic:
			return Easing.easeInElastic(start, end, value);
		case Easing.EaseType.easeOutElastic:
			return Easing.easeOutElastic(start, end, value);
		case Easing.EaseType.easeInOutElastic:
			return Easing.easeInOutElastic(start, end, value);
		default:
			return Mathf.Clamp01(value);
		}
	}

	private static float linear(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, value);
	}

	private static float clerp(float start, float end, float value)
	{
		float num = 0f;
		float num2 = 360f;
		float num3 = Mathf.Abs((num2 - num) / 2f);
		float result;
		if (end - start < -num3)
		{
			float num4 = (num2 - start + end) * value;
			result = start + num4;
		}
		else if (end - start > num3)
		{
			float num4 = -(num2 - end + start) * value;
			result = start + num4;
		}
		else
		{
			result = start + (end - start) * value;
		}
		return result;
	}

	private static float spring(float start, float end, float value)
	{
		value = Mathf.Clamp01(value);
		value = (Mathf.Sin(value * 3.14159274f * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + 1.2f * (1f - value));
		return start + (end - start) * value;
	}

	private static float easeInQuad(float start, float end, float value)
	{
		end -= start;
		return end * value * value + start;
	}

	private static float easeOutQuad(float start, float end, float value)
	{
		end -= start;
		return -end * value * (value - 2f) + start;
	}

	private static float easeInOutQuad(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end / 2f * value * value + start;
		}
		value -= 1f;
		return -end / 2f * (value * (value - 2f) - 1f) + start;
	}

	private static float easeInCubic(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value + start;
	}

	private static float easeOutCubic(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * (value * value * value + 1f) + start;
	}

	private static float easeInOutCubic(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end / 2f * value * value * value + start;
		}
		value -= 2f;
		return end / 2f * (value * value * value + 2f) + start;
	}

	private static float easeInQuart(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value * value + start;
	}

	private static float easeOutQuart(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return -end * (value * value * value * value - 1f) + start;
	}

	private static float easeInOutQuart(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end / 2f * value * value * value * value + start;
		}
		value -= 2f;
		return -end / 2f * (value * value * value * value - 2f) + start;
	}

	private static float easeInQuint(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value * value * value + start;
	}

	private static float easeOutQuint(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * (value * value * value * value * value + 1f) + start;
	}

	private static float easeInOutQuint(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end / 2f * value * value * value * value * value + start;
		}
		value -= 2f;
		return end / 2f * (value * value * value * value * value + 2f) + start;
	}

	private static float easeInSine(float start, float end, float value)
	{
		end -= start;
		return -end * Mathf.Cos(value / 1f * 1.57079637f) + end + start;
	}

	private static float easeOutSine(float start, float end, float value)
	{
		end -= start;
		return end * Mathf.Sin(value / 1f * 1.57079637f) + start;
	}

	private static float easeInOutSine(float start, float end, float value)
	{
		end -= start;
		return -end / 2f * (Mathf.Cos(3.14159274f * value / 1f) - 1f) + start;
	}

	private static float easeInExpo(float start, float end, float value)
	{
		end -= start;
		return end * Mathf.Pow(2f, 10f * (value / 1f - 1f)) + start;
	}

	private static float easeOutExpo(float start, float end, float value)
	{
		end -= start;
		return end * (-Mathf.Pow(2f, -10f * value / 1f) + 1f) + start;
	}

	private static float easeInOutExpo(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end / 2f * Mathf.Pow(2f, 10f * (value - 1f)) + start;
		}
		value -= 1f;
		return end / 2f * (-Mathf.Pow(2f, -10f * value) + 2f) + start;
	}

	private static float easeInCirc(float start, float end, float value)
	{
		end -= start;
		return -end * (Mathf.Sqrt(1f - value * value) - 1f) + start;
	}

	private static float easeOutCirc(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * Mathf.Sqrt(1f - value * value) + start;
	}

	private static float easeInOutCirc(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return -end / 2f * (Mathf.Sqrt(1f - value * value) - 1f) + start;
		}
		value -= 2f;
		return end / 2f * (Mathf.Sqrt(1f - value * value) + 1f) + start;
	}

	private static float easeInBounce(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		return end - Easing.easeOutBounce(0f, end, num - value) + start;
	}

	private static float easeOutBounce(float start, float end, float value)
	{
		value /= 1f;
		end -= start;
		if (value < 0.363636374f)
		{
			return end * (7.5625f * value * value) + start;
		}
		if (value < 0.727272749f)
		{
			value -= 0.545454562f;
			return end * (7.5625f * value * value + 0.75f) + start;
		}
		if ((double)value < 0.90909090909090906)
		{
			value -= 0.8181818f;
			return end * (7.5625f * value * value + 0.9375f) + start;
		}
		value -= 0.954545438f;
		return end * (7.5625f * value * value + 0.984375f) + start;
	}

	private static float easeInOutBounce(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		if (value < num / 2f)
		{
			return Easing.easeInBounce(0f, end, value * 2f) * 0.5f + start;
		}
		return Easing.easeOutBounce(0f, end, value * 2f - num) * 0.5f + end * 0.5f + start;
	}

	private static float easeInBack(float start, float end, float value)
	{
		end -= start;
		value /= 1f;
		float num = 1.70158f;
		return end * value * value * ((num + 1f) * value - num) + start;
	}

	private static float easeOutBack(float start, float end, float value)
	{
		float num = 1.70158f;
		end -= start;
		value = value / 1f - 1f;
		return end * (value * value * ((num + 1f) * value + num) + 1f) + start;
	}

	private static float easeInOutBack(float start, float end, float value)
	{
		float num = 1.70158f;
		end -= start;
		value /= 0.5f;
		if (value < 1f)
		{
			num *= 1.525f;
			return end / 2f * (value * value * ((num + 1f) * value - num)) + start;
		}
		value -= 2f;
		num *= 1.525f;
		return end / 2f * (value * value * ((num + 1f) * value + num) + 2f) + start;
	}

	private static float punch(float amplitude, float value)
	{
		if (value == 0f)
		{
			return 0f;
		}
		if (value == 1f)
		{
			return 0f;
		}
		float num = 0.3f;
		float num2 = num / 6.28318548f * Mathf.Asin(0f);
		return amplitude * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * 1f - num2) * 6.28318548f / num);
	}

	private static float easeInElastic(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (value == 0f)
		{
			return start;
		}
		if ((value /= num) == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
		}
		return -(num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.28318548f / num2)) + start;
	}

	private static float easeOutElastic(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (value == 0f)
		{
			return start;
		}
		if ((value /= num) == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
		}
		return num3 * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * num - num4) * 6.28318548f / num2) + end + start;
	}

	private static float easeInOutElastic(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (value == 0f)
		{
			return start;
		}
		if ((value /= num / 2f) == 2f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
		}
		if (value < 1f)
		{
			return -0.5f * (num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.28318548f / num2)) + start;
		}
		return num3 * Mathf.Pow(2f, -10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.28318548f / num2) * 0.5f + end + start;
	}
}
