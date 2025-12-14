#nullable enable
namespace System.TreeMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    public partial class Node : INode, IDisposable {

        private Lifecycle m_Lifecycle = Lifecycle.Alive;
        private object? m_Owner = null;
        private Activity m_Activity = Activity.Inactive;
        private readonly List<INode> m_Children = new List<INode>( 0 );

    }
    public partial class Node {

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
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.m_Owner;
            }
            private set {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                if (value != null) {
                    Assert.Operation.Valid( $"Node {this} must have no {this.m_Owner} owner", this.m_Owner == null );
                    Assert.Operation.Valid( $"Node {this} must have valid activity", this.Activity is Activity.Inactive );
                } else {
                    Assert.Operation.Valid( $"Node {this} must have owner", this.m_Owner != null );
                    Assert.Operation.Valid( $"Node {this} must have valid activity", this.Activity is Activity.Active or Activity.Inactive );
                }
                this.m_Owner = value;
            }
        }

        // Machine
        public ITreeMachine? Machine {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return (this.Owner as ITreeMachine) ?? (this.Owner as INode)?.Machine;
            }
        }

        // Root
        [MemberNotNullWhen( false, nameof( Parent ) )]
        public bool IsRoot {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.Parent == null;
            }
        }
        public INode Root {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.Parent?.Root ?? this;
            }
        }

        // Parent
        public INode? Parent {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.Owner as INode;
            }
        }
        public IEnumerable<INode> Ancestors {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                if (this.Parent != null) {
                    yield return this.Parent;
                    foreach (var i in this.Parent.Ancestors) yield return i;
                }
            }
        }
        public IEnumerable<INode> AncestorsAndSelf {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.Ancestors.Prepend( this );
            }
        }

        // Activity
        public Activity Activity {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.m_Activity;
            }
            private set {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                Assert.Operation.Valid( $"Node {this} must have owner", this.Owner != null );
                Assert.Operation.Valid( $"Node {this} must have valid activity", this.m_Activity != value );
                this.m_Activity = value;
            }
        }

        // Children
        public IReadOnlyList<INode> Children {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.m_Children;
            }
        }
        public IEnumerable<INode> Descendants {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                foreach (var child in this.Children) {
                    yield return child;
                    foreach (var i in child.Descendants) yield return i;
                }
            }
        }
        public IEnumerable<INode> DescendantsAndSelf {
            get {
                Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
                return this.Descendants.Prepend( this );
            }
        }

    }
    public partial class Node {

        // Constructor
        public Node() {
        }
        public void Dispose() {
            Assert.Operation.NotDisposed( $"Node {this} must be alive", this.m_Lifecycle == Lifecycle.Alive );
            this.m_Lifecycle = Lifecycle.Disposing;
            {
                this.OnDispose();
                Assert.Operation.Valid( $"Node {this} must have no {this.Children.Count( i => !i.IsDisposed )} children", this.Children.All( i => i.IsDisposed ) );
            }
            this.m_Lifecycle = Lifecycle.Disposed;
        }
        protected virtual void OnDispose() {
        }

    }
    public partial class Node {

        // Attach
        private void Attach(ITreeMachine machine, object? argument) {
            Assert.Argument.NotNull( $"Argument 'machine' must be non-null", machine != null );
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"Node {this} must have no {this.Owner} owner", this.Owner == null );
            {
                this.Owner = machine;
                this.OnAttach( argument );
            }
            if (true) {
                this.Activate( argument );
            }
        }
        private void Attach(INode parent, object? argument) {
            Assert.Argument.NotNull( $"Argument 'parent' must be non-null", parent != null );
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"Node {this} must have no {this.Owner} owner", this.Owner == null );
            {
                this.Owner = parent;
                this.OnAttach( argument );
            }
            if (parent.Activity == Activity.Active) {
                this.Activate( argument );
            }
        }

        // Detach
        private void Detach(ITreeMachine machine, object? argument) {
            Assert.Argument.NotNull( $"Argument 'machine' must be non-null", machine != null );
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"Node {this} must have {machine} owner", this.Owner == machine );
            if (true) {
                this.Deactivate( argument );
            }
            {
                this.OnDetach( argument );
                this.Owner = null;
            }
        }
        private void Detach(INode parent, object? argument) {
            Assert.Argument.NotNull( $"Argument 'parent' must be non-null", parent != null );
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"Node {this} must have {parent} owner", this.Owner == parent );
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
    public partial class Node {

        // Activate
        private void Activate(object? argument) {
            this.Activity = Activity.Activating;
            this.OnActivate( argument );
            foreach (var child in this.Children.ToList()) {
                child.Activate( argument );
            }
            this.Activity = Activity.Active;
        }

        // Deactivate
        private void Deactivate(object? argument) {
            this.Activity = Activity.Deactivating;
            foreach (var child in this.Children.Reverse()) {
                child.Deactivate( argument );
            }
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
    public partial class Node {

        // AddChild
        public void AddChild(INode child, object? argument) {
            Assert.Argument.NotNull( $"Argument 'child' must be non-null", child != null );
            Assert.Argument.Valid( $"Argument 'child' ({child}) must be non-disposed", !child.IsDisposed );
            Assert.Argument.Valid( $"Argument 'child' ({child}) must have no {child.Owner} owner", child.Owner == null );
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"Node {this} must have no {child} child", !this.Children.Contains( child ) );
            this.m_Children.Add( child );
            this.Sort( this.m_Children );
            child.Attach( this, argument );
        }
        public void AddChildren(IEnumerable<INode> children, object? argument) {
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            foreach (var child in children) {
                this.AddChild( child, argument );
            }
        }

        // RemoveChild
        public void RemoveChild(INode child, object? argument, Action<INode, object?>? callback = null) {
            Assert.Argument.NotNull( $"Argument 'child' must be non-null", child != null );
            Assert.Argument.Valid( $"Argument 'child' ({child}) must be non-disposed", !child.IsDisposed );
            Assert.Argument.Valid( $"Argument 'child' ({child}) must have {this} owner", child.Owner == this );
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"Node {this} must have {child} child", this.Children.Contains( child ) );
            child.Detach( this, argument );
            _ = this.m_Children.Remove( child );
            if (callback != null) {
                callback.Invoke( child, argument );
            } else {
                ((IDisposable) child).Dispose();
            }
        }
        public int RemoveChildren(Func<INode, bool> predicate, object? argument, Action<INode, object?>? callback = null) {
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            var count = 0;
            foreach (var child in this.Children.Reverse().Where( predicate )) {
                this.RemoveChild( child, argument, callback );
                count++;
            }
            return count;
        }

        // RemoveSelf
        public void RemoveSelf(object? argument, Action<INode, object?>? callback = null) {
            Assert.Operation.NotDisposed( $"Node {this} must be non-disposed", !this.IsDisposed );
            Assert.Operation.Valid( $"Node {this} must have owner", this.Owner != null );
            if (this.Owner is Node parent) {
                parent.RemoveChild( this, argument, callback );
            } else {
                ((TreeMachine) this.Owner).SetRoot( null, argument, callback );
            }
        }

        // Sort
        protected virtual void Sort(List<INode> children) {
            //children.Sort( (a, b) => Comparer<int>.Default.Compare( GetOrderOf( a ), GetOrderOf( b ) ) );
        }

    }
}
