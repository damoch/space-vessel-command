﻿using Assets.Scripts.Game.Controllers.Abstractions;

namespace Assets.Scripts.Game.CombatEngine.Abstractions
{
    public interface IMovableEntity
    {
        void OnTargetReached();
        IGameController GameController { get; }
    }
}
