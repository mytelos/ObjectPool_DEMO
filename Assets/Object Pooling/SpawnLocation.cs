using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics.ObjectPooling
{
    /// <summary>
    /// Attach this to a Transform in a Unity Scene, which you want to make a spawn location of a spesific Prefab Type
    /// </summary>
    public class SpawnLocation : MonoBehaviour
    {
        public CloneSource OriginalClone;
        private void Awake()
        {
            gameObject.name = "Spawn Location of " + OriginalClone.TypeName;
            OriginalClone.InitializePool();
        }
        public MonoBehaviour Spawn()
        {
            MonoBehaviour spawn = OriginalClone.GetNextClone();
            spawn.transform.position = transform.position;
            spawn.transform.SetParent(transform);
            return spawn;
        }
    } 
}