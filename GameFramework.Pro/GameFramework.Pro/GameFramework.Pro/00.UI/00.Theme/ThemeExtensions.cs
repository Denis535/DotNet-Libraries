#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.StateMachine.Pro;

    public static class ThemeExtensions {
        public static PlayListBase PlayList(this IState state) {
            return ((PlayListBase.State2)state).PlayList;
        }

        public static T PlayList<T>(this IState state) where T : notnull, PlayListBase {
            return (T)state.PlayList();
        }
    }
}
