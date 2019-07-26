using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics.ObjectPooling
{

    /// <summary>
    /// Attach to a Prefab which you want to make a source for cloning in the pooling system
    /// </summary>
    public class CloneSource : Clone
    {
        public int TypeId;
        public string TypeName;
        public SpawnableObjectPool<Clone> ClonePool;
        public bool PoolInitialized = false;
        [Space(10)]
        [Header("Baking")]
        public int BakeCount;
        public bool CloseBakedObjects;
        public void InitializePool()
        {
            if (!PoolInitialized)
            {
                ClonePool = new SpawnableObjectPool<Clone>(this, BakeCount, CloseBakedObjects);
                PoolInitialized = true;
            }
        }
        public void DestroyPool()
        {
            ClonePool = null;
        }
        public Clone GetNextClone()
        {
            Clone clone = ClonePool.GetNextObject(CloseBakedObjects);
            clone.Initialize(ClonePool);
            return clone;
        }
    }
}