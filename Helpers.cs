using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace BingChatLight;

public static class Helpers
{
    [StackTraceHidden]
    public static void Assert(
        [DoesNotReturnIf(false)] bool expr,
        [CallerArgumentExpression(nameof(expr))] string exprmsg = "")
    {
        if (!expr)
        {
            ArgumentException(exprmsg);
        }
    }

    [StackTraceHidden, DoesNotReturn]
    private static void ArgumentException(string exprmsg)
    {
        throw new ArgumentException("Condition not satisfied", exprmsg);
    }
}
