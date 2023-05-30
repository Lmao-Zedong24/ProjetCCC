using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class HandTagCollisionManager : Singleton<HandTagCollisionManager>
{
    // Start is called before the first frame update

    Dictionary<string, TagCollisionCallback> _tagCollisionFuncs;

    public delegate void TagCollisionCallback(Collision collision);

    protected override void Awake()
    {
        base.Awake();
        _tagCollisionFuncs = new Dictionary<string, TagCollisionCallback>();
    }

    public void AddTagCollisionFunc(string tag, TagCollisionCallback callback)
    {
        //if (!_tagCollisionFuncs.ContainsKey(tag))
        //    _tagCollisionFuncs.Add(tag, new List<TagCollisionCallback>());

        if (!_tagCollisionFuncs.ContainsKey(tag))
            _tagCollisionFuncs[tag] = callback;
        else
            _tagCollisionFuncs[tag] += callback;
    }

    public void RemoveTagCollisionFunc(string tag)
    {
        _tagCollisionFuncs.Remove(tag);
    }

    public void InvokeTagCollisionFunc(Collision collision)
    {
        if (_tagCollisionFuncs.TryGetValue(collision.transform.tag, out var callback))
            callback(collision);
    }
}
