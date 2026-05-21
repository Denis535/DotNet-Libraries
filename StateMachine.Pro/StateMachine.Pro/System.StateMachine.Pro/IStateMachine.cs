#nullable enable
namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStateMachine : IDisposable {

        // IsDisposed
        public bool IsDisposing { get; }
        public bool IsDisposed { get; }

    }
    public interface IStateMachine<out T> : IStateMachine where T : IState<T> {

        // Root
        public T? Root { get; }

    }
}
