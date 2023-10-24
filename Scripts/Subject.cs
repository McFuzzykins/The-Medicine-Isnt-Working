using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private readonly ArrayList observers = new ArrayList();

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.Notify(this);
        }
    }
}
