using UnityEngine;
using System;
using System.Collections.Generic;

public class EventLog<T>
{
    private List<T> logEntries = new List<T>();

    // Event to notify when a new entry is added to the log
    public event Action<T> OnEntryAdded;

    public void LogEvent(T eventEntry)
    {
        logEntries.Add(eventEntry);

        // Notify subscribers that a new entry has been added
        OnEntryAdded?.Invoke(eventEntry);
    }

    public void ClearLog()
    {
        logEntries.Clear();
    }

    public void DisplayLog()
    {
        foreach (T entry in logEntries)
        {
            Debug.Log(entry.ToString());
        }
    }
}