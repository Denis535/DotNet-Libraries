#nullable enable
namespace System {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public static class Check {
        public static class Argument {

            public static void Valid([DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ArgumentException(message: null);
            }

            public static void NotNull([DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ArgumentNullException(null, message: null);
            }

            public static void InRange([DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ArgumentOutOfRangeException(null, message: null);
            }

            public static void Valid(FormattableString message, [DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ArgumentException(message: message.ToString());
            }

            public static void NotNull(FormattableString message, [DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ArgumentNullException(null, message: message.ToString());
            }

            public static void InRange(FormattableString message, [DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ArgumentOutOfRangeException(null, message: message.ToString());
            }

        }

        public static class Operation {

            public static void Valid([DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new InvalidOperationException(message: null);
            }

            public static void Ready([DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new InvalidOperationException(message: null);
            }

            public static void Alive([DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ObjectDisposedException(null, message: null);
            }

            public static void Valid(FormattableString message, [DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new InvalidOperationException(message: message.ToString());
            }

            public static void Ready(FormattableString message, [DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new InvalidOperationException(message: message.ToString());
            }

            public static void Alive(FormattableString message, [DoesNotReturnIf(false)] bool isValid) {
                if (!isValid) throw new ObjectDisposedException(null, message: message.ToString());
            }

        }
    }
}
