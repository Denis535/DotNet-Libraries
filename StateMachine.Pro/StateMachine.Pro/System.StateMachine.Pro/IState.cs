#nullable enable
namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public partial interface IState : IDisposable {

        // IsDisposed
        public bool IsDisposing { get; }
        public bool IsDisposed { get; }

        // Owner
        public object? Owner { get; }

        // Machine
        public IStateMachine? Machine { get; }

        // Root
        [MemberNotNullWhen( false, nameof( Parent ) )] public bool IsRoot { get; }
        public IState Root { get; }

        // Parent
        public IState? Parent { get; }
        public IEnumerable<IState> Ancestors { get; }
        public IEnumerable<IState> AncestorsAndSelf { get; }

        // Activity
        public Activity Activity { get; }

    }
    public partial interface IState {

        // Attach
        protected internal void Attach(IStateMachine machine, object? argument);
        protected internal void Attach(IState parent, object? argument);

        // Detach
        protected internal void Detach(IStateMachine machine, object? argument);
        protected internal void Detach(IState parent, object? argument);

        // Activate
        protected internal void Activate(object? argument);

        // Deactivate
        protected internal void Deactivate(object? argument);

    }
}
