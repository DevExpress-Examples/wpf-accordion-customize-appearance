<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/353310423/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T986691)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Accordion - Appearance Customization

This example demonstrates how to customize appearance settings (foreground and background colors, border color and thickness) of the following accordion UI elements:

* Accordion Header
* Accordion Item

```xaml
<dxa:AccordionControl x:Name="accordion">
    <dxa:AccordionControl.HeaderStyle>
        <Style TargetType="dxa:HeaderPresenter" >
            <Setter Property="Background" Value="#e6f2fa"/>
            <Setter Property="Foreground" Value="Brown"/>
            <Setter Property="BorderBrush" Value="#51555f"/>
            <Setter Property="BorderThickness" Value="0,0,0,1"/>
        </Style>
    </dxa:AccordionControl.HeaderStyle>
    <dxa:AccordionControl.ItemContainerStyle>
        <Style TargetType="dxa:AccordionItem">
            <Setter Property="Foreground" Value="Red"/>
            <Setter Property="ShowInCollapsedMode" Value="{Binding ShowInCollapsedMode}"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsCustomView}" Value="True">
                    <Setter Property="Background" Value="#e6f2fa" />
                    <Setter Property="BorderBrush" Value="#0072c6"/>
                    <Setter Property="BorderThickness" Value="1"/>
                    <Setter Property="Foreground" Value="Orange"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </dxa:AccordionControl.ItemContainerStyle>
</dxa:AccordionControl>
```


## Files to Review

* [MainWindow.xaml](./CS/AppearanceCustomization/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/AppearanceCustomization/MainWindow.xaml))
* [MainViewModel.cs](./CS/AppearanceCustomization/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/AppearanceCustomization/MainViewModel.vb))


## Documentation

* [Accordion Control](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control)
* [Getting Started (Accordion Control)](https://docs.devexpress.com/WPF/119805/controls-and-libraries/navigation-controls/accordion-control/getting-started)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-accordion-customize-appearance&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-accordion-customize-appearance&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
