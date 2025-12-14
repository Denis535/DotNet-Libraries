#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class EntityBase2 : EntityBase {

        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed( $"Entity {this} must be non-disposed", !this.IsDisposed );
                return IDependencyProvider.Instance;
            }
        }

        public EntityBase2() {
        }
        private protected override void OnDisposeInternal() {
            base.OnDisposeInternal();
        }

    }
}
