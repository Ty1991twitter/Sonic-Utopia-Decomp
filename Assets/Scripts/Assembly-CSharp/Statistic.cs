using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class Statistic
{
	[CompilerGenerated]
	private sealed class _003CAddModifier_003Ec__AnonStorey2B
	{
		internal StatisticModifier oModifier;

		internal bool _003C_003Em__21(StatisticModifier o)
		{
			return o.source == oModifier.source;
		}
	}

	[CompilerGenerated]
	private sealed class _003CAddModifier_003Ec__AnonStorey2C
	{
		internal UnityEngine.Object oSource;

		internal bool _003C_003Em__22(StatisticModifier o)
		{
			return o.source == oSource;
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveModifier_003Ec__AnonStorey2D
	{
		internal UnityEngine.Object oSource;

		internal bool _003C_003Em__23(StatisticModifier o)
		{
			return o.source == oSource;
		}
	}

	[SerializeField]
	private string _name = "Statistic";

	[SerializeField]
	[HideInInspector]
	private bool _integer;

	[SerializeField]
	private float _baseValue;

	[HideInInspector]
	[SerializeField]
	private float _numericalModifier;

	[SerializeField]
	[HideInInspector]
	private float _percentileModifier;

	private List<StatisticModifier> _modifiers = new List<StatisticModifier>();

	[CompilerGenerated]
	private static Predicate<StatisticModifier> _003C_003Ef__am_0024cache6;

	public string name
	{
		get
		{
			return _name;
		}
		private set
		{
			_name = value;
		}
	}

	public bool integer
	{
		get
		{
			return _integer;
		}
		private set
		{
			_integer = value;
		}
	}

	public float baseValue
	{
		get
		{
			return _baseValue;
		}
		set
		{
			_baseValue = value;
		}
	}

	public float numericalModifier
	{
		get
		{
			return _numericalModifier;
		}
		private set
		{
			_numericalModifier = value;
		}
	}

	public float percentileModifier
	{
		get
		{
			return _percentileModifier;
		}
		private set
		{
			_percentileModifier = value;
		}
	}

	public float totalValue
	{
		get
		{
			return (baseValue + numericalModifier) * (1f + percentileModifier);
		}
	}

	public List<StatisticModifier> modifiers
	{
		get
		{
			return _modifiers;
		}
	}

	public Statistic()
	{
		_name = "Statistic";
		_integer = false;
		_baseValue = 0f;
		_numericalModifier = 0f;
		_percentileModifier = 0f;
	}

	public Statistic(string sName)
	{
		_name = sName;
		_integer = false;
		_baseValue = 0f;
		_numericalModifier = 0f;
		_percentileModifier = 0f;
	}

	public Statistic(string sName, bool bInteger)
	{
		_name = sName;
		_integer = bInteger;
		_baseValue = 0f;
		_numericalModifier = 0f;
		_percentileModifier = 0f;
	}

	public Statistic(string sName, bool bInteger, float fValue)
	{
		_name = sName;
		_integer = bInteger;
		_baseValue = fValue;
		_numericalModifier = 0f;
		_percentileModifier = 0f;
	}

	public virtual void CalculateValue()
	{
		_numericalModifier = 0f;
		_percentileModifier = 0f;
		List<StatisticModifier> list = _modifiers;
		if (_003C_003Ef__am_0024cache6 == null)
		{
			_003C_003Ef__am_0024cache6 = _003CCalculateValue_003Em__20;
		}
		list.RemoveAll(_003C_003Ef__am_0024cache6);
		for (int i = 0; i < _modifiers.Count; i++)
		{
			switch (_modifiers[i].type)
			{
			case StatisticModifierType.Numerical:
				_numericalModifier += _modifiers[i].value;
				break;
			case StatisticModifierType.Percentile:
				_percentileModifier += _modifiers[i].value;
				break;
			}
		}
	}

	public void AddModifier(StatisticModifier oModifier)
	{
		_003CAddModifier_003Ec__AnonStorey2B _003CAddModifier_003Ec__AnonStorey2B = new _003CAddModifier_003Ec__AnonStorey2B();
		_003CAddModifier_003Ec__AnonStorey2B.oModifier = oModifier;
		float num = _modifiers.FindIndex(_003CAddModifier_003Ec__AnonStorey2B._003C_003Em__21);
		if (_003CAddModifier_003Ec__AnonStorey2B.oModifier.source != null && num < 0f)
		{
			_modifiers.Add(_003CAddModifier_003Ec__AnonStorey2B.oModifier);
		}
		CalculateValue();
	}

	public void AddModifier(StatisticModifierType oType, UnityEngine.Object oSource, float fValue)
	{
		_003CAddModifier_003Ec__AnonStorey2C _003CAddModifier_003Ec__AnonStorey2C = new _003CAddModifier_003Ec__AnonStorey2C();
		_003CAddModifier_003Ec__AnonStorey2C.oSource = oSource;
		float num = _modifiers.FindIndex(_003CAddModifier_003Ec__AnonStorey2C._003C_003Em__22);
		if (_003CAddModifier_003Ec__AnonStorey2C.oSource != null && num < 0f)
		{
			_modifiers.Add(new StatisticModifier(oType, _003CAddModifier_003Ec__AnonStorey2C.oSource, fValue));
		}
		CalculateValue();
	}

	public void RemoveModifier(UnityEngine.Object oSource)
	{
		_003CRemoveModifier_003Ec__AnonStorey2D _003CRemoveModifier_003Ec__AnonStorey2D = new _003CRemoveModifier_003Ec__AnonStorey2D();
		_003CRemoveModifier_003Ec__AnonStorey2D.oSource = oSource;
		_modifiers.RemoveAll(_003CRemoveModifier_003Ec__AnonStorey2D._003C_003Em__23);
		CalculateValue();
	}

	[CompilerGenerated]
	private static bool _003CCalculateValue_003Em__20(StatisticModifier o)
	{
		return o.source == null;
	}
}
