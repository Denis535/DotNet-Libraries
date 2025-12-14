#nullable enable
namespace System.TreeMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITreeMachine {

        // IsDisposed
        public bool IsDisposing { get; }
        public bool IsDisposed { get; }

        // Root
        public INode? Root { get; }

    }
}
