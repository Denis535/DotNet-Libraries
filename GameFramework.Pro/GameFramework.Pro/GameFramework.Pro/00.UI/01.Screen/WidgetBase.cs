#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.TreeMachine.Pro;

    internal sealed class Node : System.TreeMachine.Pro.Node {

        public WidgetBase Widget { get; }

        public Node(WidgetBase widget) {
            this.Widget = widget;
        }
        protected override void OnDispose() {
            this.Widget.OnDispose();
        }

        protected override void OnActivate(object? argument) {
            foreach (var ancestor in this.Ancestors.Cast<Node>().ToList().AsEnumerable().Reverse()) { // top-down
                ancestor.Widget.OnBeforeDescendantActivate( this, argument );
            }
            this.Widget.OnActivate( argument );
            foreach (var ancestor in this.Ancestors.Cast<Node>().ToList()) { // down-top
                ancestor.Widget.OnAfterDescendantActivate( this, argument );
            }
        }
        protected override void OnDeactivate(object? argument) {
            foreach (var ancestor in this.Ancestors.Cast<Node>().ToList().AsEnumerable().Reverse()) { // top-down
                ancestor.Widget.OnBeforeDescendantDeactivate( this, argument );
            }
            this.Widget.OnDeactivate( argument );
            foreach (var ancestor in this.Ancestors.Cast<Node>().ToList()) { // down-top
                ancestor.Widget.OnAfterDescendantDeactivate( this, argument );
            }
        }

        protected override void Sort(List<INode> children) {
            this.Widget.Sort( children );
        }

    }
    public abstract class WidgetBase {

        private readonly Node m_Node;

        public bool IsDisposing {
            get {
                return this.m_Node.IsDisposing;
            }
        }
        public bool IsDisposed {
            get {
                return this.m_Node.IsDisposed;
            }
        }

        public INode Node {
            get {
                Assert.Operation.Valid( $"Widget {this} must be non-disposed", !this.IsDisposed );
                return this.m_Node;
            }
        }
        protected System.TreeMachine.Pro.Node NodeMutable {
            get {
                Assert.Operation.Valid( $"Widget {this} must be non-disposed", !this.IsDisposed );
                return this.m_Node;
            }
        }

        public WidgetBase() {
            this.m_Node = new Node( this );
        }
        protected internal abstract void OnDispose();

        protected internal abstract void OnActivate(object? argument);
        protected internal abstract void OnDeactivate(object? argument);

        protected internal virtual void OnBeforeDescendantActivate(INode descendant, object? argument) {
        }
        protected internal virtual void OnAfterDescendantActivate(INode descendant, object? argument) {
        }
        protected internal virtual void OnBeforeDescendantDeactivate(INode descendant, object? argument) {
        }
        protected internal virtual void OnAfterDescendantDeactivate(INode descendant, object? argument) {
        }

        protected internal virtual void Sort(List<INode> children) {
        }

    }
    public abstract class ViewableWidgetBase : WidgetBase {

        private object m_View = default!;

        public object View {
            get {
                Assert.Operation.Valid( $"Widget {this} must be non-disposed", !this.IsDisposed );
                return this.m_View;
            }
            protected init {
                Assert.Operation.Valid( $"Widget {this} must be non-disposed", !this.IsDisposed );
                this.m_View = value ?? throw new ArgumentNullException( nameof( value ) );
            }
        }

        public ViewableWidgetBase() {
        }

    }
    public abstract class ViewableWidgetBase<TView> : ViewableWidgetBase
        where TView : notnull {

        protected new TView View {
            get => (TView) base.View;
            init => base.View = value;
        }

        public ViewableWidgetBase() {
        }

    }
}
