using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[DisallowMultipleComponent]
public class Actor : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CImpactEffect_003Ec__AnonStorey10
	{
		internal ImpactEffectApplicationData oData;

		internal bool _003C_003Em__0(ImpactEffect o)
		{
			return o.behaviour == oData.behaviour && o.instigator == oData.instigator;
		}
	}

	[SerializeField]
	private TagContainer _tagContainer = new TagContainer();

	private bool _alive = true;

	private ActorPhysics _physics;

	private ActorStatistics _statistics;

	private ActorInventory _inventory;

	private ActorAbilityComponent _abilityComponent;

	private Health _health;

	private Impactable _impactable;

	private Rigidbody _rigidbody;

	private Vector3 _spawnPosition = Vector3.zero;

	private Quaternion _spawnRotation = Quaternion.identity;

	public TagContainer tagContainer
	{
		get
		{
			return _tagContainer;
		}
	}

	public bool alive
	{
		get
		{
			return _alive;
		}
		protected set
		{
			if ((bool)health)
			{
				if (value)
				{
					health.currentValue = health.maximum.totalValue;
				}
				else
				{
					health.currentValue = 0f;
				}
			}
			_alive = value;
		}
	}

	public ActorPhysics physics
	{
		get
		{
			return (!_physics) ? (_physics = GetComponent<ActorPhysics>()) : _physics;
		}
	}

	public ActorStatistics statistics
	{
		get
		{
			return (!_statistics) ? (_statistics = GetComponent<ActorStatistics>()) : _statistics;
		}
	}

	public ActorInventory inventory
	{
		get
		{
			return (!_inventory) ? (_inventory = GetComponent<ActorInventory>()) : _inventory;
		}
	}

	public ActorAbilityComponent abilityComponent
	{
		get
		{
			return (!_abilityComponent) ? (_abilityComponent = GetComponent<ActorAbilityComponent>()) : _abilityComponent;
		}
	}

	public Health health
	{
		get
		{
			return (!_health) ? (_health = GetComponent<Health>()) : _health;
		}
	}

	public Impactable impactable
	{
		get
		{
			return (!_impactable) ? (_impactable = GetComponent<Impactable>()) : _impactable;
		}
	}

	public Rigidbody rigidbody
	{
		get
		{
			return (!_rigidbody) ? (_rigidbody = GetComponent<Rigidbody>()) : _rigidbody;
		}
	}

	public Vector3 spawnPosition
	{
		get
		{
			return _spawnPosition;
		}
		set
		{
			_spawnPosition = value;
		}
	}

	public Quaternion spawnRotation
	{
		get
		{
			return _spawnRotation;
		}
		set
		{
			_spawnRotation = value;
		}
	}

	public float healthPercentage
	{
		get
		{
			return (!(health != null) || !(health.maximum.totalValue > 0f)) ? 0f : (health.currentValue / health.maximum.totalValue);
		}
	}

	public event ActorEventHandler Tick;

	public event ActorEventHandler Changed;

	public event ActorEventHandler Respawned;

	public event ActorEventHandler Despawned;

	public event ActorEventHandler Death;

	public event ActorEventHandler ImpactIncoming;

	public event ActorEventHandler ImpactHit;

	public event ActorEventHandler ImpactApply;

	public event ActorEventHandler ImpactEffectIncoming;

	public event ActorEventHandler ImpactEffectApply;

	public Statistic GetAttribute(string sName)
	{
		return (!statistics) ? null : statistics.GetAttribute(sName);
	}

	public float GetAttributeValue(string sName)
	{
		return (!statistics) ? 0f : statistics.GetAttributeValue(sName);
	}

	protected void TriggerDeath()
	{
		if (this.Death != null)
		{
			this.Death(this, new ActorDeathEventArgs(new ContextDeath(), new DefaultDeath()));
		}
	}

	protected void TriggerDeath(DeathType oType)
	{
		if (this.Death != null)
		{
			this.Death(this, new ActorDeathEventArgs(new ContextDeath(), (oType != null) ? oType : (oType = new DefaultDeath())));
		}
	}

	protected void TriggerRespawn()
	{
		if (this.Respawned != null)
		{
			this.Respawned(this, new ActorGenericEventArgs(new ContextRespawn()));
		}
	}

	protected void TriggerDespawn()
	{
		if (this.Despawned != null)
		{
			this.Despawned(this, new ActorGenericEventArgs(new ContextRespawn()));
		}
	}

	protected void TriggerTick(float fDeltaTime)
	{
		if (this.Tick != null && fDeltaTime > 0f)
		{
			this.Tick(this, new ActorTickEventArgs(new ContextTick(), fDeltaTime));
		}
	}

	protected void TriggerChanged(int i)
	{
		if (this.Changed != null)
		{
			this.Changed(this, new ActorChangedEventArgs(new ContextChanged(), i));
		}
	}

	protected void TriggerImpactIncoming(ImpactApplicationData oData)
	{
		if (this.ImpactIncoming != null && oData != null)
		{
			this.ImpactIncoming(this, new ActorImpactEventArgs(new ContextImpactIncoming(), oData));
		}
	}

	protected void TriggerImpactHit(ImpactApplicationData oData)
	{
		if (this.ImpactHit != null && oData != null)
		{
			this.ImpactHit(this, new ActorImpactEventArgs(new ContextImpactHit(), oData));
		}
	}

	protected void TriggerImpactApply(ImpactApplicationData oData)
	{
		if (this.ImpactApply != null && oData != null)
		{
			this.ImpactApply(this, new ActorImpactEventArgs(new ContextImpactApply(), oData));
		}
	}

	protected void TriggerImpactEffectIncoming(ImpactEffectApplicationData oData)
	{
		if (this.ImpactEffectIncoming != null && oData != null)
		{
			this.ImpactEffectIncoming(this, new ActorImpactEffectEventArgs(new ContextImpactEffectIncoming(), oData));
		}
	}

	protected void TriggerImpactEffectApply(ImpactEffectApplicationData oData)
	{
		if (this.ImpactEffectApply != null && oData != null)
		{
			this.ImpactEffectApply(this, new ActorImpactEffectEventArgs(new ContextImpactEffectApply(), oData));
		}
	}

	public Component AddComponent(Type tType)
	{
		Component result = base.gameObject.AddComponent(tType);
		SendChangedMessage(0);
		TriggerChanged(0);
		return result;
	}

	public T AddComponent<T>() where T : Component
	{
		T result = base.gameObject.AddComponent<T>();
		SendChangedMessage(0);
		TriggerChanged(0);
		return result;
	}

	private void SendChangedMessage(int iValue)
	{
		SendMessage("OnChanged", iValue, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void Impact(ImpactApplicationData oData)
	{
		if (!impactable || !tagContainer.AllTagsMatch(oData.requiredTags) || tagContainer.AnyTagsMatch(oData.blockedByTags))
		{
			return;
		}
		TriggerImpactIncoming(oData);
		if (!oData.prevented)
		{
			TriggerImpactHit(oData);
			OnImpactHit(oData);
			if (!oData.prevented)
			{
				TriggerImpactApply(oData);
				OnImpactApply(oData);
				for (int i = 0; i < oData.effects.Count; i++)
				{
					if (oData.effects[i] != null)
					{
						ImpactEffectApplicationData impactEffectApplicationData = new ImpactEffectApplicationData(oData.effects[i]);
						impactEffectApplicationData.target = oData.target;
						impactEffectApplicationData.instigator = oData.instigator;
						impactEffectApplicationData.source = oData.source;
						ImpactEffectApplicationData oData2 = impactEffectApplicationData;
						ImpactEffect(oData2);
					}
				}
			}
		}
		if (alive && healthPercentage <= 0f)
		{
			Die();
		}
	}

	public virtual void ImpactEffect(ImpactEffectApplicationData oData)
	{
		_003CImpactEffect_003Ec__AnonStorey10 _003CImpactEffect_003Ec__AnonStorey = new _003CImpactEffect_003Ec__AnonStorey10();
		_003CImpactEffect_003Ec__AnonStorey.oData = oData;
		if (!impactable | !statistics | (_003CImpactEffect_003Ec__AnonStorey.oData.behaviour == null))
		{
			return;
		}
		TriggerImpactEffectIncoming(_003CImpactEffect_003Ec__AnonStorey.oData);
		if (_003CImpactEffect_003Ec__AnonStorey.oData.prevented)
		{
			return;
		}
		ImpactEffect impactEffect = statistics.impactEffects.Find(_003CImpactEffect_003Ec__AnonStorey._003C_003Em__0);
		TriggerImpactEffectApply(_003CImpactEffect_003Ec__AnonStorey.oData);
		if (impactEffect != null)
		{
			impactEffect.OnApply();
		}
		else
		{
			impactEffect = new ImpactEffect(_003CImpactEffect_003Ec__AnonStorey.oData);
			impactEffect.Initialize(this);
			impactEffect.OnApply();
			if (impactEffect.duration > 0f)
			{
				statistics.impactEffects.Add(impactEffect);
				impactEffect.Initialize(this);
				impactEffect.Expired += statistics.HandleImpactEffectExpired;
				impactEffect.OnAdd();
			}
		}
		if (impactEffect != null)
		{
			impactEffect.instigator = _003CImpactEffect_003Ec__AnonStorey.oData.instigator;
			impactEffect.magnitude = _003CImpactEffect_003Ec__AnonStorey.oData.magnitude;
			impactEffect.duration = _003CImpactEffect_003Ec__AnonStorey.oData.duration;
			impactEffect.remainingDuration = _003CImpactEffect_003Ec__AnonStorey.oData.behaviour.duration;
			impactEffect.periodDuration = _003CImpactEffect_003Ec__AnonStorey.oData.behaviour.periodDuration;
			impactEffect.periodRemainingDuration = _003CImpactEffect_003Ec__AnonStorey.oData.behaviour.periodDuration;
			impactEffect.period = 0;
			impactEffect.quantity += _003CImpactEffect_003Ec__AnonStorey.oData.quantity;
		}
		OnImpactEffectApply(_003CImpactEffect_003Ec__AnonStorey.oData);
	}

	public void Die()
	{
		if (!(!impactable | !alive))
		{
			alive = false;
			TriggerDeath();
			OnDeath();
		}
	}

	public void Die(DeathType oType)
	{
		if (!(!impactable | !alive))
		{
			alive = false;
			TriggerDeath(oType);
			OnDeath();
		}
	}

	public void Despawn()
	{
		TriggerDespawn();
		OnDespawn();
	}

	public void Respawn()
	{
		TriggerRespawn();
		OnRespawn();
	}

	public virtual void OnDeath()
	{
	}

	public virtual void OnRespawn()
	{
	}

	public virtual void OnDespawn()
	{
	}

	public virtual void OnImpactHit(ImpactApplicationData oData)
	{
	}

	public virtual void OnImpactApply(ImpactApplicationData oData)
	{
	}

	public virtual void OnImpactEffectApply(ImpactEffectApplicationData oData)
	{
	}

	private void Awake()
	{
		GameMode.AddActorRegister(this);
	}

	private void Update()
	{
		TriggerTick(Time.deltaTime);
	}
}
