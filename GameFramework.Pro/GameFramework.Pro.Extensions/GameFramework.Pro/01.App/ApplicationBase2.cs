#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ApplicationBase2 : ApplicationBase {
        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed($"Application {this} must be non-disposed", !this.IsDisposed);
                return IDependencyProvider.Instance;
            }
        }

        public ApplicationBase2() {
        }

        private protected override void OnDisposeInternal() {
            base.OnDisposeInternal();
        }
    }
}
