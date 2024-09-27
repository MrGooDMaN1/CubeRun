using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    private static EventBus _instance;
    public static EventBus Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new EventBus();
            }

            return _instance;
        }
    }

    private EventBus()
    {
        _events = new();
    }

    private readonly Dictionary<string, List<object>> _events = new Dictionary<string, List<object>>();

    public void Subscribe<T>(Action<T> action)
    {
        string key = typeof(T).Name;
        if (_events.ContainsKey(key))
        {
            _events[key].Add(action);
        }
        else
        {
            _events.Add(key, new List<object>() { action });
        }
    }

    public void Unsubscribe<T>(Action<T> action)
    {
        string key = typeof(T).Name;
        if (_events.ContainsKey(key))
        {
            _events[key].Remove(action);
        }
        else
        {
            Debug.LogError($"Attempt to unsubscribe from an unsubscribed {key} method");
        }
    }

    public void Invoke<T>(T signal)
    {
        string key = typeof(T).Name;
        if (_events.ContainsKey(key))
        {
            for(int i = 0; i < _events[key].Count; i++)
            {
                Action<T> callback = _events[key][i] as Action<T>;
                callback.Invoke(signal);
            }
        }
    }
}
