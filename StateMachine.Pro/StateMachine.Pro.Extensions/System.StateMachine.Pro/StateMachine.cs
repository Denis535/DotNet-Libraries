#nullable enable
namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed partial class StateMachine : IStateMachine, IDisposable {

        private Lifecycle m_Lifecycle = Lifecycle.Alive;
        private IState? m_Root = null;

    }
    public sealed partial class StateMachine {

        // IsDisposed
        public bool IsDisposing {
            get {
                return this.m_Lifecycle == Lifecycle.Disposing;
            }
        }
        public bool IsDisposed {
            get {
                return this.m_Lifecycle == Lifecycle.Disposed;
            }
        }

        // Root
        public IState? Root {
            get {
                Assert.Operation.NotDisposed( $"StateMachine {this} must be non-disposed", !this.IsDisposed );
                return this.m_Root;
            }
            private set {
                Assert.Operation.NotDisposed( $"StateMachine {this} must be non-disposed", !this.IsDisposed );
                if (value != null) {
                    Assert.Operation.Valid( $"StateMachine {this} must have no {this.m_Root} root", this.m_Root == null );
                } else {
                    Assert.Operation.Valid( $"StateMachine {this} must have root", this.m_Root != null );
                }
                this.m_Root = value;
            }
        }

    }
    public sealed partial class StateMachine {

        // Constructor
        public StateMachine() {
        }
        public void Dispose() {
            Assert.Operation.NotDisposed( $"StateMachine {this} must be alive", this.m_Lifecycle == Lifecycle.Alive );
            this.m_Lifecycle = Lifecycle.Disposing;
            {
                Assert.Operation.Valid( $"StateMachine {this} must have no {this.Root} root", this.Root == null || this.Root.IsDisposed );
            }
            this.m_Lifecycle = Lifecycle.Disposed;
        }

    }
    public sealed partial class StateMachine {

        // SetRoot
        public void SetRoot(IState? root, object? argument, Action<IState, object?>? callback = null) {
            Assert.Operation.NotDisposed( $"StateMachine {this} must be non-disposed", !this.IsDisposed );
            if (this.Root != null) {
                this.RemoveRoot( this.Root, argument, callback );
            }
            if (root != null) {
                this.AddRoot( root, argument );
            }
        }

        // AddRoot
        private void AddRoot(IState root, object? argument) {
            Assert.Argument.NotNull( $"Argument 'root' must be non-null", root != null );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must be non-disposed", !root.IsDisposed );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must have no {root.Owner} owner", root.Owner == null );
            Assert.Operation.NotDisposed( $"StateMachine {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"StateMachine {this} must have no {this.Root} root", this.Root == null );
            this.Root = root;
            this.Root.Attach( this, argument );
        }

        // RemoveRoot
        private void RemoveRoot(IState root, object? argument, Action<IState, object?>? callback = null) {
            Assert.Argument.NotNull( $"Argument 'root' must be non-null", root != null );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must be non-disposed", !root.IsDisposed );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must have {this} owner", root.Owner == this );
            Assert.Operation.NotDisposed( $"StateMachine {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"StateMachine {this} must have {root} root", this.Root == root );
            this.Root.Detach( this, argument );
            this.Root = null;
            if (callback != null) {
                callback.Invoke( root, argument );
            } else {
                root.Dispose();
            }
        }

    }
}
