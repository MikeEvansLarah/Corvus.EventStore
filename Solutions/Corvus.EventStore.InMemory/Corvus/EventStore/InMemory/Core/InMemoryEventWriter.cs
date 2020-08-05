﻿// <copyright file="InMemoryEventWriter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus2.EventStore.InMemory.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Corvus2.EventStore.Core;
    using Corvus2.EventStore.InMemory.Core.Internal;

    /// <summary>
    /// In-memory implementation of <see cref="IEventWriter"/>.
    /// </summary>
    public readonly struct InMemoryEventWriter : IEventWriter
    {
        private readonly InMemoryEventStore store;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryEventWriter"/> struct.
        /// </summary>
        /// <param name="store">The underlying store.</param>
        public InMemoryEventWriter(InMemoryEventStore store)
        {
            this.store = store;
        }

        /// <inheritdoc/>
        public Task WriteAsync(in SerializedEvent @event)
        {
            return this.store.WriteAsync(@event);
        }

        /// <inheritdoc/>
        public Task WriteBatchAsync(in IEnumerable<SerializedEvent> events)
        {
            return this.store.WriteAsync(events);
        }
    }
}
