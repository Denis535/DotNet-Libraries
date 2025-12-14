#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ScreenBase2<TRouter, TApplication> : ScreenBase
        where TRouter : RouterBase
        where TApplication : ApplicationBase {

        private readonly TRouter m_Router;
        private readonly TApplication m_Application;

        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed( $"Screen {this} must be non-disposed", !this.IsDisposed );
                return IDependencyProvider.Instance;
            }
        }
        protected TRouter Router {
            get {
                Assert.Operation.NotDisposed( $"Screen {this} must be non-disposed", !this.IsDisposed );
                return this.m_Router;
            }
        }
        protected TApplication Application {
            get {
                Assert.Operation.NotDisposed( $"Screen {this} must be non-disposed", !this.IsDisposed );
                return this.m_Application;
            }
        }

        public ScreenBase2() {
            this.m_Router = this.Provider.RequireDependency<TRouter>();
            this.m_Application = this.Provider.RequireDependency<TApplication>();
        }
        internal override void OnDisposeInternal() {
            base.OnDisposeInternal();
        }

    }
}
