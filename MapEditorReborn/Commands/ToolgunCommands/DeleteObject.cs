﻿namespace MapEditorReborn.Commands
{
    using System;
    using API.Features.Components;
    using CommandSystem;
    using Events.Handlers.Internal;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;

    /// <summary>
    /// Command used for deleting the objects.
    /// </summary>
    public class DeleteObject : ICommand
    {
        /// <inheritdoc/>
        public string Command => "delete";

        /// <inheritdoc/>
        public string[] Aliases => new string[] { "del", "remove", "rm" };

        /// <inheritdoc/>
        public string Description => "Deletes the object which you are looking at.";

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"mpr.{Command}"))
            {
                response = $"You don't have permission to execute this command. Required permission: mpr.{Command}";
                return false;
            }

            Player player = Player.Get(sender);

            if (ToolGunHandler.TryGetMapObject(player, out MapEditorObject mapObject))
            {
                ToolGunHandler.DeleteObject(player, mapObject);
                response = "You've successfully deleted the object!";

                return true;
            }
            else
            {
                response = "You aren't looking at any Map Editor object!";
                return false;
            }
        }
    }
}
