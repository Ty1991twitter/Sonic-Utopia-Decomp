using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Actor))]
public class ActorStatistics : ActorComponent
{
	[CompilerGenerated]
	private sealed class _003CGetAttribute_003Ec__AnonStorey21
	{
		internal string sName;

		internal bool _003C_003Em__16(Statistic o)
		{
			return o.name == sName;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetAttributeValue_003Ec__AnonStorey22
	{
		internal string sName;

		internal bool _003C_003Em__17(Statistic o)
		{
			return o.name == sName;
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyImpactEffect_003Ec__AnonStorey23
	{
		internal ImpactEffectApplicationData oData;

		internal bool _003C_003Em__18(ImpactEffect o)
		{
			return o.behaviour == oData.behaviour && o.instigator == oData.instigator;
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveImpactEffect_003Ec__AnonStorey24
	{
		internal ImpactEffectBehaviour oBehaviour;

		internal bool _003C_003Em__19(ImpactEffect o)
		{
			return o.behaviour == oBehaviour;
		}
	}

	[SerializeField]
	private List<Statistic> _attributes = new List<Statistic>();

	[SerializeField]
	private List<ImpactEffect> _impactEffects = new List<ImpactEffect>();

	public List<Statistic> attributes
	{
		get
		{
			return _attributes;
		}
		set
		{
			_attributes = value;
		}
	}

	public List<ImpactEffect> impactEffects
	{
		get
		{
			return _impactEffects;
		}
		set
		{
			_impactEffects = value;
		}
	}

	public Statistic GetAttribute(string sName)
	{
		_003CGetAttribute_003Ec__AnonStorey21 _003CGetAttribute_003Ec__AnonStorey = new _003CGetAttribute_003Ec__AnonStorey21();
		_003CGetAttribute_003Ec__AnonStorey.sName = sName;
		return _attributes.Find(_003CGetAttribute_003Ec__AnonStorey._003C_003Em__16);
	}

	public float GetAttributeValue(string sName)
	{
		_003CGetAttributeValue_003Ec__AnonStorey22 _003CGetAttributeValue_003Ec__AnonStorey = new _003CGetAttributeValue_003Ec__AnonStorey22();
		_003CGetAttributeValue_003Ec__AnonStorey.sName = sName;
		Statistic statistic = _attributes.Find(_003CGetAttributeValue_003Ec__AnonStorey._003C_003Em__17);
		return (statistic == null) ? 0f : statistic.totalValue;
	}

	public void ApplyImpactEffect(ImpactEffectApplicationData oData)
	{
		_003CApplyImpactEffect_003Ec__AnonStorey23 _003CApplyImpactEffect_003Ec__AnonStorey = new _003CApplyImpactEffect_003Ec__AnonStorey23();
		_003CApplyImpactEffect_003Ec__AnonStorey.oData = oData;
		if (_003CApplyImpactEffect_003Ec__AnonStorey.oData.behaviour == null)
		{
			return;
		}
		ImpactEffect impactEffect = impactEffects.Find(_003CApplyImpactEffect_003Ec__AnonStorey._003C_003Em__18);
		if (impactEffect != null)
		{
			impactEffect.OnApply();
		}
		else
		{
			impactEffect = new ImpactEffect(_003CApplyImpactEffect_003Ec__AnonStorey.oData);
			impactEffect.OnApply();
			if (impactEffect.duration > 0f)
			{
				impactEffects.Add(impactEffect);
				impactEffect.Initialize(base.actor);
				impactEffect.Expired += HandleImpactEffectExpired;
				impactEffect.OnAdd();
			}
		}
		if (impactEffect != null)
		{
			impactEffect.instigator = _003CApplyImpactEffect_003Ec__AnonStorey.oData.instigator;
			impactEffect.magnitude = _003CApplyImpactEffect_003Ec__AnonStorey.oData.magnitude;
			impactEffect.duration = _003CApplyImpactEffect_003Ec__AnonStorey.oData.behaviour.duration;
			impactEffect.remainingDuration = _003CApplyImpactEffect_003Ec__AnonStorey.oData.behaviour.duration;
			impactEffect.periodDuration = _003CApplyImpactEffect_003Ec__AnonStorey.oData.behaviour.periodDuration;
			impactEffect.periodRemainingDuration = _003CApplyImpactEffect_003Ec__AnonStorey.oData.behaviour.periodDuration;
			impactEffect.period = 0;
			impactEffect.quantity += _003CApplyImpactEffect_003Ec__AnonStorey.oData.quantity;
		}
	}

	public void RemoveImpactEffect(ImpactEffect oImpactEffect)
	{
		oImpactEffect.OnRemove();
		impactEffects.Remove(oImpactEffect);
	}

	public void RemoveImpactEffect(ImpactEffectBehaviour oBehaviour)
	{
		_003CRemoveImpactEffect_003Ec__AnonStorey24 _003CRemoveImpactEffect_003Ec__AnonStorey = new _003CRemoveImpactEffect_003Ec__AnonStorey24();
		_003CRemoveImpactEffect_003Ec__AnonStorey.oBehaviour = oBehaviour;
		List<ImpactEffect> list = impactEffects.FindAll(_003CRemoveImpactEffect_003Ec__AnonStorey._003C_003Em__19);
		foreach (ImpactEffect item in list)
		{
			item.OnRemove();
			impactEffects.Remove(item);
		}
	}

	public void HandleImpactEffectExpired(object sender, ImpactEffectExpiredEventArgs e)
	{
		ImpactEffect impactEffect = ((!(sender is ImpactEffect)) ? null : (sender as ImpactEffect));
		if (impactEffect != null)
		{
			RemoveImpactEffect(impactEffect);
		}
	}

	private void Awake()
	{
		if (!base.actor)
		{
			return;
		}
		for (int i = 0; i < impactEffects.Count; i++)
		{
			impactEffects[i].Initialize(base.actor);
			if (impactEffects[i].behaviour != null)
			{
				impactEffects[i].duration = impactEffects[i].behaviour.duration;
				impactEffects[i].periodDuration = impactEffects[i].behaviour.periodDuration;
				impactEffects[i].remainingDuration = Mathf.Clamp(impactEffects[i].remainingDuration, 0f, impactEffects[i].duration);
				impactEffects[i].periodRemainingDuration = Mathf.Clamp(impactEffects[i].periodRemainingDuration, 0f, impactEffects[i].periodDuration);
			}
			impactEffects[i].OnAdd();
			impactEffects[i].Expired += HandleImpactEffectExpired;
		}
	}
}
