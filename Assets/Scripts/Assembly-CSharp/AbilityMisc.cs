using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sonic;
using UnityEngine;

public class AbilityMisc : MonoBehaviour
{
	private Character _character;

	private CharacterMotor _motor;

	private readonly List<Collider> rings = new List<Collider>();

	private readonly List<SceneRing> sceneRings = new List<SceneRing>();

	private readonly List<Rigidbody> ringPhysics = new List<Rigidbody>();

	private FloatingPlatforms box;

	public float minRingMagSpeed = 1f;

	public float ringRangeMultiplier = 0.07f;

	public float ringSpeedMultiplier = 1.12f;

	public float minRingRange = 0.5f;

	[CompilerGenerated]
	private static Func<Collider, FloatingPlatforms> _003C_003Ef__am_0024cacheA;

	[CompilerGenerated]
	private static Func<FloatingPlatforms, bool> _003C_003Ef__am_0024cacheB;

	private Character character
	{
		get
		{
			return (!_character) ? (_character = GetComponent<Character>()) : _character;
		}
	}

	private CharacterMotor motor
	{
		get
		{
			return (!_motor) ? (_motor = GetComponent<CharacterMotor>()) : _motor;
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
		Vector3 position = character.transform.position;
		Collider[] source = Physics.OverlapBox(position - new Vector3(0f, 0f, 0f), new Vector3(0.15f, 0.1f, 0.15f));
		if (_003C_003Ef__am_0024cacheA == null)
		{
			_003C_003Ef__am_0024cacheA = _003CUpdate_003Em__26;
		}
		IEnumerable<FloatingPlatforms> source2 = source.Select(_003C_003Ef__am_0024cacheA);
		if (_003C_003Ef__am_0024cacheB == null)
		{
			_003C_003Ef__am_0024cacheB = _003CUpdate_003Em__27;
		}
		FloatingPlatforms floatingPlatforms = source2.FirstOrDefault(_003C_003Ef__am_0024cacheB);
		if (floatingPlatforms == null && box != null)
		{
			box.Activated = false;
			box = null;
		}
		if (floatingPlatforms != null && (box == null || floatingPlatforms.gameObject != box.gameObject))
		{
			if (box != null)
			{
				box.Activated = false;
			}
			box = floatingPlatforms;
		}
		if (box != null)
		{
			box.Activated = true;
		}
		if (!motor || ((bool)motor.state && (motor.state is CharacterStateDamage || motor.state is CharacterStateDead)))
		{
			return;
		}
		float magnitude = character.velocity.magnitude;
		if (character.velocity.magnitude >= minRingMagSpeed)
		{
			Collider[] array = Physics.OverlapSphere(position, minRingRange + character.velocity.magnitude * ringRangeMultiplier);
			if (array != null)
			{
				List<Collider> list = array.Where(_003CUpdate_003Em__28).ToList();
				foreach (Collider item in list)
				{
					rings.Add(item);
					item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
					sceneRings.Add(item.GetComponent<SceneRing>());
					ringPhysics.Add(item.GetComponent<Rigidbody>());
				}
			}
		}
		for (int i = 0; i < rings.Count; i++)
		{
			Collider collider = rings[i];
			SceneRing sceneRing = sceneRings[i];
			Rigidbody rigidbody = ringPhysics[i];
			if (!sceneRing.active || !sceneRing.canPickUp || collider == null || sceneRing == null || rigidbody == null)
			{
				rings.Remove(collider);
				sceneRings.Remove(sceneRing);
				ringPhysics.Remove(rigidbody);
				i--;
				continue;
			}
			Vector3 position2 = collider.transform.position;
			Vector3 vector = position - position2;
			if (vector.magnitude < magnitude * ringSpeedMultiplier * Time.deltaTime)
			{
				rigidbody.velocity = Vector3.zero;
				collider.transform.position = position;
			}
			else
			{
				Vector3 normalized = vector.normalized;
				rigidbody.velocity = normalized * Mathf.Max(magnitude * ringSpeedMultiplier, minRingMagSpeed);
			}
		}
	}

	[CompilerGenerated]
	private static FloatingPlatforms _003CUpdate_003Em__26(Collider p)
	{
		return p.gameObject.GetComponentInParent<FloatingPlatforms>();
	}

	[CompilerGenerated]
	private static bool _003CUpdate_003Em__27(FloatingPlatforms p)
	{
		return p != null;
	}

	[CompilerGenerated]
	private bool _003CUpdate_003Em__28(Collider p)
	{
		return !rings.Contains(p) && p.gameObject.GetComponent<SceneRing>() != null;
	}
}
