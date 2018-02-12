﻿using System.Collections.Generic;
using UnityEngine;

namespace Chinchillada.BehaviourSelections.BehaviourTree.Builder
{
    /// <summary>
    /// Base abstract class for builders of <see cref="IConditionalComposite"/> behaviours.
    /// </summary>
    [ExecuteInEditMode]
    internal abstract class ConditionalCompositeBuilder : CompositeBuilder
    {
        /// <summary>
        /// Parent object for condition behaviours.
        /// </summary>
        [SerializeField] private GameObject _conditionsParent;

        /// <summary>
        /// Parent object for action behaviours.
        /// </summary>
        [SerializeField] private GameObject _actionsParent;

        /// <summary>
        /// Called when this object first awakens.
        /// Ensures the child object groupers exist.
        /// </summary>
        protected virtual void Awake()
        {
            if (_conditionsParent == null)
                _conditionsParent = CreateEmptyChild("Conditions");

            if(_actionsParent == null)
                _actionsParent = CreateEmptyChild("Actions");
        }

        /// <summary>
        /// Creates an empty child with the given <paramref name="childName"/>.
        /// </summary>
        /// <param name="childName">Name for the child.</param>
        /// <returns>The child.</returns>
        private GameObject CreateEmptyChild(string childName)
        {
            GameObject child = new GameObject(childName);
            child.transform.parent = transform;

            return child;
        }

        /// <inheritdoc />
        protected override void InitializeChildren(Composite composite, BehaviourTree tree)
        {
            //Cast to conditional.
            IConditionalComposite conditionalComposite = (IConditionalComposite) composite;

            //Build children.
            IEnumerable<IBehaviour> conditions = BuildChildren(_conditionsParent.transform, tree);
            IEnumerable<IBehaviour> actions = BuildChildren(_actionsParent.transform, tree);

            //Add children.
            foreach (IBehaviour condition in conditions)
                conditionalComposite.AddCondition(condition);
            foreach (IBehaviour action in actions)
                conditionalComposite.AddAction(action);
        }
    }
}