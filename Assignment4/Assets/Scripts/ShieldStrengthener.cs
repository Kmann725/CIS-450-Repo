/*
 * Kyle Manning
 * ShieldStrengthener.cs
 * Assignment 4
 * Shield decorator which adds two health to a shield
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldStrengthener : ShieldDecorator
{
    private int healthBoost = 2;

    public ShieldStrengthener(ShieldAbstract shield)
    {
        this.shield = shield;
        this.shield.health += healthBoost;
    }

    public override int TakeDamage()
    {
        this.shield.health--;
        return this.shield.health;
    }
}
