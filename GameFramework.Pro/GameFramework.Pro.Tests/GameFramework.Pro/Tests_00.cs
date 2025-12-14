#pragma warning disable CA2000 // Dispose objects before losing scope
namespace GameFramework.Pro {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    public class Tests_00 {

        [Test]
        public void Test_00() {
            using var program = new Program();
        }

    }
    // Main
    internal class Program : ProgramBase2<Theme, Screen, Router, Application> {

        public Program() {
            this.Application = new Application();
            this.Router = new Router();
            this.Screen = new Screen();
            this.Theme = new Theme();
        }
        protected override void OnDispose() {
            this.Theme.Dispose();
            this.Screen.Dispose();
            this.Router.Dispose();
            this.Application.Dispose();
        }

    }
    // UI
    internal class Theme : ThemeBase2<Router, Application> {

        public Theme() : base() {
            this.Machine.SetRoot( new MainPlayList().State, null, null );
            this.Machine.SetRoot( new GamePlayList().State, null, null );
        }
        protected override void OnDispose() {
            ((IDisposable?) this.Machine.Root)!.Dispose();
        }

    }
    internal class MainPlayList : PlayListBase2 {

        public MainPlayList() : base() {
        }
        protected internal override void OnDispose() {
        }

        protected internal override void OnActivate(object? argument) {
        }
        protected internal override void OnDeactivate(object? argument) {
        }

    }
    internal class GamePlayList : PlayListBase2 {

        public GamePlayList() : base() {
        }
        protected internal override void OnDispose() {
        }

        protected internal override void OnActivate(object? argument) {
        }
        protected internal override void OnDeactivate(object? argument) {
        }

    }
    // UI
    internal class Screen : ScreenBase2<Router, Application> {

        public Screen() : base() {
            this.Machine.SetRoot( new RootWidget().Node, null, null );
        }
        protected override void OnDispose() {
            ((IDisposable?) this.Machine.Root)!.Dispose();
        }

    }
    internal class RootWidget : WidgetBase2 {

        public RootWidget() : base() {
            this.NodeMutable.AddChild( new MainWidget().Node, null );
            this.NodeMutable.AddChild( new GameWidget().Node, null );
        }
        protected internal override void OnDispose() {
            foreach (var child in this.NodeMutable.Children.Reverse()) {
                ((IDisposable) child).Dispose();
            }
        }

        protected internal override void OnActivate(object? argument) {
        }
        protected internal override void OnDeactivate(object? argument) {
        }

    }
    internal class MainWidget : ViewableWidgetBase2<MainWidget.View> {
        new internal class View {
            public View() {
            }
        }

        public MainWidget() : base() {
            base.View = new View();
        }
        protected internal override void OnDispose() {
            foreach (var child in this.NodeMutable.Children.Reverse()) {
                ((IDisposable) child).Dispose();
            }
        }

        protected internal override void OnActivate(object? argument) {
        }
        protected internal override void OnDeactivate(object? argument) {
        }

    }
    internal class GameWidget : ViewableWidgetBase2<GameWidget.View> {
        new internal class View {
            public View() {
            }
        }

        public GameWidget() : base() {
            base.View = new View();
        }
        protected internal override void OnDispose() {
            foreach (var child in this.NodeMutable.Children.Reverse()) {
                ((IDisposable) child).Dispose();
            }
        }

        protected internal override void OnActivate(object? argument) {
        }
        protected internal override void OnDeactivate(object? argument) {
        }

    }
    // UI
    internal class Router : RouterBase2<Theme, Screen, Application> {

        public Router() : base() {
        }
        protected override void OnDispose() {
        }

    }
    // App
    internal class Application : ApplicationBase2 {

        private Game Game { get; init; }

        public Application() : base() {
            this.Game = new Game();
        }
        protected override void OnDispose() {
            this.Game.Dispose();
        }

    }
    // Domain
    internal class Game : GameBase2 {

        private Player Player { get; init; }
        private Entity Entity { get; init; }

        public Game() : base() {
            this.Player = new Player();
            this.Entity = new Entity();
        }
        protected override void OnDispose() {
            this.Entity.Dispose();
            this.Player.Dispose();
        }

    }
    internal class Player : PlayerBase2 {

        public Player() : base() {
        }
        protected override void OnDispose() {
        }

    }
    internal class Entity : EntityBase {

        public Entity() {
        }
        protected override void OnDispose() {
        }

    }
}
