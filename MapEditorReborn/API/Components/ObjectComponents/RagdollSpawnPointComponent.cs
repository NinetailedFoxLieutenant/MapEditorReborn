﻿namespace MapEditorReborn.API
{
    using System.Collections.Generic;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using UnityEngine;

    /// <summary>
    /// Component added to RagdollSpawnPointObject. Is is used for easier idendification of the object and it's variables.
    /// </summary>
    public class RagdollSpawnPointComponent : MapEditorObject
    {
        /// <summary>
        /// Initializes the <see cref="RagdollSpawnPointComponent"/>.
        /// </summary>
        /// <param name="ragdollSpawnPoint">The <see cref="RagdollSpawnPointObject"/> to instantiate.</param>
        /// <returns>Instance of this compoment.</returns>
        public RagdollSpawnPointComponent Init(RagdollSpawnPointObject ragdollSpawnPoint)
        {
            Base = ragdollSpawnPoint;

            ForcedRoomType = ragdollSpawnPoint.RoomType != RoomType.Unknown ? ragdollSpawnPoint.RoomType : FindRoom().Type;
            UpdateObject();

            return this;
        }

        /// <summary>
        /// The config-base of the object containing all of it's properties.
        /// </summary>
        public RagdollSpawnPointObject Base;

        /// <inheritdoc cref="MapEditorObject.UpdateObject()"/>
        public override void UpdateObject()
        {
            OnDestroy();

            if (Handler.CurrentLoadedMap != null && string.IsNullOrEmpty(Base.Name) && Handler.CurrentLoadedMap.RagdollRoleNames.TryGetValue(Base.RoleType, out List<string> ragdollNames))
            {
                Base.Name = ragdollNames[Random.Range(0, ragdollNames.Count)];
            }

            attachedRagdoll = Ragdoll.Spawn(Base.RoleType, Base.DamageType.ConvertToDamageType(), Base.Name, transform.position, transform.rotation, scp096Death: false);
        }

        private void OnDestroy() => attachedRagdoll?.Delete();

        private Ragdoll attachedRagdoll = null;
    }
}