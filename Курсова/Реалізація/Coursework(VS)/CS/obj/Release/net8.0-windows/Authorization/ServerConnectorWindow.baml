   M S B A M L   `   `   `  ���� =  9CS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CS.General.FormCS.General.Form  =#clr-namespace:CS.General.Form.FieldCS.General.Form.Field  'clr-namespace:CS.General
CS.General  ,    &CS.Authorization.ServerConnectorWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .formclr-namespace:CS.General.Form     6fields#clr-namespace:CS.General.Form.Field     ,generalclr-namespace:CS.General       � Title$  ServerConnectionWindow�� � WindowStartupLocation$ CenterScreen=�   
FormWindow#��[   J� CommandBindings )  #System.Windows.Input.CommandBinding  -   FillCommandBinding��   Command$( "general:CustomCommands.FillCommand��.��� -    �Name$ Wrapper��$
��0 10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�%   CS.General.Form.Field.TextField  -     Name$
 Host��   Title$ Хост��$��0��  -   $
 Name��$ Ім'я��$��1��  -   $ Password��$ Пароль��$��2��  -   $ Database��$ База даних��$��3��!   CS.General.Form.FormButtons  -     Name$ Buttons��$��4��