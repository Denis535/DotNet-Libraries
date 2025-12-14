#nullable enable
namespace System.TreeMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed partial class TreeMachine : ITreeMachine, IDisposable {

        private Lifecycle m_Lifecycle = Lifecycle.Alive;
        private INode? m_Root = null;

    }
    public sealed partial class TreeMachine {

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
        public INode? Root {
            get {
                Assert.Operation.NotDisposed( $"TreeMachine {this} must be non-disposed", !this.IsDisposed );
                return this.m_Root;
            }
            private set {
                Assert.Operation.NotDisposed( $"TreeMachine {this} must be non-disposed", !this.IsDisposed );
                if (value != null) {
                    Assert.Operation.Valid( $"TreeMachine {this} must have no {this.m_Root} root", this.m_Root == null );
                } else {
                    Assert.Operation.Valid( $"TreeMachine {this} must have root", this.m_Root != null );
                }
                this.m_Root = value;
            }
        }

    }
    public sealed partial class TreeMachine {

        // Constructor
        public TreeMachine() {
        }
        public void Dispose() {
            Assert.Operation.NotDisposed( $"TreeMachine {this} must be alive", this.m_Lifecycle == Lifecycle.Alive );
            this.m_Lifecycle = Lifecycle.Disposing;
            {
                Assert.Operation.Valid( $"TreeMachine {this} must have no {this.Root} root", this.Root == null || this.Root.IsDisposed );
            }
            this.m_Lifecycle = Lifecycle.Disposed;
        }

    }
    public sealed partial class TreeMachine {

        // SetRoot
        public void SetRoot(INode? root, object? argument, Action<INode, object?>? callback = null) {
            Assert.Operation.NotDisposed( $"TreeMachine {this} must be non-disposed", !this.IsDisposed );
            if (this.Root != null) {
                this.RemoveRoot( this.Root, argument, callback );
            }
            if (root != null) {
                this.AddRoot( root, argument );
            }
        }

        // AddRoot
        private void AddRoot(INode root, object? argument) {
            Assert.Argument.NotNull( $"Argument 'root' must be non-null", root != null );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must be non-disposed", !root.IsDisposed );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must have no {root.Owner} owner", root.Owner == null );
            Assert.Operation.NotDisposed( $"TreeMachine {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"TreeMachine {this} must have no {this.Root} root", this.Root == null );
            this.Root = root;
            this.Root.Attach( this, argument );
        }

        // RemoveRoot
        private void RemoveRoot(INode root, object? argument, Action<INode, object?>? callback = null) {
            Assert.Argument.NotNull( $"Argument 'root' must be non-null", root != null );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must be non-disposed", !root.IsDisposed );
            Assert.Argument.Valid( $"Argument 'root' ({root}) must have {this} owner", root.Owner == this );
            Assert.Operation.NotDisposed( $"TreeMachine {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"TreeMachine {this} must have {root} root", this.Root == root );
            this.Root.Detach( this, argument );
            this.Root = null;
            if (callback != null) {
                callback.Invoke( root, argument );
            } else {
                ((IDisposable) root).Dispose();
            }
        }

    }
}
