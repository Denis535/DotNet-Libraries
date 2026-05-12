#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class GameBase : DisposableBase {
        public GameBase() {
        }

        private protected override void OnDisposeInternal() {
        }
    }

    public abstract class PlayerBase : DisposableBase {
        public PlayerBase() {
        }

        private protected override void OnDisposeInternal() {
        }
    }

    public abstract class WorldBase : DisposableBase {
        public WorldBase() {
        }

        private protected override void OnDisposeInternal() {
        }
    }

    public abstract class EntityBase : DisposableBase {
        public EntityBase() {
        }

        private protected override void OnDisposeInternal() {
        }
    }
}
