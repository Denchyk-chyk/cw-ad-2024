   M S B A M L   `   `   `  ����=  9CS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CS.General
CS.General  5   	   =#clr-namespace:CS.General.Form.FieldCS.General.Form.Field  5   	   1clr-namespace:CS.General.FormCS.General.Form  5   	        CS.Queries.Eleventh.FormUi   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,generalclr-namespace:CS.General     5   	   6fields#clr-namespace:CS.General.Form.Field     5   	   .formclr-namespace:CS.General.Form     5   	     � Title$  FormUi��5
   	    � WindowStartupLocation$ CenterScreen=�6      
FormWindow#��[  6=    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        FillCommandBinding��   Command$( "general:CustomCommands.FillCommand��5   5   6b   .��5      �   FormGrid#��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   %   CS.General.Form.Field.ListField  -   5          Name$ ProductCategory��5         Title$ Категорія��64   $��0��6F     5   
   -   5        $ 
Laboratory��5      $ Лабораорія��6/   $��1��6B   %   CS.General.Form.Field.DateField  5   
   -   5          Name$ 	FirstDate��5         Title$! Початкова дата��6.   $��2��6E     5   
   -   5        $ LastDate��5      $ Кінцева дата��6-   $��3��6B   !   CS.General.Form.FormButtons  5   
   -   5        	  Name$	 Buttons��5      $��4��6,   5      5      