﻿using System;

namespace Chinchillada.BehaviourSelections.BehaviourTree
{
    public interface IBehaviour
    {
        event Action<IBehaviour, Behaviour.Status> Terminated;

        BehaviourTree Tree { get; }

        /// <summary>
        /// The current status.
        /// </summary>
        Behaviour.Status CurrentStatus { get; }

        /// <summary>
        /// If the behaviour is terminated or not.
        /// </summary>
        bool IsTerminated { get; }

        /// <summary>
        /// Updates the behavour.
        /// </summary>
        /// <returns>The status after the update.</returns>
        Behaviour.Status Tick();

        /// <summary>
        /// Terminate the behavior.
        /// </summary>
        void Terminate();

        /// <summary>
        /// Terminate the behaviour with the given status.
        /// </summary>
        /// <param name="status">The status to terminate with.</param>
        void Terminate(Behaviour.Status status);
    }
}