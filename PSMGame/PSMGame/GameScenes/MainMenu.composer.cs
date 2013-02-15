// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace PSMGame
{
    partial class MainMenu
    {
        ImageBox Background;
        Label Title;
        Button PlayButton;
        Button InstructionsButton;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            Background = new ImageBox();
            Background.Name = "Background";
            Title = new Label();
            Title.Name = "Title";
            PlayButton = new Button();
            PlayButton.Name = "PlayButton";
            InstructionsButton = new Button();
            InstructionsButton.Name = "InstructionsButton";

            // Background
            Background.Image = new ImageAsset("/Application/assets/LandAndSky.jpg");

            // Title
            Title.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Title.Font = new UIFont(FontAlias.System, 32, FontStyle.Regular);
            Title.LineBreak = LineBreak.Character;
            Title.HorizontalAlignment = HorizontalAlignment.Center;
            Title.TextShadow = new TextShadowSettings()
            {
                Color = new UIColor(128f / 255f, 128f / 255f, 128f / 255f, 127f / 255f),
                HorizontalOffset = 4f,
                VerticalOffset = 4f,
            };

            // PlayButton
            PlayButton.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            PlayButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            PlayButton.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 25f / 255f);

            // InstructionsButton
            InstructionsButton.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            InstructionsButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            InstructionsButton.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 25f / 255f);

            // MainMenu
            this.RootWidget.AddChildLast(Background);
            this.RootWidget.AddChildLast(Title);
            this.RootWidget.AddChildLast(PlayButton);
            this.RootWidget.AddChildLast(InstructionsButton);
            this.Showing += new EventHandler(onShowing);
            this.Shown += new EventHandler(onShown);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    Background.SetPosition(0, 0);
                    Background.SetSize(200, 200);
                    Background.Anchors = Anchors.None;
                    Background.Visible = true;

                    Title.SetPosition(263, 70);
                    Title.SetSize(214, 36);
                    Title.Anchors = Anchors.None;
                    Title.Visible = true;

                    PlayButton.SetPosition(283, 210);
                    PlayButton.SetSize(214, 56);
                    PlayButton.Anchors = Anchors.None;
                    PlayButton.Visible = true;

                    InstructionsButton.SetPosition(283, 210);
                    InstructionsButton.SetSize(214, 56);
                    InstructionsButton.Anchors = Anchors.None;
                    InstructionsButton.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    Background.SetPosition(0, 0);
                    Background.SetSize(960, 544);
                    Background.Anchors = Anchors.None;
                    Background.Visible = true;

                    Title.SetPosition(373, 70);
                    Title.SetSize(214, 36);
                    Title.Anchors = Anchors.None;
                    Title.Visible = true;

                    PlayButton.SetPosition(373, 210);
                    PlayButton.SetSize(214, 56);
                    PlayButton.Anchors = Anchors.None;
                    PlayButton.Visible = true;

                    InstructionsButton.SetPosition(373, 275);
                    InstructionsButton.SetSize(214, 56);
                    InstructionsButton.Anchors = Anchors.None;
                    InstructionsButton.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            Title.Text = "PSM Game";

            PlayButton.Text = "Play";

            InstructionsButton.Text = "Instructions";
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    Title.Visible = false;
                    PlayButton.Visible = false;
                    InstructionsButton.Visible = false;
                    break;

                default:
                    Title.Visible = false;
                    PlayButton.Visible = false;
                    InstructionsButton.Visible = false;
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    new FadeInEffect()
                    {
                        Widget = Title,
                    }.Start();
                    new SlideInEffect()
                    {
                        Widget = PlayButton,
                        MoveDirection = FourWayDirection.Right,
                    }.Start();
                    new SlideInEffect()
                    {
                        Widget = InstructionsButton,
                        MoveDirection = FourWayDirection.Left,
                    }.Start();
                    break;

                default:
                    new FadeInEffect()
                    {
                        Widget = Title,
                    }.Start();
                    new SlideInEffect()
                    {
                        Widget = PlayButton,
                        MoveDirection = FourWayDirection.Right,
                    }.Start();
                    new SlideInEffect()
                    {
                        Widget = InstructionsButton,
                        MoveDirection = FourWayDirection.Left,
                    }.Start();
                    break;
            }
        }

    }
}
