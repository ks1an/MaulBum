using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Core : MonoBehaviour
{
    private readonly List<CoreComponent> _coreComponents = new List<CoreComponent>();

    private void Awake()
    {

    }

    public void LogicUpdate()
    {
        foreach (CoreComponent component in _coreComponents)
        {
            component.LogicUpdate();
        }
    }

    public void AddComponent(CoreComponent component)
    {
        if (!_coreComponents.Contains(component))
        {
            _coreComponents.Add(component);
        }
    }

    public T GetCoreComponent<T>() where T : CoreComponent
    {
        var comp = _coreComponents.OfType<T>().FirstOrDefault();
        if (comp) return comp;

        comp = GetComponentInChildren<T>();
        if (comp) return comp;

        Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}");
        return null;
    }
}
