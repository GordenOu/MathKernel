using System;
using System.Collections.Generic;
using Core.Clang;
using Core.Diagnostics;

namespace MathKernel.CodeGeneration
{
    internal static class Extensions
    {
        private class NotifyingVisitor : CursorVisitor
        {
            public event EventHandler<Cursor> VisitingCursor;

            protected override ChildVisitResult Visit(Cursor cursor, Cursor parent)
            {
                VisitingCursor?.Invoke(this, cursor);
                return ChildVisitResult.Continue;
            }
        }

        public static Cursor[] GetChildren(this Cursor cursor)
        {
            Requires.NotNull(cursor, nameof(cursor));

            var visitor = new NotifyingVisitor();
            var children = new List<Cursor>();
            visitor.VisitingCursor += (sender, e) => children.Add(e);
            visitor.VisitChildren(cursor);
            return children.ToArray();
        }
    }
}
