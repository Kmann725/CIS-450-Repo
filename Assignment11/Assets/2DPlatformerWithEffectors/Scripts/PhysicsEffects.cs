using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsEffects
{

    public static Rigidbody2D AddForceUp(Rigidbody2D rb, float forceAmount)
    {
        rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);
        return rb;
    }
    public static Rigidbody2D AddForceLeft(Rigidbody2D rb, float forceAmount)
    {
        rb.AddForce(Vector2.left * forceAmount, ForceMode2D.Impulse);
        return rb;
    }
    public static Rigidbody2D AddForceRight(Rigidbody2D rb, float forceAmount)
    {
        rb.AddForce(Vector2.left * forceAmount, ForceMode2D.Impulse);
        return rb;
    }

}
