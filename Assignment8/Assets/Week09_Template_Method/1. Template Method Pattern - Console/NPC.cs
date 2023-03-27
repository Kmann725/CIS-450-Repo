using UnityEngine;
using System.Collections;

namespace TemplateMethodPatternConsole
{
    public abstract class NPC
    {
        public void Interact()
        {
            Move();

            Speak();

            if (IsAggro())
            {
                Attack();
            }
        }

        //This is a concrete method.
        //Concrete methods are shared by all subclasses.
        void Move()
        {
            Debug.Log("The " + this.GetType() + " moves towards you.");
        }

        // These are abstract methods.
        // Abstract methods must be overridden by each subclass.
        public abstract void Speak();

        public abstract void Attack();

        //This is a hook.
        //Subclasses can override hooks,
        //but it is optional.
        public virtual bool IsAggro()
        {
            return false;
        }


    }
}