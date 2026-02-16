#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.TreeMachine.Pro;

    public abstract class WidgetBase {
        internal sealed class Node2 : Node {
            private readonly WidgetBase m_Widget;

            public WidgetBase Widget {
                get {
                    Assert.Operation.Valid($"Node {this} must be non-disposed", !this.IsDisposed);
                    return this.m_Widget;
                }
            }

            public Node2(WidgetBase widget) {
                this.m_Widget = widget;
            }

            protected override void OnDispose() {
                this.Widget.OnDispose();
                this.Widget.OnDisposeInternal();
            }

            protected override void OnActivate(object? argument) {
                foreach (var ancestor in this.Ancestors.Cast<Node2>().ToList().AsEnumerable().Reverse()) {
                    // top-down
                    ancestor.Widget.OnBeforeDescendantActivate(this, argument);
                }

                this.Widget.OnActivate(argument);
                foreach (var ancestor in this.Ancestors.Cast<Node2>().ToList()) {
                    // down-top
                    ancestor.Widget.OnAfterDescendantActivate(this, argument);
                }
            }

            protected override void OnDeactivate(object? argument) {
                foreach (var ancestor in this.Ancestors.Cast<Node2>().ToList().AsEnumerable().Reverse()) {
                    // top-down
                    ancestor.Widget.OnBeforeDescendantDeactivate(this, argument);
                }

                this.Widget.OnDeactivate(argument);
                foreach (var ancestor in this.Ancestors.Cast<Node2>().ToList()) {
                    // down-top
                    ancestor.Widget.OnAfterDescendantDeactivate(this, argument);
                }
            }

            protected override void Sort(List<INode> children) {
                this.Widget.Sort(children);
            }
        }

        private readonly Node m_Node;

        public INode Node => this.m_Node;
        protected Node NodeMutable => this.m_Node;

        public WidgetBase() {
            this.m_Node = new Node2(this);
        }

        protected internal abstract void OnDispose();

        private protected virtual void OnDisposeInternal() {
        }

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
                Assert.Operation.Valid($"Widget {this} must be non-disposed", !this.Node.IsDisposed);
                return this.m_View;
            }
            protected init {
                Assert.Operation.Valid($"Widget {this} must be non-disposed", !this.Node.IsDisposed);
                this.m_View = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public ViewableWidgetBase() {
        }

        private protected override void OnDisposeInternal() {
            if (this.m_View is IDisposable disposable) {
                disposable.Dispose();
            }
        }
    }

    public abstract class ViewableWidgetBase<TView> : ViewableWidgetBase
        where TView : notnull {
        protected new TView View {
            get => (TView)base.View;
            init => base.View = value;
        }

        public ViewableWidgetBase() {
        }
    }
}
