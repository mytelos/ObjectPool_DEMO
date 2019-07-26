using System.Collections.Generic;
using UnityEngine;

namespace Generics.ObjectPooling
{
    public class SpawnableObjectPool<T> where T : MonoBehaviour
    {
        public T Prefab;
        //public Transform SpawnParent;
        public Queue<T> Pool;
        public SpawnableObjectPool(/*Transform SpawnParent, */T prefab, int bakeCount, bool closeBakedObjects)
        {
            Pool = new Queue<T>(bakeCount);
            //this.SpawnParent = SpawnParent;
            Prefab = prefab;
            Bake(bakeCount, closeBakedObjects);
        }
        private void Bake(int v, bool closeObject)
        {
            for (int i = 0; i < v; ++i)
            {
                CreateObject(closeObject);
            }
        }
        public virtual void CreateObject(bool closeObject)
        {
            T p = UnityEngine.Object.Instantiate<T>(Prefab);//, SpawnParent);
            p.gameObject.SetActive(!closeObject);
            Pool.Enqueue(p);
        }
        public T GetNextObject(bool closeIfNewObjectCreated)
        {
            if (Pool.Count == 0)
                CreateObject(closeIfNewObjectCreated);
            T obj = Pool.Dequeue();
            return obj;
        }
        public virtual void ReturnObjectToPool(T obj, bool closeObjOnFinish)
        {
            obj.gameObject.SetActive(!closeObjOnFinish);
            Pool.Enqueue(obj);
        }
    }
}
