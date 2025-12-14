#nullable enable
namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    public partial class State : IState, IDisposable {

        private Lifecycle m_Lifecycle = Lifecycle.Alive;
        private object? m_Owner = null;
        private Activity m_Activity = Activity.Inactive;

    }
    public partial class State {

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

        // Owner
        public object? Owner {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                return this.m_Owner;
            }
            private set {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                if (value != null) {
                    Assert.Operation.Valid( $"State {this} must have no {this.m_Owner} owner", this.m_Owner == null );
                    Assert.Operation.Valid( $"State {this} must have valid activity", this.Activity is Activity.Inactive );
                } else {
                    Assert.Operation.Valid( $"State {this} must have owner", this.m_Owner != null );
                    Assert.Operation.Valid( $"State {this} must have valid activity", this.Activity is Activity.Active or Activity.Inactive );
                }
                this.m_Owner = value;
            }
        }

        // Machine
        public IStateMachine? Machine {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                return (this.Owner as IStateMachine) ?? (this.Owner as IState)?.Machine;
            }
        }

        // Root
        [MemberNotNullWhen( false, nameof( Parent ) )]
        public bool IsRoot {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                return this.Parent == null;
            }
        }
        public IState Root {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                return this.Parent?.Root ?? this;
            }
        }

        // Parent
        public IState? Parent {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                return this.Owner as IState;
            }
        }
        public IEnumerable<IState> Ancestors {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                if (this.Parent != null) {
                    yield return this.Parent;
                    foreach (var i in this.Parent.Ancestors) yield return i;
                }
            }
        }
        public IEnumerable<IState> AncestorsAndSelf {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                return this.Ancestors.Prepend( this );
            }
        }

        // Activity
        public Activity Activity {
            get {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                return this.m_Activity;
            }
            private set {
                Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
                Assert.Operation.Valid( $"State {this} must have owner", this.Owner != null );
                Assert.Operation.Valid( $"State {this} must have valid activity", this.m_Activity != value );
                this.m_Activity = value;
            }
        }

    }
    public partial class State {

        // Constructor
        public State() {
        }
        public void Dispose() {
            Assert.Operation.NotDisposed( $"State {this} must be alive", this.m_Lifecycle == Lifecycle.Alive );
            this.m_Lifecycle = Lifecycle.Disposing;
            {
                this.OnDispose();
            }
            this.m_Lifecycle = Lifecycle.Disposed;
        }
        protected virtual void OnDispose() {
        }

    }
    public partial class State {

        // Attach
        private void Attach(IStateMachine machine, object? argument) {
            Assert.Argument.NotNull( $"Argument 'machine' must be non-null", machine != null );
            Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"State {this} must have no {this.Owner} owner", this.Owner == null );
            {
                this.Owner = machine;
                this.OnAttach( argument );
            }
            if (true) {
                this.Activate( argument );
            }
        }
        private void Attach(IState parent, object? argument) {
            Assert.Argument.NotNull( $"Argument 'parent' must be non-null", parent != null );
            Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"State {this} must have no {this.Owner} owner", this.Owner == null );
            {
                this.Owner = parent;
                this.OnAttach( argument );
            }
            if (parent.Activity == Activity.Active) {
                this.Activate( argument );
            }
        }

        // Detach
        private void Detach(IStateMachine machine, object? argument) {
            Assert.Argument.NotNull( $"Argument 'machine' must be non-null", machine != null );
            Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"State {this} must have {machine} owner", this.Owner == machine );
            if (true) {
                this.Deactivate( argument );
            }
            {
                this.OnDetach( argument );
                this.Owner = null;
            }
        }
        private void Detach(IState parent, object? argument) {
            Assert.Argument.NotNull( $"Argument 'parent' must be non-null", parent != null );
            Assert.Operation.NotDisposed( $"State {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"State {this} must have {parent} owner", this.Owner == parent );
            if (this.Activity == Activity.Active) {
                this.Deactivate( argument );
            }
            {
                this.OnDetach( argument );
                this.Owner = null;
            }
        }

        // OnAttach
        protected virtual void OnAttach(object? argument) {
        }

        // OnDetach
        protected virtual void OnDetach(object? argument) {
        }

    }
    public partial class State {

        // Activate
        private void Activate(object? argument) {
            this.Activity = Activity.Activating;
            this.OnActivate( argument );
            this.Activity = Activity.Active;
        }

        // Deactivate
        private void Deactivate(object? argument) {
            this.Activity = Activity.Deactivating;
            this.OnDeactivate( argument );
            this.Activity = Activity.Inactive;
        }

        // OnActivate
        protected virtual void OnActivate(object? argument) {
        }

        // OnDeactivate
        protected virtual void OnDeactivate(object? argument) {
        }

    }
}
