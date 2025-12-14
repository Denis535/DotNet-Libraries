#nullable enable
namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class StateMachine {

        // IsDisposed
        bool IStateMachine.IsDisposing => this.IsDisposing;
        bool IStateMachine.IsDisposed => this.IsDisposed;

        // Root
        IState? IStateMachine.Root => this.Root;

        // Dispose
        void IDisposable.Dispose() {
            this.Dispose();
        }

    }
}
