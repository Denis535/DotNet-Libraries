#nullable enable
namespace System.TreeMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class TreeMachine {

        // IsDisposed
        bool ITreeMachine.IsDisposing => this.IsDisposing;
        bool ITreeMachine.IsDisposed => this.IsDisposed;

        // Root
        INode? ITreeMachine.Root => this.Root;

        // Dispose
        void IDisposable.Dispose() {
            this.Dispose();
        }

    }
}
