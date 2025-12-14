#nullable enable
namespace System.TreeMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public partial class Node {

        // IsDisposed
        bool INode.IsDisposing => this.IsDisposing;
        bool INode.IsDisposed => this.IsDisposed;

        // Owner
        object? INode.Owner => this.Owner;

        // Machine
        ITreeMachine? INode.Machine => this.Machine;

        // Root
        [MemberNotNullWhen( false, nameof( INode.Parent ) )] bool INode.IsRoot => this.IsRoot;
        INode INode.Root => this.Root;

        // Parent
        INode? INode.Parent => this.Parent;
        IEnumerable<INode> INode.Ancestors => this.Ancestors;
        IEnumerable<INode> INode.AncestorsAndSelf => this.AncestorsAndSelf;

        // Activity
        Activity INode.Activity => this.Activity;

        // Children
        IEnumerable<INode> INode.Children => this.Children;
        IEnumerable<INode> INode.Descendants => this.Descendants;
        IEnumerable<INode> INode.DescendantsAndSelf => this.DescendantsAndSelf;

        // Dispose
        void IDisposable.Dispose() {
            this.Dispose();
        }

    }
    public partial class Node {

        // Attach
        void INode.Attach(ITreeMachine machine, object? argument) {
            this.Attach( machine, argument );
        }
        void INode.Attach(INode parent, object? argument) {
            this.Attach( parent, argument );
        }

        // Detach
        void INode.Detach(ITreeMachine machine, object? argument) {
            this.Detach( machine, argument );
        }
        void INode.Detach(INode parent, object? argument) {
            this.Detach( parent, argument );
        }

        // Activate
        void INode.Activate(object? argument) {
            this.Activate( argument );
        }

        // Deactivate
        void INode.Deactivate(object? argument) {
            this.Deactivate( argument );
        }

    }
}
