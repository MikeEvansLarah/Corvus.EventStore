﻿// <copyright file="SerializedEvent.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus2.EventStore.Core
{
    using System;

    /// <summary>
    /// Represents an event serialized to a UTF8-encoded text array.
    /// </summary>
    public readonly struct SerializedEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializedEvent"/> struct.
        /// </summary>
        /// <param name="aggregateId">The Id of the aggregate to which this event is applied.</param>
        /// <param name="eventType">The <see cref="EventType"/>.</param>
        /// <param name="sequenceNumber">The <see cref="SequenceNumber"/>.</param>
        /// <param name="timestamp">The <see cref="Timestamp"/>.</param>
        /// <param name="partitionKey">The <see cref="PartitionKey"/>.</param>
        /// <param name="utf8TextPayload">The <see cref="Utf8TextPayload"/>.</param>
        public SerializedEvent(
            string aggregateId,
            string eventType,
            long sequenceNumber,
            long timestamp,
            string partitionKey,
            ReadOnlyMemory<byte> utf8TextPayload)
        {
            this.AggregateId = aggregateId;
            this.EventType = eventType;
            this.SequenceNumber = sequenceNumber;
            this.Timestamp = timestamp;
            this.PartitionKey = partitionKey;
            this.Utf8TextPayload = utf8TextPayload;
        }

        /// <summary>
        /// Gets the Id of the aggregate to which this event is applied.
        /// </summary>
        public string AggregateId { get; }

        /// <summary>
        /// Gets the unique name for the type of event that this data represents.
        /// </summary>
        /// <remarks>
        /// It is recommended that some type of namespaced name is used, ideally with a scheme that provides for a
        /// version number.
        /// </remarks>
        public string EventType { get; }

        /// <summary>
        /// Gets the partition key for the event.
        /// </summary>
        public string PartitionKey { get; }

        /// <summary>
        /// Gets the nominal wall clock timestamp for the event as determined by the creator of the event.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the sequence number for the event.
        /// </summary>
        /// <remarks>
        /// This is a monotonically incrementing value for the aggregate to which the event belongs.</remarks>
        public long SequenceNumber { get; }

        /// <summary>
        /// Gets the payload data for the event.
        /// </summary>
        public ReadOnlyMemory<byte> Utf8TextPayload { get; }
    }
}
