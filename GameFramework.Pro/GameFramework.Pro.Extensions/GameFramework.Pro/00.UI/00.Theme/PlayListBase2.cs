#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class PlayListBase2 : PlayListBase {

        protected IDependencyProvider Provider {
            get {
                Assert.Operation.Valid( $"PlayList {this} must be non-disposed", !this.IsDisposed );
                return IDependencyProvider.Instance;
            }
        }

        public PlayListBase2() {
        }

    }
}
