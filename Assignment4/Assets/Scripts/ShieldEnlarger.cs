/*
 * Kyle Manning
 * ShieldEnlarger.cs
 * Assignment 4
 * Shield decorator which doubles the amount of health a shield has
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnlarger : ShieldDecorator
{
    private int healthBoost = 2;

    public ShieldEnlarger(ShieldAbstract shield, int health)
    {
        this.shield = shield;
        this.shield.health = health * healthBoost;
    }

    public override int TakeDamage()
    {
        this.shield.health--;
        return this.shield.health;
    }
}
