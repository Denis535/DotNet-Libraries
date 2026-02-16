#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class PlayListBase2 : PlayListBase {
        protected IDependencyProvider Provider {
            get {
                Assert.Operation.Valid($"PlayList {this} must be non-disposed", !this.State.IsDisposed);
                return IDependencyProvider.Instance;
            }
        }

        public PlayListBase2() {
        }

        private protected override void OnDisposeInternal() {
            base.OnDisposeInternal();
        }
    }
}
