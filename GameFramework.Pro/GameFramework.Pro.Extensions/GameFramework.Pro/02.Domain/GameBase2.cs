#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class GameBase2 : GameBase {

        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed( $"Game {this} must be non-disposed", !this.IsDisposed );
                return IDependencyProvider.Instance;
            }
        }

        public GameBase2() {
        }
        private protected override void OnDisposeInternal() {
            base.OnDisposeInternal();
        }

    }
}
