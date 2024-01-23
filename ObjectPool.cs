using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> objectQueue = new Queue<T>();
    private T prefab;
    private Transform parentTransform;

    public ObjectPool(T prefab, int initialSize = 10, Transform parentTransform = null)
    {
        this.prefab = prefab;
        this.parentTransform = parentTransform;

        for (int i = 0; i < initialSize; i++)
        {
            T obj = CreateObject();
            objectQueue.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        if (objectQueue.Count == 0)
        {
            T newObj = CreateObject();
            return newObj;
        }

        T obj = objectQueue.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        objectQueue.Enqueue(obj);
    }

    private T CreateObject()
    {
        T obj = Object.Instantiate(prefab, parentTransform);
        obj.gameObject.SetActive(false);
        return obj;
    }
}