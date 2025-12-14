#nullable enable
namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStateMachine {

        // IsDisposed
        public bool IsDisposing { get; }
        public bool IsDisposed { get; }

        // Root
        public IState? Root { get; }

    }
}
