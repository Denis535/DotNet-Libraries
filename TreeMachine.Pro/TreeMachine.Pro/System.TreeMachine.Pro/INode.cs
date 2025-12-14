#nullable enable
namespace System.TreeMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public partial interface INode : IDisposable {

        // IsDisposed
        public bool IsDisposing { get; }
        public bool IsDisposed { get; }

        // Owner
        public object? Owner { get; }

        // Machine
        public ITreeMachine? Machine { get; }

        // Root
        [MemberNotNullWhen( false, nameof( Parent ) )] public bool IsRoot { get; }
        public INode Root { get; }

        // Parent
        public INode? Parent { get; }
        public IEnumerable<INode> Ancestors { get; }
        public IEnumerable<INode> AncestorsAndSelf { get; }

        // Activity
        public Activity Activity { get; }

        // Children
        public IEnumerable<INode> Children { get; }
        public IEnumerable<INode> Descendants { get; }
        public IEnumerable<INode> DescendantsAndSelf { get; }

    }
    public partial interface INode {

        // Attach
        protected internal void Attach(ITreeMachine machine, object? argument);
        protected internal void Attach(INode parent, object? argument);

        // Detach
        protected internal void Detach(ITreeMachine machine, object? argument);
        protected internal void Detach(INode parent, object? argument);

        // Activate
        protected internal void Activate(object? argument);

        // Deactivate
        protected internal void Deactivate(object? argument);

    }
}
