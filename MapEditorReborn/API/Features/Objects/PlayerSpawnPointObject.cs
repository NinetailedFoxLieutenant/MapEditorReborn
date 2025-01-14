﻿namespace MapEditorReborn.API.Features.Objects
{
    using System;
    using Enums;
    using Exiled.API.Enums;
    using UnityEngine;

    /// <summary>
    /// A tool used to spawn and save PlayerSpawnPoints to a file.
    /// </summary>
    [Serializable]
    public class PlayerSpawnPointObject
    {
        /// <summary>
        /// Gets or sets the <see cref="PlayerSpawnPointObject"/>'s <see cref="Enums.SpawnableTeam"/>.
        /// </summary>
        public SpawnableTeam SpawnableTeam { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PlayerSpawnPointObject"/>'s position.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Exiled.API.Enums.RoomType"/> which is used to determine the spawn position and rotation of the <see cref="PlayerSpawnPointObject"/>.
        /// </summary>
        public RoomType RoomType { get; set; }
    }
}
