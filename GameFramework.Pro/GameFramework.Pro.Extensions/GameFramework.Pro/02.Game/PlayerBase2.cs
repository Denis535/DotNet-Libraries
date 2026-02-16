#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class PlayerBase2 : PlayerBase {
        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed($"Player {this} must be non-disposed", !this.IsDisposed);
                return IDependencyProvider.Instance;
            }
        }

        public PlayerBase2() {
        }

        private protected override void OnDisposeInternal() {
            base.OnDisposeInternal();
        }
    }
}
