#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class RouterBase2<TTheme, TScreen, TApplication> : RouterBase
        where TTheme : ThemeBase
        where TScreen : ScreenBase
        where TApplication : ApplicationBase {

        private readonly TApplication m_Application;

        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed( $"Router {this} must be non-disposed", !this.IsDisposed );
                return IDependencyProvider.Instance;
            }
        }
        protected TTheme Theme => this.Provider.RequireDependency<TTheme>();
        protected TScreen Screen => this.Provider.RequireDependency<TScreen>();
        protected TApplication Application {
            get {
                Assert.Operation.NotDisposed( $"Router {this} must be non-disposed", !this.IsDisposed );
                return this.m_Application;
            }
        }

        public RouterBase2() {
            this.m_Application = this.Provider.RequireDependency<TApplication>();
        }
        protected override void OnDispose() {
            base.OnDispose();
        }

    }
}
