using UnityEngine;

/// <summary>
/// Scene singleton template, only valid in the current scene, it will be destroyed when switching scenes
/// </summary>
/// <typeparam name="T">Must be Component</typeparam>
public class Singleton<T>: MonoBehaviour where T: Component
{
    protected static T _Instance;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                // If there is no instance, find all objects of this type
                _Instance = FindObjectOfType(typeof(T)) as T;
                if (_Instance == null)
                {
                    // If not found, create a new one
                    GameObject obj = new GameObject(typeof(T).Name);
                    // The object is not visible and will not be saved
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    // force conversion to T 
                    _Instance = obj.AddComponent(typeof(T)) as T;
                }
            }
            return _Instance;
        }
    }

    protected virtual void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _Instance = this as T;
        }
    }

    private void OnDestroy()
    {
        _Instance = null;
    }
}