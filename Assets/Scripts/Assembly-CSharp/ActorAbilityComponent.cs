using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Actor))]
public class ActorAbilityComponent : ActorComponent
{
	[CompilerGenerated]
	private sealed class _003CFindAbility_003Ec__AnonStorey11
	{
		internal string sName;

		internal bool _003C_003Em__1(Ability o)
		{
			return o != null && o.behaviour != null && o.behaviour.displayName == sName;
		}
	}

	[CompilerGenerated]
	private sealed class _003CEngageAbility_003Ec__AnonStorey12
	{
		internal string sName;

		internal bool _003C_003Em__2(Ability o)
		{
			return o != null && o.behaviour != null && o.behaviour.displayName == sName;
		}
	}

	[CompilerGenerated]
	private sealed class _003CDisengageAbility_003Ec__AnonStorey13
	{
		internal string sName;

		internal bool _003C_003Em__3(Ability o)
		{
			return o != null && o.behaviour != null && o.behaviour.displayName == sName;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCancelAbility_003Ec__AnonStorey14
	{
		internal string sName;

		internal bool _003C_003Em__4(Ability o)
		{
			return o != null && o.behaviour != null && o.behaviour.displayName == sName;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCancelWithTags_003Ec__AnonStorey15
	{
		internal TagContainer oTags;

		internal bool _003C_003Em__5(Ability o)
		{
			return o.behaviour != null && o.active && o.behaviour.canCancel && o.behaviour.tags.AnyTagsMatch(oTags);
		}
	}

	[SerializeField]
	protected TagContainer _tags = new TagContainer();

	[SerializeField]
	protected List<Ability> _abilities = new List<Ability>();

	public TagContainer tags
	{
		get
		{
			return _tags;
		}
	}

	public List<Ability> abilities
	{
		get
		{
			return _abilities;
		}
	}

	public event ActorAbilityEventHandler AbilityEngaged;

	public event ActorAbilityEventHandler AbilityDisengaged;

	public Ability FindAbility(string sName)
	{
		_003CFindAbility_003Ec__AnonStorey11 _003CFindAbility_003Ec__AnonStorey = new _003CFindAbility_003Ec__AnonStorey11();
		_003CFindAbility_003Ec__AnonStorey.sName = sName;
		return abilities.Find(_003CFindAbility_003Ec__AnonStorey._003C_003Em__1);
	}

	public void EngageAbility(string sName)
	{
		_003CEngageAbility_003Ec__AnonStorey12 _003CEngageAbility_003Ec__AnonStorey = new _003CEngageAbility_003Ec__AnonStorey12();
		_003CEngageAbility_003Ec__AnonStorey.sName = sName;
		Ability ability = abilities.Find(_003CEngageAbility_003Ec__AnonStorey._003C_003Em__2);
		if (ability != null)
		{
			ability.Engage();
		}
	}

	public void DisengageAbility(string sName)
	{
		_003CDisengageAbility_003Ec__AnonStorey13 _003CDisengageAbility_003Ec__AnonStorey = new _003CDisengageAbility_003Ec__AnonStorey13();
		_003CDisengageAbility_003Ec__AnonStorey.sName = sName;
		Ability ability = abilities.Find(_003CDisengageAbility_003Ec__AnonStorey._003C_003Em__3);
		if (ability != null)
		{
			ability.Disengage();
		}
	}

	public void CancelAbility(string sName)
	{
		_003CCancelAbility_003Ec__AnonStorey14 _003CCancelAbility_003Ec__AnonStorey = new _003CCancelAbility_003Ec__AnonStorey14();
		_003CCancelAbility_003Ec__AnonStorey.sName = sName;
		Ability ability = abilities.Find(_003CCancelAbility_003Ec__AnonStorey._003C_003Em__4);
		if (ability != null)
		{
			ability.Cancel();
		}
	}

	public void CancelWithTags(TagContainer oTags)
	{
		_003CCancelWithTags_003Ec__AnonStorey15 _003CCancelWithTags_003Ec__AnonStorey = new _003CCancelWithTags_003Ec__AnonStorey15();
		_003CCancelWithTags_003Ec__AnonStorey.oTags = oTags;
		List<Ability> list = abilities.FindAll(_003CCancelWithTags_003Ec__AnonStorey._003C_003Em__5);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].Cancel();
		}
	}

	private void Awake()
	{
		if ((bool)base.actor)
		{
			for (int i = 0; i < abilities.Count; i++)
			{
				abilities[i].Initialize(base.actor);
			}
		}
	}
}
