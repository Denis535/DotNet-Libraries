#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class WidgetBase2 : WidgetBase {

        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed( $"Widget {this} must be non-disposed", !this.IsDisposed );
                return IDependencyProvider.Instance;
            }
        }

        public WidgetBase2() {
        }

    }
    public abstract class ViewableWidgetBase2<TView> : ViewableWidgetBase<TView>
        where TView : notnull {

        protected IDependencyProvider Provider {
            get {
                Assert.Operation.NotDisposed( $"Widget {this} must be non-disposed", !this.IsDisposed );
                return IDependencyProvider.Instance;
            }
        }

        public ViewableWidgetBase2() {
        }

    }
}
