#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.StateMachine.Pro;
    using System.Text;

    public abstract class PlayListBase {
        internal sealed class State2 : State {
            private readonly PlayListBase m_PlayList;

            public PlayListBase PlayList {
                get {
                    Assert.Operation.Valid($"State {this} must be non-disposed", !this.IsDisposed);
                    return this.m_PlayList;
                }
            }

            public State2(PlayListBase playList) {
                this.m_PlayList = playList;
            }

            protected override void OnDispose() {
                this.PlayList.OnDispose();
                this.PlayList.OnDisposeInternal();
            }

            protected override void OnActivate(object? argument) {
                this.PlayList.OnActivate(argument);
            }

            protected override void OnDeactivate(object? argument) {
                this.PlayList.OnDeactivate(argument);
            }
        }

        private readonly State m_State;

        public IState State => this.m_State;
        protected State StateMutable => this.m_State;

        public PlayListBase() {
            this.m_State = new State2(this);
        }

        protected internal abstract void OnDispose();

        private protected virtual void OnDisposeInternal() {
        }

        protected internal abstract void OnActivate(object? argument);
        protected internal abstract void OnDeactivate(object? argument);
    }
}
