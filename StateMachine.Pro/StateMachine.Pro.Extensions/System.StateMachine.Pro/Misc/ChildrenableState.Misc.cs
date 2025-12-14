#nullable enable
namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class ChildrenableState {

        // IsDisposed
        bool IState.IsDisposing => this.IsDisposing;
        bool IState.IsDisposed => this.IsDisposed;

        // Owner
        object? IState.Owner => this.Owner;

        // Machine
        IStateMachine? IState.Machine => this.Machine;

        // Root
        bool IState.IsRoot => this.IsRoot;
        IState IState.Root => this.Root;

        // Parent
        IState? IState.Parent => this.Parent;
        IEnumerable<IState> IState.Ancestors => this.Ancestors;
        IEnumerable<IState> IState.AncestorsAndSelf => this.AncestorsAndSelf;

        // Activity
        Activity IState.Activity => this.Activity;

        // Dispose
        void IDisposable.Dispose() {
            this.Dispose();
        }

    }
    public partial class ChildrenableState {

        // Attach
        void IState.Attach(IStateMachine machine, object? argument) {
            this.Attach( machine, argument );
        }
        void IState.Attach(IState parent, object? argument) {
            this.Attach( parent, argument );
        }

        // Detach
        void IState.Detach(IStateMachine machine, object? argument) {
            this.Detach( machine, argument );
        }
        void IState.Detach(IState parent, object? argument) {
            this.Detach( parent, argument );
        }

        // Activate
        void IState.Activate(object? argument) {
            this.Activate( argument );
        }

        // Deactivate
        void IState.Deactivate(object? argument) {
            this.Deactivate( argument );
        }

    }
}
