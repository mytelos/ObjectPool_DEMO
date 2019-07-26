using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics.ObjectPooling
{
    /// <summary>
    /// Clone that is being cloned from CloneSource
    /// </summary>
    public class Clone : MonoBehaviour
    {
        public SpawnableObjectPool<Clone> PoolToReturn;
        public delegate void ReturnToPool(Clone obj, bool closeObjOnFinish);
        public ReturnToPool MyReturnToPool;
        public void Initialize(SpawnableObjectPool<Clone> PoolToReturn)
        {
            this.PoolToReturn = PoolToReturn;
            MyReturnToPool = new ReturnToPool(PoolToReturn.ReturnObjectToPool);
        }
        public void ReturnClone()
        {
            MyReturnToPool.Invoke(this, true);
        }
    }
}