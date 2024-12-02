using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Ihatedthiswork.Вспомогательные_классы
{
    internal class App
    {
        <Application.Resources>
        <local:TextEmptyToVisibilityConverter x:Key="TextEmptyToVisibilityConverter" />
        <Style TargetType = "Button" >
            < Setter Property="Background" Value="Gray" />
            <Setter Property = "Foreground" Value="White" />
            <Setter Property = "BorderBrush" Value="Transparent" />
            <Setter Property = "Padding" Value="10,5" />
            <Setter Property = "FontWeight" Value="Bold" />
            <Setter Property = "Template" >
                < Setter.Value >
                    < ControlTemplate TargetType="Button">
                        <Border Background = "{TemplateBinding Background}"
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="1"
                                CornerRadius="10">
                            <ContentPresenter HorizontalAlignment = "Center"
                                             VerticalAlignment="Center"
                                             Content="{TemplateBinding Content}"
                                             ContentTemplate="{TemplateBinding ContentTemplate}" />
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Application.Resources>
    }
}
