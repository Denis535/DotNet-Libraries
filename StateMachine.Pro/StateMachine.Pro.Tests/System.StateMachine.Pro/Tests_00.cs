namespace System.StateMachine.Pro {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using Assert = NUnit.Framework.Assert;

    public class Tests_00 {

        [Test]
        public void Test_00() {
            using (var machine = new StateMachine()) {
                {
                    // machine.SetState State
                    machine.SetRoot( new State(), null, null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                }
                {
                    // machine.SetState ChildrenableState
                    machine.SetRoot( new ChildrenableState(), null, null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                }
                {
                    // machine.SetState null
                    machine.SetRoot( null, null, null );
                    Assert.That( machine.Root, Is.Null );
                }
            }
        }

        [Test]
        public void Test_01() {
            using (var machine = new StateMachine()) {
                {
                    // machine.SetState State
                    machine.SetRoot( new State(), null, null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
                    Assert.That( machine.Root.Activity, Is.EqualTo( Activity.Active ) );
                }
                {
                    // machine.SetState ChildrenableState
                    machine.SetRoot( new ChildrenableState(), null, null );
                    Assert.That( machine.Root, Is.Not.Null );
                    Assert.That( machine.Root.Machine, Is.EqualTo( machine ) );
                    Assert.That( machine.Root.IsRoot, Is.EqualTo( true ) );
                    Assert.That( machine.Root.Root, Is.EqualTo( machine.Root ) );
                    Assert.That( machine.Root.Parent, Is.EqualTo( null ) );
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
}
