#nullable enable
namespace GameFramework.Pro {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.TreeMachine.Pro;

    public static class ScreenExtensions {

        public static WidgetBase Widget(this INode node) {
            return ((Node) node).Widget;
        }
        public static T Widget<T>(this INode node) where T : notnull, WidgetBase {
            return (T) node.Widget();
        }

    }
}
