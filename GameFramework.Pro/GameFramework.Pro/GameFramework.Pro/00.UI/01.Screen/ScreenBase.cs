#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.TreeMachine.Pro;

    public abstract class ScreenBase : DisposableBase {
        
        private readonly TreeMachine m_Machine;

        protected TreeMachine Machine {
            get {
                Check.Operation.Alive($"Screen {this} must be alive", !this.IsDisposed);
                return this.m_Machine;
            }
        }

        public ScreenBase() {
            this.m_Machine = new TreeMachine();
        }
        private protected override void OnDisposeInternal() {
            this.Machine.Dispose();
        }
        
    }
}
