/*
 * Kyle Manning
 * ShieldAbstract.cs
 * Assignment 4
 * Abstract class for the shield and decorators
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShieldAbstract : MonoBehaviour
{
    public int health;

    public abstract int TakeDamage();
}
