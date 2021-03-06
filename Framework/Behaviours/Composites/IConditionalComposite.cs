﻿namespace Chinchillada.BehaviourSelections.BehaviorTree
{
    /// <summary>
    /// Interface for <see cref="Composite"/> behaviors that separate conditional child behaviors from action child behaviors.
    /// </summary>
    public interface IConditionalComposite
    {
        /// <summary>
        /// Adds a new condition.
        /// </summary>
        /// <param name="condition">The condition to add.</param>
        void AddCondition(IBehavior condition);

        /// <summary>
        /// Adds a new action.
        /// </summary>
        /// <param name="action">The action to add.</param>
        void AddAction(IBehavior action);
    }
}