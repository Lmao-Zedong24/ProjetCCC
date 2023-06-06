using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class HandTagCollisionManager : Singleton<HandTagCollisionManager>
{
    // Start is called before the first frame update

    Dictionary<CallBackCondition, CollisionCallback> _collisionFuncs;

    public delegate void CollisionCallback(Collision collision);
    public delegate bool CallBackCondition(Collision collision);

    protected override void Awake()
    {
        base.Awake();
        _collisionFuncs = new Dictionary<CallBackCondition, CollisionCallback>();
    }

    public void AddCollisionFunc(CallBackCondition condition, CollisionCallback callback)
    {
        //if (!_tagCollisionFuncs.ContainsKey(tag))
        //    _tagCollisionFuncs.Add(tag, new List<TagCollisionCallback>());

        if (!_collisionFuncs.ContainsKey(condition))
            _collisionFuncs[condition] = callback;
        else
            _collisionFuncs[condition] += callback;
    }

    public void InvokeTagCollisionFunc(Collision collision)
    {
        foreach (var pair in _collisionFuncs)
        {
            if (pair.Key(collision))
                pair.Value(collision); 
        }
    }
}
