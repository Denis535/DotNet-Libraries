#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.StateMachine.Pro;
    using System.Text;

    internal sealed class State : System.StateMachine.Pro.State {

        public PlayListBase PlayList { get; }

        public State(PlayListBase playList) {
            this.PlayList = playList;
        }
        protected override void OnDispose() {
            this.PlayList.OnDispose();
        }

        protected override void OnActivate(object? argument) {
            this.PlayList.OnActivate( argument );
        }
        protected override void OnDeactivate(object? argument) {
            this.PlayList.OnDeactivate( argument );
        }

    }
    public abstract class PlayListBase {

        private readonly State m_State;

        public bool IsDisposing {
            get {
                return this.m_State.IsDisposing;
            }
        }
        public bool IsDisposed {
            get {
                return this.m_State.IsDisposed;
            }
        }

        public IState State {
            get {
                Assert.Operation.Valid( $"PlayList {this} must be non-disposed", !this.IsDisposed );
                return this.m_State;
            }
        }
        protected System.StateMachine.Pro.State StateMutable {
            get {
                Assert.Operation.Valid( $"PlayList {this} must be non-disposed", !this.IsDisposed );
                return this.m_State;
            }
        }

        public PlayListBase() {
            this.m_State = new State( this );
        }
        protected internal abstract void OnDispose();

        protected internal abstract void OnActivate(object? argument);
        protected internal abstract void OnDeactivate(object? argument);

    }
}
