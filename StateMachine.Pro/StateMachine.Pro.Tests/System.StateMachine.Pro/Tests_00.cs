namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Assert = NUnit.Framework.Assert;

    public class Tests_00 {

        [Test]
        public void Test_00() {
            using (var machine = new StateMachine<IState2>()) {
                {
                    // machine.SetState State
                    machine.SetRoot( new State2(), null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
                    Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                }
                {
                    // machine.SetState ChildrenableState
                    machine.SetRoot( new ChildrenableState2(), null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
                    Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                }
                {
                    // machine.SetState null
                    machine.SetRoot( null, null );
                    Assert.That( machine.Root, Is.Null );
                }
            }
        }

        [Test]
        public void Test_01() {
            using (var machine = new StateMachine<IState2>()) {
                {
                    // machine.SetState State
                    machine.SetRoot( new State2(), null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
                    Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                }
                {
                    // machine.SetState ChildrenableState
                    machine.SetRoot( new ChildrenableState2(), null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Owner, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
                    Assert.That( machine.Root.Ancestors.Count(), Is.EqualTo( 0 ) );
                    Assert.That( machine.Root.AncestorsAndSelf.Count(), Is.EqualTo( 1 ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                }
                {
                    // machine.Root.Dispose
                    machine.Root.Dispose();
                    Assert.That( machine.Root.IsDisposed, Is.True );
                }
            }
        }

    }
    internal interface IState2 : IState<IState2> {
    }
    internal sealed class State2 : State<IState2>, IState2 {
    }
    internal sealed class ChildrenableState2 : ChildrenableState<IState2>, IState2 {
    }
}
