#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ApplicationBase : DisposableBase {
        public ApplicationBase() {
        }

        private protected override void OnDisposeInternal() {
        }
    }
}
