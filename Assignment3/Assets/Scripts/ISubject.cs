/*
 * Kyle Manning
 * ISubject.cs
 * Assignment 3
 * Interface to be implemented by the subject in the scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void RegisterObserver(IObserver obs);

    void RemoveObserver(IObserver obs);

    void NotifyObservers();
}
