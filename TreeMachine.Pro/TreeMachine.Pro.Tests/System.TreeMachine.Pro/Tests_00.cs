namespace System.TreeMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Assert = NUnit.Framework.Assert;

    public class Tests_00 {

        [Test]
        public void Test_00() {
            using (var machine = new TreeMachine<Node2>()) {
                // machine.SetRoot Node
                machine.SetRoot( new Node2(), null );
                Assert.That( machine.Root, Is.Not.Null );
                Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                Assert.That( machine.Root.IsRoot, Is.True );
                Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                Assert.That( machine.Root.Parent, Is.Null );
                Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                Assert.That( machine.Root.Children.Count, Is.EqualTo( 0 ) );
                Assert.That( machine.Root.Descendants.Count(), Is.EqualTo( 0 ) );
                Assert.That( machine.Root.DescendantsAndSelf.Count(), Is.EqualTo( 1 ) );
                {
                    // machine.Root.AddChildren Node, Node
                    machine.Root.AddChildren( [ new Node2(), new Node2() ], null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.True );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.Null );
                    Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                    Assert.That( machine.Root.Children.Count, Is.EqualTo( 2 ) );
                    Assert.That( machine.Root.Descendants.Count(), Is.EqualTo( 2 ) );
                    Assert.That( machine.Root.DescendantsAndSelf.Count(), Is.EqualTo( 3 ) );
                    foreach (var child in machine.Root.Children) {
                        Assert.That( child.Owner, Is.EqualTo( machine.Root ) );
                        Assert.That( child.Machine, Is.EqualTo( machine ) );
                        Assert.That( child.IsRoot, Is.False );
                        Assert.That( child.Root, Is.EqualTo( machine.Root ) );
                        Assert.That( child.Parent, Is.EqualTo( machine.Root ) );
                        Assert.That( child.Ancestors.Count(), Is.EqualTo( 1 ) );
                        Assert.That( child.AncestorsAndSelf.Count(), Is.EqualTo( 2 ) );
                        Assert.That( child.Activity, Is.EqualTo( Activity.Active ) );
                        Assert.That( child.Children.Count, Is.EqualTo( 0 ) );
                        Assert.That( child.Descendants.Count(), Is.EqualTo( 0 ) );
                        Assert.That( child.DescendantsAndSelf.Count(), Is.EqualTo( 1 ) );
                    }
                    // machine.Root.RemoveChildren true
                    _ = machine.Root.RemoveChildren( i => true, null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.True );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.Null );
                    Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                    Assert.That( machine.Root.Children.Count, Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.Descendants.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.DescendantsAndSelf.Count(), Is.EqualTo( 1 ) );
                }
                // machine.SetRoot null
                machine.SetRoot( null, null );
                Assert.That( machine.Root, Is.Null );
            }
        }

        [Test]
        public void Test_01() {
            using (var machine = new TreeMachine<Node2>()) {
                // machine.SetRoot Node
                machine.SetRoot( new Node2(), null, null );
                Assert.That( machine.Root, Is.Not.Null );
                Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                Assert.That( machine.Root.IsRoot, Is.True );
                Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                Assert.That( machine.Root.Parent, Is.Null );
                Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                Assert.That( machine.Root.Children.Count, Is.EqualTo( 0 ) );
                Assert.That( machine.Root.Descendants.Count(), Is.EqualTo( 0 ) );
                Assert.That( machine.Root.DescendantsAndSelf.Count(), Is.EqualTo( 1 ) );
                {
                    // machine.Root.AddChildren Node, Node
                    machine.Root.AddChildren( [ new Node2(), new Node2() ], null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.True );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.Null );
                    Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                    Assert.That( machine.Root.Children.Count, Is.EqualTo( 2 ) );
                    Assert.That( machine.Root.Descendants.Count(), Is.EqualTo( 2 ) );
                    Assert.That( machine.Root.DescendantsAndSelf.Count(), Is.EqualTo( 3 ) );
                    foreach (var child in machine.Root.Children) {
                        Assert.That( child.Owner, Is.EqualTo( machine.Root ) );
                        Assert.That( child.Machine, Is.EqualTo( machine ) );
                        Assert.That( child.IsRoot, Is.False );
                        Assert.That( child.Root, Is.EqualTo( machine.Root ) );
                        Assert.That( child.Parent, Is.EqualTo( machine.Root ) );
                        Assert.That( child.Ancestors.Count(), Is.EqualTo( 1 ) );
                        Assert.That( child.AncestorsAndSelf.Count(), Is.EqualTo( 2 ) );
                        Assert.That( child.Activity, Is.EqualTo( Activity.Active ) );
                        Assert.That( child.Children.Count, Is.EqualTo( 0 ) );
                        Assert.That( child.Descendants.Count(), Is.EqualTo( 0 ) );
                        Assert.That( child.DescendantsAndSelf.Count(), Is.EqualTo( 1 ) );
                    }
                    //  machine.Root.Children.Reverse.Dispose
                    foreach (var child in machine.Root.Children.Reverse()) {
                        child.Dispose();
                        Assert.That( child.IsDisposed, Is.True );
                    }
                }
                // machine.Root.Dispose
                machine.Root.Dispose();
                Assert.That( machine.Root.IsDisposed, Is.True );
            }
        }

    }
    internal sealed class Node2 : Node<Node2> {
    }
}
