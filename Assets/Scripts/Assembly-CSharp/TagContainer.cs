using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class TagContainer
{
	[CompilerGenerated]
	private sealed class _003CGetTagQuantity_003Ec__AnonStorey29
	{
		internal string sTag;

		internal bool _003C_003Em__1E(string o)
		{
			return o == sTag;
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveAllOfTag_003Ec__AnonStorey2A
	{
		internal string sTag;

		internal bool _003C_003Em__1F(string o)
		{
			return o == sTag;
		}
	}

	[SerializeField]
	private List<string> _tags = new List<string>();

	public List<string> tags
	{
		get
		{
			return _tags;
		}
	}

	public bool ContainsTag(string sTag)
	{
		return _tags.Contains(sTag);
	}

	public int GetTagQuantity(string sTag)
	{
		_003CGetTagQuantity_003Ec__AnonStorey29 _003CGetTagQuantity_003Ec__AnonStorey = new _003CGetTagQuantity_003Ec__AnonStorey29();
		_003CGetTagQuantity_003Ec__AnonStorey.sTag = sTag;
		return _tags.FindAll(_003CGetTagQuantity_003Ec__AnonStorey._003C_003Em__1E).Count;
	}

	public bool AnyTagsMatch(TagContainer oContainer)
	{
		foreach (string tag in oContainer.tags)
		{
			if (ContainsTag(tag))
			{
				return true;
			}
		}
		return false;
	}

	public bool AllTagsMatch(TagContainer oContainer)
	{
		foreach (string tag in oContainer.tags)
		{
			if (!ContainsTag(tag))
			{
				return false;
			}
		}
		return true;
	}

	public bool NoTagsMatch(TagContainer oContainer)
	{
		foreach (string tag in oContainer.tags)
		{
			if (ContainsTag(tag))
			{
				return false;
			}
		}
		return true;
	}

	public void AddTag(string sTag)
	{
		_tags.Add(sTag);
	}

	public void AddUniqueTag(string sTag)
	{
		if (!_tags.Contains(sTag))
		{
			_tags.Add(sTag);
		}
	}

	public void ClearTags()
	{
		_tags.Clear();
	}

	public void RemoveTag(string sTag)
	{
		_tags.Remove(sTag);
	}

	public void RemoveAllOfTag(string sTag)
	{
		_003CRemoveAllOfTag_003Ec__AnonStorey2A _003CRemoveAllOfTag_003Ec__AnonStorey2A = new _003CRemoveAllOfTag_003Ec__AnonStorey2A();
		_003CRemoveAllOfTag_003Ec__AnonStorey2A.sTag = sTag;
		_tags.RemoveAll(_003CRemoveAllOfTag_003Ec__AnonStorey2A._003C_003Em__1F);
	}

	public void AppendTagsFromContainer(TagContainer oContainer)
	{
		for (int i = 0; i < oContainer.tags.Count; i++)
		{
			AddTag(oContainer.tags[i]);
		}
	}

	public void RemoveTagsFromContainer(TagContainer oContainer)
	{
		for (int i = 0; i < oContainer.tags.Count; i++)
		{
			RemoveAllOfTag(oContainer.tags[i]);
		}
	}
}
