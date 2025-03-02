using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application = System.Windows.Application;
using Border = System.Windows.Controls.Border;
using Button = System.Windows.Controls.Button;
using DataGrid = System.Windows.Controls.DataGrid;
using Rectangle = System.Windows.Shapes.Rectangle;
using Style = System.Windows.Style;
using Window = System.Windows.Window;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public static TaxInspectionEntities1 baza;

        public AuthorizationWindow()
        {
            InitializeComponent();

            // Путь к конфигурации
            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string FilePath = System.IO.Path.Combine(executablePath, "config.txt");

            CurrentSettings.LoadSettings(FilePath);

            baza = new TaxInspectionEntities1();

            this.PreviewKeyDown += MainWindow_PreviewKeyDown;

            ClarkHistory.UserRequests.Clear();
            ClarkHistory.ClarkAnswers.Clear();

            tbx1.Focus();

            CheckNextUpdateDate();

            // Применение стилей в соответствии с конфигурацией
            switch (CurrentSettings.Theme)
            {
                case 1:

                    // Btn1

                    Style btn1Style = new Style(typeof(Button));
                    btn1Style.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(235, 232, 232))));
                    btn1Style.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn1Style.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn1Style.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn1Style.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn1Style.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template1 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border1 = new FrameworkElementFactory(typeof(Border));
                    border1.Name = "border";
                    border1.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border1.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(235, 232, 232)));
                    border1.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border1.SetValue(Border.BorderThicknessProperty, new Thickness(0.5));
                    border1.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter1 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter1.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter1.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border1.AppendChild(contentPresenter1);

                    template1.VisualTree = border1;

                    Trigger trigger1 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger1.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkGray) { TargetName = "border" });
                    template1.Triggers.Add(trigger1);

                    btn1Style.Setters.Add(new Setter(Button.TemplateProperty, template1));

                    Style existingStyle1 = (Style)Application.Current.Resources["Btn1"];

                    Application.Current.Resources["Btn1"] = btn1Style;

                    // Btn2

                    Style btn11Style = new Style(typeof(Button));
                    btn11Style.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(248, 248, 248))));
                    btn11Style.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn11Style.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn11Style.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn11Style.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn11Style.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template11 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border11 = new FrameworkElementFactory(typeof(Border));
                    border11.Name = "border";
                    border11.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border11.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(248, 248, 248)));
                    border11.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border11.SetValue(Border.BorderThicknessProperty, new Thickness(1));
                    border11.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter11 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter11.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter11.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border11.AppendChild(contentPresenter11);

                    template11.VisualTree = border11;

                    Trigger trigger11 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger11.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkGray) { TargetName = "border" });
                    template11.Triggers.Add(trigger11);

                    btn11Style.Setters.Add(new Setter(Button.TemplateProperty, template11));

                    Style existingStyle11 = (Style)Application.Current.Resources["Btn2"];

                    Application.Current.Resources["Btn2"] = btn11Style;

                    // Rect1

                    Style rectStyle1 = new Style(typeof(Rectangle));
                    rectStyle1.Setters.Add(new Setter(Rectangle.FillProperty, new SolidColorBrush(Color.FromRgb(217, 217, 217))));
                    rectStyle1.Setters.Add(new Setter(Rectangle.StrokeProperty, Brushes.Black));
                    rectStyle1.Setters.Add(new Setter(Rectangle.StrokeThicknessProperty, 0.5));

                    Style existingStyleRect1 = (Style)Application.Current.Resources["Rect1"];

                    Application.Current.Resources["Rect1"] = rectStyle1;

                    // Bord1

                    Style borderStyle1 = new Style(typeof(Border));
                    borderStyle1.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(217, 217, 217))));
                    borderStyle1.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle1.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle1.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Style existingStyleBorder1 = (Style)Application.Current.Resources["Bord1"];

                    Application.Current.Resources["Bord1"] = borderStyle1;

                    // Bord3

                    Style borderStyle11 = new Style(typeof(Border));
                    borderStyle11.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(235, 232, 232))));
                    borderStyle11.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle11.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle11.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger11 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger11.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkGray));

                    borderStyle11.Triggers.Add(mouseOverTrigger11);

                    Style existingStyleBorder11 = (Style)Application.Current.Resources["Bord3"];

                    Application.Current.Resources["Bord3"] = borderStyle11;

                    // Bord4

                    Style borderStyle12 = new Style(typeof(Border));
                    borderStyle12.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(248, 248, 248))));
                    borderStyle12.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle12.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
                    borderStyle12.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger12 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger12.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.DarkGray));

                    borderStyle12.Triggers.Add(mouseOverTrigger12);

                    Style existingStyleBorder12 = (Style)Application.Current.Resources["Bord4"];

                    Application.Current.Resources["Bord4"] = borderStyle12;

                    break;
                case 2:

                    // Btn1

                    Style btn2Style = new Style(typeof(Button));
                    btn2Style.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 185, 185))));
                    btn2Style.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn2Style.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn2Style.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn2Style.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn2Style.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template2 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border2 = new FrameworkElementFactory(typeof(Border));
                    border2.Name = "border";
                    border2.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border2.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 185, 185)));
                    border2.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border2.SetValue(Border.BorderThicknessProperty, new Thickness(0.5));
                    border2.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter2 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter2.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter2.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border2.AppendChild(contentPresenter2);

                    template2.VisualTree = border2;

                    Trigger trigger2 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger2.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(193, 106, 106))) { TargetName = "border" });
                    template2.Triggers.Add(trigger2);

                    btn2Style.Setters.Add(new Setter(Button.TemplateProperty, template2));

                    Style existingStyle2 = (Style)Application.Current.Resources["Btn1"];

                    Application.Current.Resources["Btn1"] = btn2Style;

                    // Btn2

                    Style btn21Style = new Style(typeof(Button));
                    btn21Style.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 216, 216))));
                    btn21Style.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn21Style.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn21Style.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn21Style.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn21Style.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template21 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border21 = new FrameworkElementFactory(typeof(Border));
                    border21.Name = "border";
                    border21.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border21.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 216, 216)));
                    border21.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border21.SetValue(Border.BorderThicknessProperty, new Thickness(1));
                    border21.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter21 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter21.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter21.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border21.AppendChild(contentPresenter21);

                    template21.VisualTree = border21;

                    Trigger trigger21 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger21.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(193, 106, 106))) { TargetName = "border" });
                    template21.Triggers.Add(trigger21);

                    btn21Style.Setters.Add(new Setter(Button.TemplateProperty, template21));

                    Style existingStyle21 = (Style)Application.Current.Resources["Btn2"];

                    Application.Current.Resources["Btn2"] = btn21Style;

                    // Rect1

                    Style rectStyle2 = new Style(typeof(Rectangle));
                    rectStyle2.Setters.Add(new Setter(Rectangle.FillProperty, new SolidColorBrush(Color.FromRgb(255, 142, 142))));
                    rectStyle2.Setters.Add(new Setter(Rectangle.StrokeProperty, Brushes.Black));
                    rectStyle2.Setters.Add(new Setter(Rectangle.StrokeThicknessProperty, 0.5));

                    Style existingStyleRect2 = (Style)Application.Current.Resources["Rect1"];

                    Application.Current.Resources["Rect1"] = rectStyle2;

                    // Bord1

                    Style borderStyle2 = new Style(typeof(Border));
                    borderStyle2.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 142, 142))));
                    borderStyle2.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle2.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle2.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Style existingStyleBorder2 = (Style)Application.Current.Resources["Bord1"];

                    Application.Current.Resources["Bord1"] = borderStyle2;

                    // Bord3

                    Style borderStyle21 = new Style(typeof(Border));
                    borderStyle21.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 185, 185))));
                    borderStyle21.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle21.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle21.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger21 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger21.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(193, 106, 106))));

                    borderStyle21.Triggers.Add(mouseOverTrigger21);

                    Style existingStyleBorder21 = (Style)Application.Current.Resources["Bord3"];

                    Application.Current.Resources["Bord3"] = borderStyle21;

                    // Bord4

                    Style borderStyle22 = new Style(typeof(Border));
                    borderStyle22.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 216, 216))));
                    borderStyle22.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle22.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
                    borderStyle22.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger22 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger22.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(193, 106, 106))));

                    borderStyle22.Triggers.Add(mouseOverTrigger22);

                    Style existingStyleBorder22 = (Style)Application.Current.Resources["Bord4"];

                    Application.Current.Resources["Bord4"] = borderStyle22;

                    break;
                case 3:

                    // Btn1

                    Style btn3Style = new Style(typeof(Button));
                    btn3Style.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(202, 255, 229))));
                    btn3Style.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn3Style.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn3Style.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn3Style.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn3Style.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template3 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border3 = new FrameworkElementFactory(typeof(Border));
                    border3.Name = "border";
                    border3.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border3.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(202, 255, 229)));
                    border3.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border3.SetValue(Border.BorderThicknessProperty, new Thickness(0.5));
                    border3.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter3 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter3.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter3.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border3.AppendChild(contentPresenter3);

                    template3.VisualTree = border3;

                    Trigger trigger3 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger3.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(119, 207, 165))) { TargetName = "border" });
                    template3.Triggers.Add(trigger3);

                    btn3Style.Setters.Add(new Setter(Button.TemplateProperty, template3));

                    Style existingStyle3 = (Style)Application.Current.Resources["Btn1"];

                    Application.Current.Resources["Btn1"] = btn3Style;

                    // Btn2

                    Style btn31Style = new Style(typeof(Button));
                    btn31Style.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(227, 255, 242))));
                    btn31Style.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn31Style.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn31Style.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn31Style.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn31Style.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template31 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border31 = new FrameworkElementFactory(typeof(Border));
                    border31.Name = "border";
                    border31.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border31.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(227, 255, 242)));
                    border31.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border31.SetValue(Border.BorderThicknessProperty, new Thickness(1));
                    border31.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter31 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter31.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter31.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border31.AppendChild(contentPresenter31);

                    template31.VisualTree = border31;

                    Trigger trigger31 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger31.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(119, 207, 165))) { TargetName = "border" });
                    template31.Triggers.Add(trigger31);

                    btn31Style.Setters.Add(new Setter(Button.TemplateProperty, template31));

                    Style existingStyle31 = (Style)Application.Current.Resources["Btn2"];

                    Application.Current.Resources["Btn2"] = btn31Style;

                    // Rect1

                    Style rectStyle3 = new Style(typeof(Rectangle));
                    rectStyle3.Setters.Add(new Setter(Rectangle.FillProperty, new SolidColorBrush(Color.FromRgb(165, 255, 212))));
                    rectStyle3.Setters.Add(new Setter(Rectangle.StrokeProperty, Brushes.Black));
                    rectStyle3.Setters.Add(new Setter(Rectangle.StrokeThicknessProperty, 0.5));

                    Style existingStyleRect3 = (Style)Application.Current.Resources["Rect1"];

                    Application.Current.Resources["Rect1"] = rectStyle3;

                    // Bord1

                    Style borderStyle3 = new Style(typeof(Border));
                    borderStyle3.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(165, 255, 212))));
                    borderStyle3.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle3.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle3.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Style existingStyleBorder3 = (Style)Application.Current.Resources["Bord1"];

                    Application.Current.Resources["Bord1"] = borderStyle3;

                    // Bord3

                    Style borderStyle31 = new Style(typeof(Border));
                    borderStyle31.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(202, 255, 229))));
                    borderStyle31.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle31.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle31.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger31 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger31.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(119, 207, 165))));

                    borderStyle31.Triggers.Add(mouseOverTrigger31);

                    Style existingStyleBorder31 = (Style)Application.Current.Resources["Bord3"];

                    Application.Current.Resources["Bord3"] = borderStyle31;

                    // Bord4

                    Style borderStyle32 = new Style(typeof(Border));
                    borderStyle32.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(227, 255, 242))));
                    borderStyle32.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle32.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
                    borderStyle32.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger32 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger32.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(119, 207, 165))));

                    borderStyle32.Triggers.Add(mouseOverTrigger32);

                    Style existingStyleBorder32 = (Style)Application.Current.Resources["Bord4"];

                    Application.Current.Resources["Bord4"] = borderStyle32;

                    break;
                case 4:

                    // Btn1

                    Style btn4tyle = new Style(typeof(Button));
                    btn4tyle.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 232, 172))));
                    btn4tyle.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn4tyle.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn4tyle.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn4tyle.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn4tyle.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template4 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border4 = new FrameworkElementFactory(typeof(Border));
                    border4.Name = "border";
                    border4.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border4.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 232, 172)));
                    border4.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border4.SetValue(Border.BorderThicknessProperty, new Thickness(0.5));
                    border4.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter4 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter4.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter4.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border4.AppendChild(contentPresenter4);

                    template4.VisualTree = border4;

                    Trigger trigger4 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger4.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(219, 188, 107))) { TargetName = "border" });
                    template4.Triggers.Add(trigger4);

                    btn4tyle.Setters.Add(new Setter(Button.TemplateProperty, template4));

                    Style existingStyle4 = (Style)Application.Current.Resources["Btn1"];

                    Application.Current.Resources["Btn1"] = btn4tyle;

                    // Btn2

                    Style btn41tyle = new Style(typeof(Button));
                    btn41tyle.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 243, 214))));
                    btn41tyle.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.Black));
                    btn41tyle.Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Inter")));
                    btn41tyle.Setters.Add(new Setter(Button.FontSizeProperty, 20.0));
                    btn41tyle.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                    btn41tyle.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));

                    ControlTemplate template41 = new ControlTemplate(typeof(Button));
                    FrameworkElementFactory border41 = new FrameworkElementFactory(typeof(Border));
                    border41.Name = "border";
                    border41.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
                    border41.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 243, 214)));
                    border41.SetValue(Border.BorderBrushProperty, Brushes.Black);
                    border41.SetValue(Border.BorderThicknessProperty, new Thickness(1));
                    border41.SetValue(Border.PaddingProperty, new Thickness(10));

                    FrameworkElementFactory contentPresenter41 = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter41.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter41.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
                    border41.AppendChild(contentPresenter41);

                    template41.VisualTree = border41;

                    Trigger trigger41 = new Trigger { Property = Button.IsMouseOverProperty, Value = true };
                    trigger41.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(219, 188, 107))) { TargetName = "border" });
                    template41.Triggers.Add(trigger41);

                    btn41tyle.Setters.Add(new Setter(Button.TemplateProperty, template41));

                    Style existingStyle41 = (Style)Application.Current.Resources["Btn2"];

                    Application.Current.Resources["Btn2"] = btn41tyle;

                    // Rect1

                    Style rectStyle4 = new Style(typeof(Rectangle));
                    rectStyle4.Setters.Add(new Setter(Rectangle.FillProperty, new SolidColorBrush(Color.FromRgb(255, 220, 129))));
                    rectStyle4.Setters.Add(new Setter(Rectangle.StrokeProperty, Brushes.Black));
                    rectStyle4.Setters.Add(new Setter(Rectangle.StrokeThicknessProperty, 0.5));

                    Style existingStyleRect4 = (Style)Application.Current.Resources["Rect1"];

                    Application.Current.Resources["Rect1"] = rectStyle4;

                    // Bord1

                    Style borderStyle4 = new Style(typeof(Border));
                    borderStyle4.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 220, 129))));
                    borderStyle4.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle4.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle4.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Style existingStyleBorder4 = (Style)Application.Current.Resources["Bord1"];

                    Application.Current.Resources["Bord1"] = borderStyle4;

                    // Bord3

                    Style borderStyle41 = new Style(typeof(Border));
                    borderStyle41.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 232, 172))));
                    borderStyle41.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle41.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0.5)));
                    borderStyle41.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger41 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger41.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(219, 188, 107))));

                    borderStyle41.Triggers.Add(mouseOverTrigger41);

                    Style existingStyleBorder41 = (Style)Application.Current.Resources["Bord3"];

                    Application.Current.Resources["Bord3"] = borderStyle41;

                    // Bord4

                    Style borderStyle42 = new Style(typeof(Border));
                    borderStyle42.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(255, 243, 214))));
                    borderStyle42.Setters.Add(new Setter(Border.BorderBrushProperty, Brushes.Black));
                    borderStyle42.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
                    borderStyle42.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));

                    Trigger mouseOverTrigger42 = new Trigger { Property = Border.IsMouseOverProperty, Value = true };
                    mouseOverTrigger42.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(219, 188, 107))));

                    borderStyle42.Triggers.Add(mouseOverTrigger42);

                    Style existingStyleBorder42 = (Style)Application.Current.Resources["Bord4"];

                    Application.Current.Resources["Bord4"] = borderStyle42;

                    break;
            }

            Style dataGridStyle = new Style(typeof(DataGrid));
            dataGridStyle.Setters.Add(new Setter(DataGrid.ForegroundProperty, Brushes.Black));
            dataGridStyle.Setters.Add(new Setter(DataGrid.FontSizeProperty, (double)CurrentSettings.FontSize));
            dataGridStyle.Setters.Add(new Setter(DataGrid.FontFamilyProperty, new FontFamily("Inter")));
            dataGridStyle.Setters.Add(new Setter(DataGrid.IsReadOnlyProperty, true));
            dataGridStyle.Setters.Add(new Setter(DataGrid.AutoGenerateColumnsProperty, false));
            dataGridStyle.Setters.Add(new Setter(DataGrid.ColumnWidthProperty, new DataGridLength(1, DataGridLengthUnitType.Star)));

            Style existingStyleDataGrid = (Style)Application.Current.Resources["Dg1"];

            Application.Current.Resources["Dg1"] = dataGridStyle;
        }

        /// <summary>
        /// Формированое налогов и задолженностей
        /// </summary>
        public void CheckNextUpdateDate()
        {
            var lastRecord = baza.UpdateTax.OrderByDescending(u => u.NextUpdateDate).FirstOrDefault();
            if (lastRecord != null && lastRecord.NextUpdateDate <= DateTime.Now)
            {
                var updateTax = new UpdateTax
                {
                    UpdateDate = lastRecord.NextUpdateDate,
                    NextUpdateDate = lastRecord.NextUpdateDate.AddYears(1)
                };

                baza.UpdateTax.Add(updateTax);

                var taxpayers = baza.Taxpayer.ToList();

                foreach (var taxpayer in taxpayers)
                {
                    var properties = baza.Property.Where(p => p.IdTaxpayer == taxpayer.IdTaxpayer);
                    double sum = (double)properties.Sum(p => p.Sum);
                    var totalSum = (sum - (sum * 0.13)) * 0.01;

                    var tax = new Tax
                    {
                        IdTaxpayer = taxpayer.IdTaxpayer,
                        IdTaxRate = 2,
                        Sum = (decimal)totalSum,
                        PaymentDeadline = lastRecord.NextUpdateDate.AddYears(1),
                        Status = false
                    };

                    baza.Tax.Add(tax);
                }

                var taxs = baza.Tax.ToList();

                var selectedTaxs = taxs.Where(t => t.PaymentDeadline <= DateTime.Now && t.Status == false).ToList();

                foreach (var tax in selectedTaxs)
                {
                    var arrear = new Arrears
                    {
                        IdTax = tax.IdTax,
                        IdTaxpayer = tax.IdTaxpayer,
                        Sum = tax.Sum,
                        StartDate = tax.PaymentDeadline,
                        Status = false
                    };

                    baza.Arrears.Add(arrear);
                }

                baza.SaveChanges();
            }
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.Key == Key.D1)
            {
                CurrentUser.Login = "admin1";
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();

                string time = DateTime.Now.ToString("HH:mm:ss");

                NotificationHistory.Notifications.Add($"Вы вошли в систему под логином {CurrentUser.Login}!\n({time})");
                CurrentUser.TypeUser = 1;
            }
            if (e.Key == Key.D2)
            {
                EmployeeWindow employeeWindow = new EmployeeWindow();
                employeeWindow.Show();
                this.Close();
                CurrentUser.TypeUser = 2;
            }
            if (e.Key == Key.D3)
            {
                TaxpayerWindow taxpayerWindow = new TaxpayerWindow();
                taxpayerWindow.Show();
                this.Close();
                CurrentUser.TypeUser = 3;
            }*/

            // Переключение между полями ввода
            if (e.Key == Key.Down)
            {
                tbx2.Focus();
            }
            if (e.Key == Key.Up)
            {
                tbx1.Focus();
            }
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            // Проверка для поля Логин
            if (string.IsNullOrWhiteSpace(tbx1.Text))
            {
                MessageBox.Show("Поле \"Логин\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string login = tbx1.Text;
            string password = tbx2.Password;

            var admin = baza.Admins.FirstOrDefault(a => a.Login == login && a.Password == password);
            var employee = baza.Employee.FirstOrDefault(c => c.Login == login && c.Password == password);
            var taxpayer = baza.Taxpayer.FirstOrDefault(t => t.Login == login && t.Password == password);

            // Провекрка, к какому типу пользователя относится введенный логин и пароль
            if (admin != null)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();

                var log = new Logs
                {
                    Login = tbx1.Text,
                    LoginDate = DateTime.Now,
                    IdUserType = 1
                };

                baza.Logs.Add(log);
                baza.SaveChanges();

                string time = DateTime.Now.ToString("HH:mm:ss");

                NotificationHistory.Notifications.Add($"Вы вошли в систему под логином {tbx1.Text}!\n({time})");

                CurrentUser.Login = tbx1.Text;
                CurrentUser.Id = admin.IdAdmin;
                CurrentUser.TypeUser = 1;
            }
            else if (employee != null)
            {
                EmployeeWindow employeeWindow = new EmployeeWindow();
                employeeWindow.Show();
                this.Close();

                var log = new Logs
                {
                    Login = tbx1.Text,
                    LoginDate = DateTime.Now,
                    IdUserType = 2
                };

                baza.Logs.Add(log);
                baza.SaveChanges();

                CurrentUser.Login = tbx1.Text;
                CurrentUser.Id = employee.IdEmployee;
                CurrentUser.TypeUser = 2;
            }
            else if (taxpayer != null)
            {
                TaxpayerWindow taxpayerWindow = new TaxpayerWindow();
                taxpayerWindow.Show();
                this.Close();

                var log = new Logs
                {
                    Login = tbx1.Text,
                    LoginDate = DateTime.Now,
                    IdUserType = 3
                };

                baza.Logs.Add(log);
                baza.SaveChanges();

                CurrentUser.Login = tbx1.Text;
                CurrentUser.Id = taxpayer.IdTaxpayer;
                CurrentUser.TypeUser = 3;
            }
            else
            {
                var userExists = baza.Admins.Any(a => a.Login == login) || baza.Employee.Any(c => c.Login == login) || baza.Taxpayer.Any(t => t.Login == login);
                if (!userExists)
                {
                    MessageBox.Show("Введенный логин не зарегестрирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
